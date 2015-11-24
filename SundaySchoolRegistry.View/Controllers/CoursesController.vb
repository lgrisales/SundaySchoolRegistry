'File: CoursesController.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description: Presentation Layer.Controller that 
'manages all operation to administer courses
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
    Public Class CoursesController
        Inherits System.Web.Mvc.Controller

        ''' <summary>
        ''' Course business logic attribute
        ''' </summary>
        Private courseService As New CourseService()
        Private classroosmService As New ClassRoomService()
        Private teacherService As New TeacherService()


        ' GET: Courses.
        ''' <summary>
        ''' Action that queries all courses 
        ''' </summary>
        ''' <returns>View model to display a collection of courses</returns>
        Function Index() As ActionResult
            Return View(courseService.FindAll())
        End Function

        ' GET: Courses/Details/5
        ''' <summary>
        ''' Action that queries a specific course's details by Id
        ''' </summary>
        ''' <param name="id">course id</param>
        ''' <returns>Course information</returns>
        Function Details(ByVal id As Integer?) As ActionResult
            ' return http error if course ID is not sent as part of the URL
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' Get the user information 
            Dim course As Cours = courseService.Find(id)
            ' if the user is null, send an http error.
            If IsNothing(course) Then
                Return HttpNotFound()
            End If
            Return View(course)
        End Function

        ' GET: Courses/Create
        ''' <summary>
        ''' Action to call the page to create a course
        ''' </summary>
        ''' <returns>Empty view to for the user to enter the course information</returns>
        Function Create() As ActionResult
            Dim classrooms As IEnumerable = classroosmService.FindAll()
            ViewBag.Classrooms = GetClassrooms(classrooms)
            Dim techers As IEnumerable = teacherService.FindAll()
            ViewBag.Teachers = GetTeachers(techers)

            Return View() 'form to create the view
        End Function

        ''' <summary>
        ''' Create a list to populate the classrooms
        ''' </summary>
        ''' <param name="rooms">list of classrooms</param>
        ''' <returns>Selectlist of classrooms</returns>
        Function GetClassrooms(rooms As IEnumerable(Of ClassRoom)) As SelectList
            Dim selectList As SelectList = New SelectList(rooms, "Id", "RoomNumber")
            Return selectList
        End Function

        ''' <summary>
        ''' Create a list to populate the teachers
        ''' </summary>
        ''' <param name="teachers">list of teacher</param>
        ''' <returns>Selectlist of teachers</returns>
        Function GetTeachers(teachers As IEnumerable(Of Teacher)) As SelectList
            Dim list = New List(Of SelectListItem)
            For Each teacher As Teacher In teachers
                list.Add(New SelectListItem With
                {
                    .Value = teacher.Id,
                    .Text = teacher.FirstName + " " + teacher.LastName
                }
                )
            Next
            Dim selectList As SelectList = New SelectList(list, "Value", "Text")
            Return selectList
        End Function

        ' POST: Courses/Create
        ''' <summary>
        ''' Action invoked to create Courses.
        ''' </summary>
        ''' <param name="course">Course information to be inserted in the database</param>
        ''' <returns>View to be displayed once the course is created</returns>
        <HttpPost()>
        Function Create(<Bind(Include:="Id,Name,Description,StartHour,EndHour,MinimumAge,MaximumAge,DayOfWeek,ClassroomId,TeacherId")> ByVal course As Cours) As ActionResult
            ' check if the course is information is complete and valid
            If ModelState.IsValid Then
                ' create the course and redirect to the list of course page
                courseService.Create(course)
                Return RedirectToAction("Index")
            End If
            ' if the information is not valid return to the create page and display the information again
            Return View(course)
        End Function

        ' GET: Courses/Edit/5
        ''' <summary>
        ''' Action to call the page to update a course
        ''' </summary>
        ''' <param name="id">course id</param>
        ''' <returns>View to diplay the course information</returns>
        Function Edit(ByVal id As Integer?) As ActionResult
            ' check if the course id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the course information
            Dim course As Cours = courseService.Find(id)
            ' if the course does not exist return an http error
            If IsNothing(course) Then
                Return HttpNotFound()
            End If

            Dim classrooms As IEnumerable = classroosmService.FindAll()
            ViewBag.Classrooms = GetClassrooms(classrooms)
            Dim techers As IEnumerable = teacherService.FindAll()
            ViewBag.Teachers = GetTeachers(techers)

            Return View(course)
        End Function

        ' POST: Courses/Edit/5
        ''' <summary>
        ''' Action invoke to update Courses.
        ''' </summary>
        ''' <param name="course">course information to be updated</param>
        ''' <returns>view to be displayed</returns>
        <HttpPost()>
        Function Edit(<Bind(Include:="Id,Name,Description,StartHour,EndHour,MinimumAge,MaximumAge,DayOfWeek,ClassroomId,TeacherId")> ByVal course As Cours) As ActionResult
            ' validate the information is correct
            If ModelState.IsValid Then
                ' update course
                Try
                    courseService.Update(course)
                    ' redirect to the list of course
                    Return RedirectToAction("Index")
                Catch ex As Exception
                    ' the the error message to be displayed in the html page
                    ModelState.AddModelError("", ex.Message)
                End Try

            End If
            ' redirect to the same page to update course information
            Return View(course)
        End Function

        ' GET: Courses/Delete/5
        ''' <summary>
        ''' Action to call the page for deleting the course
        ''' </summary>
        ''' <param name="id">course id</param>
        ''' <returns>Call page to delete the course</returns>
        Function Delete(ByVal id As Integer?) As ActionResult
            ' check if id was sent
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            ' query the course information
            Dim course As Cours = courseService.Find(id)
            ' validate if the user exists
            If IsNothing(course) Then
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", "Course does not exist")
            End If
            Return View(course)
        End Function

        ' POST: Courses/Delete/5
        ''' <summary>
        ''' Action call when the user has confirmed that
        ''' the course needs to be delelted
        ''' </summary>
        ''' <param name="id">course id</param>
        ''' <returns>page to list all courses</returns>
        <HttpPost()>
        <ActionName("Delete")> ' ActionName allows  to defined a new URL to call this method
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Try
                courseService.Delete(id)
            Catch ex As Exception
                ' the the error message to be displayed in the html page
                ModelState.AddModelError("", ex.Message)
                Return RedirectToAction("Delete", New With {.id = id})

            End Try
            Return RedirectToAction("Index")
        End Function


    End Class
End Namespace
