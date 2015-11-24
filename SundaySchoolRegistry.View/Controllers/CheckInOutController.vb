'File: CheckInOutController.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description: Presentation Layer.Controller that 
'manages check-ins and check-outs
Imports System.Web.Mvc
Imports SundaySchoolRegistry.Model
Imports SundaySchoolRegistry.Service

Namespace Controllers
    Public Class CheckInOutController
        Inherits Controller

        ''' <summary>
        ''' Students business logic attribute
        ''' </summary>
        Private studentService As New StudentService()

        ''' <summary>
        ''' Loads the page to start the check in process
        ''' </summary>
        ''' <returns>page to check in students</returns>
        Function CheckIn() As ActionResult
            Dim students As IEnumerable = studentService.FindAll()
            Return View(students)
        End Function

        Function CheckInSummary(ByVal StudentId As Integer?) As ActionResult
            Dim students As IEnumerable = studentService.FindAll()
            Return View(students)
        End Function
    End Class
End Namespace