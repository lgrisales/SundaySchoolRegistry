'File: ClassRoomService.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description:Class to manage the ClassRoom business logic

Imports SundaySchoolRegistry.Repository
Imports SundaySchoolRegistry.Model

Public Class ClassRoomService

    ''' <summary>
    ''' Create a ClassRoom
    ''' </summary>
    ''' <param name="classRoom">ClassRoom information</param>
    Public Sub Create(classRoom As ClassRoom)

        Using repository As New ClassRoomRepository()
            repository.Create(classRoom)
        End Using  'dispose the object

    End Sub

    ''' <summary>
    ''' Update a ClassRoom's information
    ''' </summary>
    ''' <param name="classRoom">ClassRoom information</param>
    Public Sub Update(classRoom As ClassRoom)
        Using repository As New ClassRoomRepository()
            ' check if the classRoom exists
            Dim existingClassRoom = Find(classRoom.Id)
            If Not IsNothing(existingClassRoom) Then
                repository.Update(classRoom)
            Else
                Throw New ClassRoomException("classRoom does not exist.")
            End If

        End Using
    End Sub

    ''' <summary>
    ''' Deletes a classRoom
    ''' </summary>
    ''' <param name="id">classRoom id</param>
    Public Sub Delete(id As Integer)
        Using repository As New ClassRoomRepository()
            ' check if the classRoom exists
            Dim classRoom = repository.Find(id)
            If Not IsNothing(classRoom) Then
                repository.Delete(classRoom)
            Else
                Throw New ClassRoomException("classRoom does not exist.")
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Returns a classRoom information by Id
    ''' </summary>
    ''' <param name="id">classRoom id</param>
    ''' <returns>classRoom's information</returns>
    Public Function Find(id As Integer) As ClassRoom
        Dim classRoom As ClassRoom

        Using repository As New ClassRoomRepository()

            classRoom = repository.Find(id)
        End Using
        Return classRoom

    End Function

    ''' <summary>
    ''' Returns all classRooms
    ''' </summary>
    ''' <returns>list of classRooms</returns>
    Public Function FindAll() As IEnumerable
        Dim classRooms As IEnumerable(Of ClassRoom)

        Using repository As New ClassRoomRepository()

            classRooms = repository.FindAll()
        End Using
        Return classRooms
    End Function




End Class
