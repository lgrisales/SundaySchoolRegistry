'File: StudentRepository.vb
'Author: Lina M.Grisales
'Date: 2015
'Description: Data Access Layer
Imports System.Data.Entity
Imports SundaySchoolRegistry.Model

Public Class StudentRepository
    Inherits BaseRepository

    ''' <summary>
    ''' Creates a Student
    ''' </summary>
    ''' <param name="student">student information</param>
    Public Sub Create(student As Student)
        DBContext.Students.Add(student)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Updates a student's information
    ''' </summary>
    ''' <param name="student">student information</param>
    Public Sub Update(student As Student)
        DBContext.Entry(student).State = EntityState.Modified
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Deletes a student
    ''' </summary>
    ''' <param name="student">student information</param>
    Public Sub Delete(student As Student)
        DBContext.Students.Remove(student)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' returns a the a student details
    ''' </summary>
    ''' <param name="id">student id</param>
    ''' <returns>student information</returns>
    Public Function Find(id As Integer) As Student

        Return DBContext.Students.Find(id)
    End Function

    ''' <summary>
    ''' Returns all students 
    ''' </summary>
    ''' <returns>list of students</returns>
    Public Function FindAll() As IEnumerable
        Return DBContext.Students.ToList()
    End Function

End Class
