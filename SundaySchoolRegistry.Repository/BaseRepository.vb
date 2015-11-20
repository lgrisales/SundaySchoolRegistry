'File: BaseRepository.vb
'Author: Lina M.Grisales
'Date: 2015
'Description: Data Access Layer
Imports SundaySchoolRegistry.Model


''' <summary>
''' Base repository that implements basic logic to all
''' repositories
''' </summary>
Public Class BaseRepository
        Implements IDisposable


        ''' <summary>
        ''' Property to access the database using Entity framework
        ''' </summary>
        Public Property DBContext As SundaySchoolRegistryContext

    ' Default constructor
        Sub New()
            'Instantiate db context
            DBContext = New SundaySchoolRegistryContext()
        End Sub

    ' Close connection to Database
    Public Sub Dispose() Implements IDisposable.Dispose 'override method from Idisposable
        DBContext.Dispose() ' close connection to db
    End Sub


End Class

