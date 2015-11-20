'File: StudentsController.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description: Presentation Layer.Controller that 
'manages all operation to administer students
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
    Public Class StudentsController
        Inherits System.Web.Mvc.Controller

        ''' <summary>
        ''' Students business logic attribute
        ''' </summary>
        Private studentService As New StudentService()

        ' GET: /students.
        ''' <summary>
        ''' Action that queries all teachers 
        ''' </summary>
        ''' <returns>View model to display a collection of teachers</returns>
        Function Index() As ActionResult
            Return View(studentService.FindAll())
        End Function

        ' GET: Students/Details/5
        ''' <summary>
        ''' Action that queries a specific students's details by Id
        ''' </summary>
        ''' <param name="id">student id</param>
        ''' <returns>student information</returns>
        Function Details(ByVal id As Integer?) As ActionResult
            ' return http error if student ID is not sent as part of the URL
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' Get the user information 
            Dim student As Student = studentService.Find(id)
            ' if the user is null, send an http error.
            If IsNothing(student) Then
                Return HttpNotFound()
            End If
            Return View(student)
        End Function

        ' GET: Students/Create
        ''' <summary>
        ''' Action to call the page to create a student
        ''' </summary>
        ''' <returns>Empty view to for the user to enter the student information</returns>
        Function Create() As ActionResult
            Return View()
        End Function


        ' POST: Students/Create
        ''' <summary>
        ''' Action invoked to create Students.
        ''' </summary>
        ''' <param name="student">Student information to be inserted in the database</param>
        ''' <returns>View to be displayed once the teacher is created</returns>
        <HttpPost()>
        Function Create(<Bind(Include:="Id,FirstName,LastName,Address,City,DateBirth,Allergies,SpecialInstructions")> ByVal student As Student) As ActionResult
            ' check if the student is information is complete and valid
            If ModelState.IsValid Then
                ' create the student and redirect to the list of teacher page
                studentService.Create(student)
                Return RedirectToAction("Index")
            End If
            ' if the information is not valid return to the create page and display the information again
            Return View(student)
        End Function

        ' GET: Students/Edit/5
        ''' <summary>
        ''' Action to call the page to update a student
        ''' </summary>
        ''' <param name="id">student id</param>
        ''' <returns>View to diplay the student information</returns>
        Function Edit(ByVal id As Integer?) As ActionResult
            ' check if the student id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the student information
            Dim student As Student = studentService.Find(id)
            ' if the teacher does not exist return an http error
            If IsNothing(student) Then
                Return HttpNotFound()
            End If
            Return View(student)
        End Function


        ' POST: Students/Edit/5
        ''' <summary>
        ''' Action invoke to update Students.
        ''' </summary>
        ''' <param name="student">student information to be updated</param>
        ''' <returns>view to be displayed</returns>
        <HttpPost()>
        Function Edit(<Bind(Include:="Id,FirstName,LastName,Address,City,DateBirth,Allergies,SpecialInstructions")> ByVal student As Student) As ActionResult
            ' validate the information is correct
            If ModelState.IsValid Then
                ' update student
                Try
                    studentService.Update(student)
                    ' redirect to the list of student
                    Return RedirectToAction("Index")
                Catch ex As Exception
                    ' the the error message to be displayed in the html page
                    ModelState.AddModelError("", ex.Message)
                End Try

            End If
            ' redirect to the same page to update student information
            Return View(student)
        End Function

        ' GET: Students/Delete/5
        ''' <summary>
        ''' Action to call the page for deleting the teacher
        ''' </summary>
        ''' <param name="id">student id</param>
        ''' <returns>Call page to delete the student</returns>
        Function Delete(ByVal id As Integer?) As ActionResult
            ' check if id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the student information
            Dim student As Student = studentService.Find(id)
            ' validate if the student exists
            If IsNothing(student) Then
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", "Student does not exist")
            End If
            Return View(student)
        End Function


        ' POST: Students/Delete/5
        ''' <summary>
        ''' Action call when the user has confirmed that
        ''' the student needs to be delelted
        ''' </summary>
        ''' <param name="id">student id</param>
        ''' <returns>page to list all students</returns>
        <HttpPost()>
        <ActionName("Delete")> ' ActionName allows  to defined a new URL to call this method
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Try
                studentService.Delete(id)
            Catch ex As Exception
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", ex.Message)
                Return RedirectToAction("Delete", New With {.id = id})

            End Try
            Return RedirectToAction("Index")
        End Function


    End Class
End Namespace
