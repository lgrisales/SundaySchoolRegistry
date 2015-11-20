'File: ClassRoomRepository.vb
'Author: Lina M.Grisales
'Date: 2015
'Description: Data Access Layer
Imports System.Data.Entity
Imports SundaySchoolRegistry.Model
Public Class ClassRoomRepository
    Inherits BaseRepository

    ''' <summary>
    ''' Creates a Classroom
    ''' </summary>
    ''' <param name="classroom">Classroom information</param>
    Public Sub Create(classroom As ClassRoom)
        DBContext.ClassRooms.Add(classroom)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Updates a Classroom's information
    ''' </summary>
    ''' <param name="classroom">Classroom information</param>
    Public Sub Update(classroom As ClassRoom)
        DBContext.Entry(classroom).State = EntityState.Modified
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Deletes a Classroom
    ''' </summary>
    ''' <param name="classroom">Classroom information</param>
    Public Sub Delete(classroom As ClassRoom)
        DBContext.ClassRooms.Remove(classroom)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' returns a the a Classroom details
    ''' </summary>
    ''' <param name="id">Classroom id</param>
    ''' <returns>Classroom information</returns>
    Public Function Find(id As Integer) As ClassRoom

        Return DBContext.ClassRooms.Find(id)
    End Function

    ''' <summary>
    ''' Returns all Classroom 
    ''' </summary>
    ''' <returns>list of Classroom</returns>
    Public Function FindAll() As IEnumerable
        Return DBContext.ClassRooms.ToList()
    End Function

End Class
