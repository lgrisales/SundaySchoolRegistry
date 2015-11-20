'File: GuardiansServices.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description:Class to manage the Guardians business logic
Imports SundaySchoolRegistry.Repository
Imports SundaySchoolRegistry.Model
Public Class GuardianService
    ''' <summary>
    ''' Create a Guardian
    ''' </summary>
    ''' <param name="guardian">Guardian information</param>
    Public Sub Create(guardian As Guardian)

        Using repository As New GuardianRepository()
            repository.Create(guardian)
        End Using  'dispose the object

    End Sub

    ''' <summary>
    ''' Update a Guardian's information
    ''' </summary>
    ''' <param name="guardian">Guardian information</param>
    Public Sub Update(guardian As Guardian)
        Using repository As New GuardianRepository()
            ' check if the Guardian exists
            Dim existingGuardian = Find(guardian.Id)
            If Not IsNothing(existingGuardian) Then
                repository.Update(guardian)
            Else
                Throw New GuardianException("Guardian does not exist.")
            End If

        End Using
    End Sub

    ''' <summary>
    ''' Deletes a Guardian
    ''' </summary>
    ''' <param name="id">Guardian id</param>
    Public Sub Delete(id As Integer)
        Using repository As New GuardianRepository()
            ' check if the Guardian exists
            Dim guardian = repository.Find(id)
            If Not IsNothing(guardian) Then
                repository.Delete(guardian)
            Else
                Throw New GuardianException("Guardian does not exist.")
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Returns a Guardian information by Id
    ''' </summary>
    ''' <param name="id">Guardian id</param>
    ''' <returns>Guardian's information</returns>
    Public Function Find(id As Integer) As Guardian
        Dim guardian As Guardian

        Using repository As New GuardianRepository()

            guardian = repository.Find(id)
        End Using
        Return guardian

    End Function

    ''' <summary>
    ''' Returns all Guardians
    ''' </summary>
    ''' <returns>list of Guardians</returns>
    Public Function FindAll() As IEnumerable
        Dim guardians As IEnumerable(Of Guardian)

        Using repository As New GuardianRepository()

            guardians = repository.FindAll()
        End Using
        Return guardians
    End Function

End Class
