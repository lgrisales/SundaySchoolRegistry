'File: TeacherRepository.vb
'Author: Lina M.Grisales
'Date: 2015
'Description: Data Access Layer
Imports System.Data.Entity
Imports SundaySchoolRegistry.Model

''' <summary>
''' Repository that handles the Teacher data access
''' </summary>
Public Class TeacherRepository
    Inherits BaseRepository

    ''' <summary>
    ''' Creates a teacher
    ''' </summary>
    ''' <param name="teacher">teacher information</param>
    Public Sub Create(teacher As Teacher)
        DBContext.Teachers.Add(teacher)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Updates a teacher's information
    ''' </summary>
    ''' <param name="teacher">teacher information</param>
    Public Sub Update(teacher As Teacher)
        DBContext.Entry(teacher).State = EntityState.Modified
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Deletes a teacher
    ''' </summary>
    ''' <param name="teacher">teacher information</param>
    Public Sub Delete(teacher As Teacher)
        DBContext.Teachers.Remove(teacher)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' returns a the a teacher details
    ''' </summary>
    ''' <param name="id">teacher id</param>
    ''' <returns>teacher information</returns>
    Public Function Find(id As Integer) As Teacher
        Return DBContext.Teachers.Find(id)
    End Function

    ''' <summary>
    ''' Returns all teachers 
    ''' </summary>
    ''' <returns>list of teachers</returns>
    Public Function FindAll() As IEnumerable
        Return DBContext.Teachers.ToList()
    End Function


End Class



