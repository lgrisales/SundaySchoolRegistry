'File: ClassRoomsController.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description: Presentation Layer.Controller that 
'manages all operation to administer ClassRooms

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
    Public Class ClassRoomsController
        Inherits System.Web.Mvc.Controller

        ''' <summary>
        ''' Classroom business logic attribute
        ''' </summary>
        Private classRoomService As New ClassRoomService()

        ' GET: Classrooms.
        ''' <summary>
        ''' Action that queries all classRooms 
        ''' </summary>
        ''' <returns>View model to display a collection of classRooms</returns>
        Function Index() As ActionResult
            Return View(classRoomService.FindAll())
        End Function

        ' GET: Classrooms/Details/5
        ''' <summary>
        ''' Action that queries a specific classRoom's details by Id
        ''' </summary>
        ''' <param name="id">classRoom id</param>
        ''' <returns>ClassRoom information</returns>
        Function Details(ByVal id As Integer?) As ActionResult
            ' return http error if classRoom ID is not sent as part of the URL
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' Get the user information 
            Dim classRoom As ClassRoom = classRoomService.Find(id)
            ' if the user is null, send an http error.
            If IsNothing(classRoom) Then
                Return HttpNotFound()
            End If
            Return View(classRoom)
        End Function

        ' GET: Classrooms/Create
        ''' <summary>
        ''' Action to call the page to create a classRoom
        ''' </summary>
        ''' <returns>Empty view to for the user to enter the classRoom information</returns>
        Function Create() As ActionResult
            Return View() 'form to create the view
        End Function

        ' POST: Classrooms/Create
        ''' <summary>
        ''' Action invoked to create Classrooms.
        ''' </summary>
        ''' <param name="classRoom">ClassRoom information to be inserted in the database</param>
        ''' <returns>View to be displayed once the classRoom is created</returns>
        <HttpPost()>
        Function Create(<Bind(Include:="Id,RoomNumber,Description")> ByVal classRoom As ClassRoom) As ActionResult
            ' check if the classRoom is information is complete and valid
            If ModelState.IsValid Then
                ' create the classRoom and redirect to the list of classRoom page
                classRoomService.Create(classRoom)
                Return RedirectToAction("Index")
            End If
            ' if the information is not valid return to the create page and display the information again
            Return View(classRoom)
        End Function

        ' GET: Classrooms/Edit/5
        ''' <summary>
        ''' Action to call the page to update a classRoom
        ''' </summary>
        ''' <param name="id">classRoom id</param>
        ''' <returns>View to diplay the classRoom information</returns>
        Function Edit(ByVal id As Integer?) As ActionResult
            ' check if the classRoom id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the classRoom information
            Dim classRoom As ClassRoom = classRoomService.Find(id)
            ' if the classRoom does not exist return an http error
            If IsNothing(classRoom) Then
                Return HttpNotFound()
            End If
            Return View(classRoom)
        End Function

        ' POST: Classrooms/Edit/5
        ''' <summary>
        ''' Action invoke to update Classrooms.
        ''' </summary>
        ''' <param name="classRoom">classRoom information to be updated</param>
        ''' <returns>view to be displayed</returns>
        <HttpPost()>
        Function Edit(<Bind(Include:="Id,RoomNumber,Description")> ByVal classRoom As ClassRoom) As ActionResult
            ' validate the information is correct
            If ModelState.IsValid Then
                ' update classRoom
                Try
                    classRoomService.Update(classRoom)
                    ' redirect to the list of classRoom
                    Return RedirectToAction("Index")
                Catch ex As Exception
                    ' the the error message to be displayed in the html page
                    ModelState.AddModelError("", ex.Message)
                End Try

            End If
            ' redirect to the same page to update classRoom information
            Return View(classRoom)
        End Function

        ' GET: Classrooms/Delete/5
        ''' <summary>
        ''' Action to call the page for deleting the classRoom
        ''' </summary>
        ''' <param name="id">classRoom id</param>
        ''' <returns>Call page to delete the classRoom</returns>
        Function Delete(ByVal id As Integer?) As ActionResult
            ' check if id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the classRoom information
            Dim classRoom As ClassRoom = classRoomService.Find(id)
            ' validate if the user exists
            If IsNothing(classRoom) Then
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", "Classroom does not exist")
            End If
            Return View(classRoom)
        End Function

        ' POST: Classrooms/Delete/5
        ''' <summary>
        ''' Action call when the user has confirmed that
        ''' the classRoom needs to be deleted
        ''' </summary>
        ''' <param name="id">classRoom id</param>
        ''' <returns>page to list all classRooms</returns>
        <HttpPost()>
        <ActionName("Delete")> ' ActionName allows  to defined a new URL to call this method
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Try
                classRoomService.Delete(id)
            Catch ex As Exception
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", ex.Message)
                Return RedirectToAction("Delete", New With {.id = id})

            End Try
            Return RedirectToAction("Index")
        End Function



    End Class
End Namespace
