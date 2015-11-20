'File: ClassRoomException.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description:Class to manage exceptions
Public Class ClassRoomException
    Inherits Exception


    Public Sub New() 'Default constructor
    End Sub

    Public Sub New(message As String)
        MyBase.New(message) 'call parent constructor
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New(message, inner)
    End Sub


End Class
