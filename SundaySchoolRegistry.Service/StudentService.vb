'File: StudentService.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description:Class to manage the Student business logic

Imports SundaySchoolRegistry.Repository
Imports SundaySchoolRegistry.Model

Public Class StudentService

    ''' <summary>
    ''' Create a Student
    ''' </summary>
    ''' <param name="student">Student information</param>
    Public Sub Create(student As Student)

        Using repository As New StudentRepository

            repository.Create(student)
        End Using  'dispose the object

    End Sub

    ''' <summary>
    ''' Update a student's information
    ''' </summary>
    ''' <param name="student">student information</param>
    Public Sub Update(student As Student)
        Using repository As New StudentRepository()
            ' check if the student exists
            Dim existingStudent = Find(student.Id)
            If Not IsNothing(existingStudent) Then
                repository.Update(student)
            Else
                Throw New StudentException("student does not exist.")
            End If

        End Using
    End Sub

    ''' <summary>
    ''' Deletes a student
    ''' </summary>
    ''' <param name="id">student id</param>
    Public Sub Delete(id As Integer)
        Using repository As New StudentRepository()
            ' check if the student exists
            Dim student = repository.Find(id)
            If Not IsNothing(student) Then
                repository.Delete(student)
            Else
                Throw New StudentException("student does not exist.")
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Returns a student information by Id
    ''' </summary>
    ''' <param name="id">student id</param>
    ''' <returns>student's information</returns>
    Public Function Find(id As Integer) As Student
        Dim student As Student

        Using repository As New StudentRepository()

            student = repository.Find(id)
        End Using
        Return student

    End Function

    ''' <summary>
    ''' Returns all students
    ''' </summary>
    ''' <returns>list of students</returns>
    Public Function FindAll() As IEnumerable
        Dim students As IEnumerable(Of Student)

        Using repository As New StudentRepository()

            students = repository.FindAll()
        End Using
        Return students
    End Function




End Class
