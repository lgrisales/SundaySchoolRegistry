'File: CourseServices.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description:Class to manage the  Course business logic
Imports SundaySchoolRegistry.Repository
Imports SundaySchoolRegistry.Model
Public Class CourseService
    ''' <summary>
    ''' Create a  Course
    ''' </summary>
    ''' <param name=" course"> Course information</param>
    Public Sub Create(course As Cours)

        Using repository As New CourseRepository()

            repository.Create(course)
        End Using  'dispose the object

    End Sub

    ''' <summary>
    ''' Update a course's information
    ''' </summary>
    ''' <param name="course">course information</param>
    Public Sub Update(course As Cours)
        Using repository As New CourseRepository()
            ' check if the course exists
            Dim existingCourse = Find(course.Id)
            If Not IsNothing(existingCourse) Then
                repository.Update(course)
            Else
                Throw New CourseException("course does not exist.")
            End If

        End Using
    End Sub

    ''' <summary>
    ''' Deletes a course
    ''' </summary>
    ''' <param name="id">course id</param>
    Public Sub Delete(id As Integer)
        Using repository As New CourseRepository()
            ' check if the course exists
            Dim course = repository.Find(id)
            If Not IsNothing(course) Then
                repository.Delete(course)
            Else
                Throw New CourseException("course does not exist.")
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Returns a course information by Id
    ''' </summary>
    ''' <param name="id">course id</param>
    ''' <returns>course's information</returns>
    Public Function Find(id As Integer) As Cours

        Dim course As Cours

        Using repository As New CourseRepository()

            course = repository.Find(id)
        End Using
        Return course

    End Function

    ''' <summary>
    ''' Returns all courses
    ''' </summary>
    ''' <returns>list of courses</returns>
    Public Function FindAll() As IEnumerable
        Dim courses As IEnumerable(Of Cours)

        Using repository As New CourseRepository()

            courses = repository.FindAll()
        End Using
        Return courses
    End Function

End Class
