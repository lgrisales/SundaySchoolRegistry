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
Imports System.ComponentModel.DataAnnotations

Partial Public Class Teacher
    Public Property Id As Integer
    <Required>
    <StringLength(50)>
    <Display(Name:="First Name")>
    Public Property FirstName As String
    <Required>
    <StringLength(50)>
    <Display(Name:="Last Name")>
    Public Property LastName As String
    <StringLength(20)>
    <Display(Name:="Phone Number")>
    Public Property PhoneNumber As String
    Public Overridable Property Courses As ICollection(Of Cours) = New HashSet(Of Cours)

End Class
