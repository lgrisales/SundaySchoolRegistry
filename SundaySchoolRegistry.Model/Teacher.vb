'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Teacher
    Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property PhoneNumber As String

    Public Overridable Property Courses As ICollection(Of Cours) = New HashSet(Of Cours)

End Class
