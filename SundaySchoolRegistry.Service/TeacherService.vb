'File: TeacherService.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description:Class to manage the teacher business logic

Imports SundaySchoolRegistry.Repository
Imports SundaySchoolRegistry.Model


Public Class TeacherService


    ''' <summary>
    ''' Create a treacher
    ''' </summary>
    ''' <param name="teacher">teacher information</param>
    Public Sub Create(teacher As Teacher)

        Using repository As New TeacherRepository()
            repository.Create(teacher)
        End Using  'dispose the object

    End Sub

    ''' <summary>
    ''' Update a teacher's information
    ''' </summary>
    ''' <param name="teacher">teacher information</param>
    Public Sub Update(teacher As Teacher)
        Using repository As New TeacherRepository()
            ' check if the teacher exists
            Dim existingTeacher = Find(teacher.Id)
            If Not IsNothing(existingTeacher) Then
                repository.Update(teacher)
            Else
                Throw New TeacherException("Teacher does not exist.")
            End If

        End Using
    End Sub

    ''' <summary>
    ''' Deletes a teacher
    ''' </summary>
    ''' <param name="id">teacher id</param>
    Public Sub Delete(id As Integer)
        Using repository As New TeacherRepository()
            ' check if the teacher exists
            Dim teacher = repository.Find(id)
            If Not IsNothing(teacher) Then
                repository.Delete(teacher)
            Else
                Throw New TeacherException("Teacher does not exist.")
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Returns a teacher information by Id
    ''' </summary>
    ''' <param name="id">teacher id</param>
    ''' <returns>Teacher's information</returns>
    Public Function Find(id As Integer) As Teacher
        Dim teacher As Teacher
        Using repository As New TeacherRepository()
            teacher = repository.Find(id)
        End Using
        Return teacher
    End Function

    ''' <summary>
    ''' Returns all teachers
    ''' </summary>
    ''' <returns>list of teachers</returns>
    Public Function FindAll() As IEnumerable
        Dim teachers As IEnumerable(Of Teacher)
        Using repository As New TeacherRepository()
            teachers = repository.FindAll()
        End Using
        Return teachers
    End Function

End Class



