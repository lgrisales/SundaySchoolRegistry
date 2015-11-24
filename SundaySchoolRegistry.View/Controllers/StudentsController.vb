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

        ''' <summary>
        ''' Guardian business logic attribute
        ''' </summary>
        Private guardianService As New GuardianService()

        ''' <summary>
        ''' courses business logic attribute
        ''' </summary>
        Private courseService As New CourseService()

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


        ''' <summary>
        ''' Create a list to populate the courses
        ''' </summary>
        ''' <param name="courses">list of courses</param>
        ''' <returns>SelectList of courses</returns>
        Function GetCourses(courses As IEnumerable(Of Cours)) As SelectList
            Dim selectList As SelectList = New SelectList(courses, "Id", "Name")
            Return selectList
        End Function

        ' GET: Students/Create
        ''' <summary>
        ''' Action to call the page to create a student
        ''' </summary>
        ''' <returns>Empty view to for the user to enter the student information</returns>
        Function Create() As ActionResult
            Dim courses As IEnumerable = courseService.FindAll()
            ViewBag.Courses = GetCourses(courses)
            Return View()
        End Function



        ' POST: Students/Create
        ''' <summary>
        ''' Action invoked to create Students.
        ''' </summary>
        ''' <param name="student">Student information to be inserted in the database</param>
        ''' <returns>View to be displayed once the teacher is created</returns>
        <HttpPost()>
        Function Create(<Bind(Include:="Id,FirstName,LastName,Address,City,DateBirth,Allergies,SpecialInstructions,CourseId")> ByVal student As Student) As ActionResult
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

            Dim courses As IEnumerable = courseService.FindAll()
            ViewBag.Courses = GetCourses(courses)

            Return View(student)
        End Function


        ' POST: Students/Edit/5
        ''' <summary>
        ''' Action invoke to update Students.
        ''' </summary>
        ''' <param name="student">student information to be updated</param>
        ''' <returns>view to be displayed</returns>
        <HttpPost()>
        Function Edit(<Bind(Include:="Id,FirstName,LastName,Address,City,DateBirth,Allergies,SpecialInstructions,CourseId")> ByVal student As Student) As ActionResult
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

        ''' <summary>
        ''' Create a list to populate the guardian dropdown
        ''' </summary>
        ''' <param name="guardians">list of guardians</param>
        ''' <returns>list of guardians</returns>
        Function GetGuardians(guardians As IEnumerable(Of Guardian)) As SelectList
            Dim list = New List(Of SelectListItem)
            For Each guardian As Guardian In guardians
                list.Add(New SelectListItem With
                {
                    .Value = guardian.Id,
                    .Text = guardian.FirstName + " " + guardian.LastName
                }
                )
            Next
            Dim selectList As SelectList = New SelectList(list, "Value", "Text")
            Return selectList

        End Function

        ''' <summary>
        ''' Create a list to populate the guardian types
        ''' </summary>
        ''' <param name="types">types</param>
        ''' <returns>list of guardian types</returns>
        Function GetGuardianTypes(types As IEnumerable(Of GuardianType)) As SelectList
            Dim selectList As SelectList = New SelectList(types, "Id", "Name")
            Return selectList
        End Function

        ' GET: Students/AddGuardian
        ''' <summary>
        ''' Action to call the page to Add guardian page
        ''' </summary>
        ''' <returns>Empty view to for the user to select the student's gardian</returns>
        Function AddGuardian(ByVal id As Integer) As ActionResult
            Dim guardians As IEnumerable = guardianService.FindAll()
            ViewBag.Guardians = GetGuardians(guardians)

            Dim types As IEnumerable = guardianService.FindAllGuardianTypes()
            ViewBag.GuardianTypes = GetGuardianTypes(types)

            Dim guardianStudent = New GuardianStudent()
            guardianStudent.Student = studentService.Find(id)
            guardianStudent.StudentId = guardianStudent.Student.Id

            Return View(guardianStudent)
        End Function


        ' POST: Students/AddGuardian
        ''' <summary>
        ''' Action invoked to Add guardian.
        ''' </summary>
        ''' <param name="guardianStudent">Guardian Student information to be inserted in the database</param>
        ''' <returns>View to be displayed once the guardian is associated with the student</returns>
        <HttpPost()>
        Function AddGuardian(<Bind(Include:="GuardianId,StudentId,GuardianTypeId")> ByVal guardianStudent As GuardianStudent) As ActionResult
            Try
                If ModelState.IsValid Then
                    studentService.AddGuardian(guardianStudent)
                    Return RedirectToAction("Edit", New With {.id = guardianStudent.StudentId})
                End If
                ' if the information is not valid return to the create page and display the information again
            Catch ex As Exception
                ModelState.AddModelError("", "Error adding the Guardian. Make sure the guardian selected has not been already assgined")
            End Try
            Return RedirectToAction("AddGuardian", New With {.id = guardianStudent.StudentId})

        End Function


        ' GET: Students/DeleteGuardian/5
        ''' <summary>
        ''' Action to call the page for deleting the teacher
        ''' </summary>
        ''' <param name="StudentId">student id</param>
        ''' <returns>Call page to delete the student</returns>
        Function DeleteGuardian(ByVal GuardianId As Integer?, ByVal StudentId As Integer?) As ActionResult

            If IsNothing(GuardianId) Or IsNothing(StudentId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim guardianStudent = New GuardianStudent()
            guardianStudent.GuardianId = GuardianId
            guardianStudent.StudentId = StudentId
            studentService.RemoveGuardian(guardianStudent)

            Return RedirectToAction("Edit", New With {.id = StudentId})
        End Function


    End Class
End Namespace
