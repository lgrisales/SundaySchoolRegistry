'File: GuardianController.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description: Presentation Layer.Controller that 
'manages all operation to administer guardians
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports SundaySchoolRegistry.Model
Imports SundaySchoolRegistry.Service

Namespace Controllers
    Public Class GuardiansController
        Inherits System.Web.Mvc.Controller

        ''' <summary>
        ''' Guardian business logic attribute
        ''' </summary>
        Private guardianService As New GuardianService()


        ' GET: Teachers.
        ''' <summary>
        ''' Action that queries all teachers 
        ''' </summary>
        ''' <returns>View model to display a collection of teachers</returns>
        Function Index() As ActionResult
            Return View(guardianService.FindAll())
        End Function

        ' GET: Teachers/Details/5
        ''' <summary>
        ''' Action that queries a specific guardian's details by Id
        ''' </summary>
        ''' <param name="id">guardian id</param>
        ''' <returns>Guardian information</returns>
        Function Details(ByVal id As Integer?) As ActionResult
            ' return http error if guardian ID is not sent as part of the URL
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' Get the user information 
            Dim guardian As Guardian = guardianService.Find(id)
            ' if the user is null, send an http error.
            If IsNothing(guardian) Then
                Return HttpNotFound()
            End If
            Return View(guardian)
        End Function

        ' GET: Teachers/Create
        ''' <summary>
        ''' Action to call the page to create a guardian
        ''' </summary>
        ''' <returns>Empty view to for the user to enter the guardian information</returns>
        Function Create() As ActionResult
            Return View() 'form to create the view
        End Function

        ' POST: Teachers/Create
        ''' <summary>
        ''' Action invoked to create Teachers.
        ''' </summary>
        ''' <param name="guardian">Guardian information to be inserted in the database</param>
        ''' <returns>View to be displayed once the guardian is created</returns>
        <HttpPost()>
        Function Create(<Bind(Include:="Id,FirstName,LastName,Address,City,CellNumber,HomeNumber,Status")> ByVal guardian As Guardian) As ActionResult
            ' check if the guardian is information is complete and valid
            If ModelState.IsValid Then
                ' create the guardian and redirect to the list of guardian page
                guardianService.Create(guardian)
                Return RedirectToAction("Index")
            End If
            ' if the information is not valid return to the create page and display the information again
            Return View(guardian)
        End Function

        ' GET: Teachers/Edit/5
        ''' <summary>
        ''' Action to call the page to update a guardian
        ''' </summary>
        ''' <param name="id">guardian id</param>
        ''' <returns>View to diplay the guardian information</returns>
        Function Edit(ByVal id As Integer?) As ActionResult
            ' check if the guardian id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the guardian information
            Dim guardian As Guardian = guardianService.Find(id)
            ' if the guardian does not exist return an http error
            If IsNothing(guardian) Then
                Return HttpNotFound()
            End If
            Return View(guardian)
        End Function

        ' POST: Teachers/Edit/5
        ''' <summary>
        ''' Action invoke to update Teachers.
        ''' </summary>
        ''' <param name="guardian">guardian information to be updated</param>
        ''' <returns>view to be displayed</returns>
        <HttpPost()>
        Function Edit(<Bind(Include:="Id,FirstName,LastName,Address,City,CellNumber,HomeNumber,Status")> ByVal guardian As Guardian) As ActionResult
            ' validate the information is correct
            If ModelState.IsValid Then
                ' update guardian
                Try
                    guardianService.Update(guardian)
                    ' redirect to the list of guardian
                    Return RedirectToAction("Index")
                Catch ex As Exception
                    ' the the error message to be displayed in the html page
                    ModelState.AddModelError("", ex.Message)
                End Try

            End If
            ' redirect to the same page to update guardian information
            Return View(guardian)
        End Function

        ' GET: Teachers/Delete/5
        ''' <summary>
        ''' Action to call the page for deleting the guardian
        ''' </summary>
        ''' <param name="id">guardian id</param>
        ''' <returns>Call page to delete the guardian</returns>
        Function Delete(ByVal id As Integer?) As ActionResult
            ' check if id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the guardian information
            Dim guardian As Guardian = guardianService.Find(id)
            ' validate if the user exists
            If IsNothing(guardian) Then
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", "Guardian does not exist")
            End If
            Return View(guardian)
        End Function

        ' POST: Teachers/Delete/5
        ''' <summary>
        ''' Action call when the user has confirmed that
        ''' the guardian needs to be delelted
        ''' </summary>
        ''' <param name="id">guardian id</param>
        ''' <returns>page to list all teachers</returns>
        <HttpPost()>
        <ActionName("Delete")> ' ActionName allows  to defined a new URL to call this method
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Try
                guardianService.Delete(id)
            Catch ex As Exception
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", ex.Message)
                Return RedirectToAction("Delete", New With {.id = id})

            End Try
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace
