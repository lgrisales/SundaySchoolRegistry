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

Partial Public Class Cours
    Public Property Id As Integer

    Public Property Name As String
    Public Property Description As String
    <Required>
    <StringLength(50)>
    <DataType(DataType.Date)>
    Public Property StartHour As Date
    <Required>
    <DataType(DataType.Date)>
    <Display(Name:="End Hour")>
    Public Property EndHour As Date
    <Required>
    <StringLength(50)>
    <Display(Name:="Minimum Age")>
    Public Property MinimumAge As Integer
    <Required>
    <StringLength(50)>
    <Display(Name:="Maximum Age")>
    Public Property MaximumAge As Integer
    <Required>
    <StringLength(50)>
    <Display(Name:="Day Of Week")>
    Public Property DayOfWeek As String
    Public Property Status As Integer
    Public Property ClassroomId As Integer
    Public Property TeacherId As Integer

    Public Overridable Property ClassRoom As ClassRoom
    Public Overridable Property CourseAttendencies As ICollection(Of CourseAttendency) = New HashSet(Of CourseAttendency)
    Public Overridable Property Teacher As Teacher
    Public Overridable Property Students As ICollection(Of Student) = New HashSet(Of Student)

End Class
