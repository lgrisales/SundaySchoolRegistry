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
        ''' <summary>
        ''' Checks in a student
        ''' </summary>
        ''' <param name="id">student id</param>
        ''' <returns>page to be redirected</returns>
        Function CheckInSummary(ByVal id As Integer?) As ActionResult
            Dim isCheckedIn = studentService.CheckInStudent(id)
            ViewBag.IsCheckedIn = isCheckedIn
            Dim student = studentService.Find(id)

            If (isCheckedIn) Then
                ModelState.AddModelError("", "The Student is already checked in")
            End If

            Return View(student)
        End Function

        ''' <summary>
        ''' Checks in a student
        ''' </summary>
        ''' <param name="id">student id</param>
        ''' <returns>page to be redirected</returns>
        Function Print(ByVal id As Integer?) As ActionResult

            Dim isCheckedIn = studentService.CheckInStudent(id)
            ' Check if the student has been already checked in 
            If (Not isCheckedIn) Then
                ModelState.AddModelError("", "The Student is not checked in")
                Return View()
            End If
            ' get the student info
            Dim student = studentService.Find(id)
            Return View(student)
        End Function

        ''' <summary>
        ''' Loads the page to start the checkout process
        ''' </summary>
        ''' <returns>page to check out students</returns>
        Function Checkout() As ActionResult
            Dim students As IEnumerable = studentService.FindAll()
            Return View(students)
        End Function

        ''' <summary>
        ''' Checks in a student
        ''' </summary>
        ''' <param name="id">student id</param>
        ''' <returns>page to be redirected</returns>
        Function CheckoutStudent(ByVal id As Integer) As ActionResult
            Dim wasCheckedIn = studentService.CheckoutStudent(id)


            If (Not wasCheckedIn) Then
                ModelState.AddModelError("", "The Student is not checked in")
            Else
                ViewBag.Message = "The student has been checked out"
            End If

            ' show all students again
            Dim students As IEnumerable = studentService.FindAll()
            Return View("checkout", students)
        End Function
    End Class
End Namespace