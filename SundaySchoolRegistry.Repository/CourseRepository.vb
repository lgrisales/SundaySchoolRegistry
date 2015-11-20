'File: CourseRepository.vb
'Author: Lina M.Grisales
'Date: Nov 2015
'Description: Data Access Layer
Imports System.Data.Entity
Imports SundaySchoolRegistry.Model
Public Class CourseRepository
    Inherits BaseRepository

    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="course">Course information</param>
    Public Sub Create(course As Cours)
        DBContext.Courses.Add(course)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Updates a course's information
    ''' </summary>
    ''' <param name="course">course information</param>
    Public Sub Update(course As Cours)
        DBContext.Entry(course).State = EntityState.Modified
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Deletes a course
    ''' </summary>
    ''' <param name="course">course information</param>
    Public Sub Delete(course As Cours)
        DBContext.Courses.Remove(course)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' returns a the a Cours details
    ''' </summary>
    ''' <param name="id">Cours id</param>
    ''' <returns>Cours information</returns>
    Public Function Find(id As Integer) As Cours


        Return DBContext.Courses.Find(id)
    End Function

    ''' <summary>
    ''' Returns all Courses 
    ''' </summary>
    ''' <returns>list of Courses</returns>
    Public Function FindAll() As IEnumerable
        Return DBContext.Courses.ToList()
    End Function

End Class
