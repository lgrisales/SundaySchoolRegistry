'File: GuardianRepository.vb
'Author: Lina M.Grisales
'Date: 2015
'Description: Data Access Layer
Imports System.Data.Entity
Imports SundaySchoolRegistry.Model
Public Class GuardianRepository
    Inherits BaseRepository

    ''' <summary>
    ''' Creates a Guardian
    ''' </summary>
    ''' <param name="guardian">Guardian information</param>
    Public Sub Create(guardian As Guardian)
        DBContext.Guardians.Add(guardian)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Updates a guardian's information
    ''' </summary>
    ''' <param name="guardian">guardian information</param>
    Public Sub Update(guardian As Guardian)
        DBContext.Entry(guardian).State = EntityState.Modified
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Deletes a guardian
    ''' </summary>
    ''' <param name="guardian">guardian information</param>
    Public Sub Delete(guardian As Guardian)
        DBContext.Guardians.Remove(guardian)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' returns a the a guardian details
    ''' </summary>
    ''' <param name="id">guardian id</param>
    ''' <returns>guardian information</returns>
    Public Function Find(id As Integer) As Guardian

        Return DBContext.Guardians.Find(id)
    End Function

    ''' <summary>
    ''' Returns all guardians 
    ''' </summary>
    ''' <returns>list of guardians</returns>
    Public Function FindAll() As IEnumerable
        Return DBContext.Guardians.ToList()
    End Function

End Class
