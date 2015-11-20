'File: TeachersController.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description: Presentation Layer.Controller that 
'manages all operation to administer teachers
Imports System.Net
Imports SundaySchoolRegistry.Model
Imports SundaySchoolRegistry.Service

Namespace Controllers

    Public Class TeachersController
        Inherits System.Web.Mvc.Controller

        ''' <summary>
        ''' Teacher business logic attribute
        ''' </summary>
        Private teacherService As New TeacherService()

        ' GET: Teachers.
        ''' <summary>
        ''' Action that queries all teachers 
        ''' </summary>
        ''' <returns>View model to display a collection of teachers</returns>
        Function Index() As ActionResult
            Return View(teacherService.FindAll())
        End Function

        ' GET: Teachers/Details/5
        ''' <summary>
        ''' Action that queries a specific teacher's details by Id
        ''' </summary>
        ''' <param name="id">teacher id</param>
        ''' <returns>Teacher information</returns>
        Function Details(ByVal id As Integer?) As ActionResult
            ' return http error if teacher ID is not sent as part of the URL
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' Get the user information 
            Dim teacher As Teacher = teacherService.Find(id)
            ' if the user is null, send an http error.
            If IsNothing(teacher) Then
                Return HttpNotFound()
            End If
            Return View(teacher)
        End Function

        ' GET: Teachers/Create
        ''' <summary>
        ''' Action to call the page to create a teacher
        ''' </summary>
        ''' <returns>Empty view to for the user to enter the teacher information</returns>
        Function Create() As ActionResult
            Return View() 'form to create the view
        End Function

        ' POST: Teachers/Create
        ''' <summary>
        ''' Action invoked to create Teachers.
        ''' </summary>
        ''' <param name="teacher">Teacher information to be inserted in the database</param>
        ''' <returns>View to be displayed once the teacher is created</returns>
        <HttpPost()>
        Function Create(<Bind(Include:="Id,FirstName,LastName,PhoneNumber")> ByVal teacher As Teacher) As ActionResult
            ' check if the teacher is information is complete and valid
            If ModelState.IsValid Then
                ' create the teacher and redirect to the list of teacher page
                teacherService.Create(teacher)
                Return RedirectToAction("Index")
            End If
            ' if the information is not valid return to the create page and display the information again
            Return View(teacher)
        End Function

        ' GET: Teachers/Edit/5
        ''' <summary>
        ''' Action to call the page to update a teacher
        ''' </summary>
        ''' <param name="id">teacher id</param>
        ''' <returns>View to diplay the teacher information</returns>
        Function Edit(ByVal id As Integer?) As ActionResult
            ' check if the teacher id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the teacher information
            Dim teacher As Teacher = teacherService.Find(id)
            ' if the teacher does not exist return an http error
            If IsNothing(teacher) Then
                Return HttpNotFound()
            End If
            Return View(teacher)
        End Function

        ' POST: Teachers/Edit/5
        ''' <summary>
        ''' Action invoke to update Teachers.
        ''' </summary>
        ''' <param name="teacher">teacher information to be updated</param>
        ''' <returns>view to be displayed</returns>
        <HttpPost()>
        Function Edit(<Bind(Include:="Id,FirstName,LastName,PhoneNumber")> ByVal teacher As Teacher) As ActionResult
            ' validate the information is correct
            If ModelState.IsValid Then
                ' update teacher
                Try
                    teacherService.Update(teacher)
                    ' redirect to the list of teacher
                    Return RedirectToAction("Index")
                Catch ex As Exception
                    ' the the error message to be displayed in the html page
                    ModelState.AddModelError("", ex.Message)
                End Try

            End If
            ' redirect to the same page to update teacher information
            Return View(teacher)
        End Function

        ' GET: Teachers/Delete/5
        ''' <summary>
        ''' Action to call the page for deleting the teacher
        ''' </summary>
        ''' <param name="id">teacher id</param>
        ''' <returns>Call page to delete the teacher</returns>
        Function Delete(ByVal id As Integer?) As ActionResult
            ' check if id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the teacher information
            Dim teacher As Teacher = teacherService.Find(id)
            ' validate if the user exists
            If IsNothing(teacher) Then
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", "Teacher does not exist")
            End If
            Return View(teacher)
        End Function

        ' POST: Teachers/Delete/5
        ''' <summary>
        ''' Action call when the user has confirmed that
        ''' the teacher needs to be delelted
        ''' </summary>
        ''' <param name="id">teacher id</param>
        ''' <returns>page to list all teachers</returns>
        <HttpPost()>
        <ActionName("Delete")> ' ActionName allows  to defined a new URL to call this method
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Try
                teacherService.Delete(id)
            Catch ex As Exception
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", ex.Message)
                Return RedirectToAction("Delete", New With {.id = id})

            End Try
            Return RedirectToAction("Index")
        End Function


    End Class
End Namespace
