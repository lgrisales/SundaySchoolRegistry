'File: StudentService.vb 
'Author: Lina M.Grisales
'Date: 2015
'Description:Class to manage the Student business logic

Imports SundaySchoolRegistry.Repository
Imports SundaySchoolRegistry.Model

Public Class StudentService

    ''' <summary>
    ''' Create a Student
    ''' </summary>
    ''' <param name="student">Student information</param>
    Public Sub Create(student As Student)

        Using repository As New StudentRepository

            repository.Create(student)
        End Using  'dispose the object

    End Sub

    ''' <summary>
    ''' Update a student's information
    ''' </summary>
    ''' <param name="student">student information</param>
    Public Sub Update(student As Student)
        Using repository As New StudentRepository()
            ' check if the student exists
            Dim existingStudent = Find(student.Id)
            If Not IsNothing(existingStudent) Then
                repository.Update(student)
            Else
                Throw New StudentException("student does not exist.")
            End If

        End Using
    End Sub

    ''' <summary>
    ''' Deletes a student
    ''' </summary>
    ''' <param name="id">student id</param>
    Public Sub Delete(id As Integer)
        Using repository As New StudentRepository()
            ' check if the student exists
            Dim student = repository.Find(id)
            If Not IsNothing(student) Then
                repository.Delete(student)
            Else
                Throw New StudentException("student does not exist.")
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Returns a student information by Id
    ''' </summary>
    ''' <param name="id">student id</param>
    ''' <returns>student's information</returns>
    Public Function Find(id As Integer) As Student
        Dim student As Student

        Using repository As New StudentRepository()

            student = repository.Find(id)
            ' this loop is to force entity framework to load the list of guardians
            ' and every guardian object from database
            For Each item As GuardianStudent In student.GuardianStudents
                Dim name = item.Guardian.FirstName
            Next
        End Using
        Return student

    End Function

    ''' <summary>
    ''' Returns all students
    ''' </summary>
    ''' <returns>list of students</returns>
    Public Function FindAll() As IEnumerable
        Dim students As IEnumerable(Of Student)

        Using repository As New StudentRepository()

            students = repository.FindAll()
        End Using
        Return students
    End Function

    ''' <summary>
    ''' Associates a guardian to a student
    ''' </summary>
    ''' <param name="guardianStudent">guardian information</param>
    Public Sub AddGuardian(guardianStudent As GuardianStudent)

        Using repository As New StudentRepository
            repository.AddGuardian(guardianStudent)
        End Using  'dispose the object

    End Sub

    ''' <summary>
    ''' Remove the relation between a guardian and an student
    ''' </summary>
    ''' <param name="guardianStudent">guardian student information</param>
    Public Sub RemoveGuardian(guardianStudent As GuardianStudent)

        Using repository As New StudentRepository
            repository.RemoveGuardian(guardianStudent)
        End Using  'dispose the object

    End Sub



    ''' <summary>
    ''' Checks in the student in a course
    ''' </summary>
    ''' <param name="studentId">student id</param>
    ''' <returns>true if the student is already checked in</returns>
    Public Function CheckInStudent(studentId As Integer) As Boolean
        Dim alreadyCheckedIn = True
        Using repository As New StudentRepository
            ' get the student information
            Dim student = repository.Find(studentId)
            ' check if the student is already checked in
            Dim todayCheckin = repository.GetCurrentCheckin(studentId)
            If IsNothing(todayCheckin) Then
                Dim courseAttendency = New CourseAttendency With {.StudentId = studentId, .CourseId = student.CourseId, .CheckinDate = DateTime.Now}
                repository.CheckInStudent(courseAttendency)
                alreadyCheckedIn = False
            End If

        End Using
        Return alreadyCheckedIn
    End Function

    ''' <summary>
    ''' Gets the current student check in
    ''' </summary>
    ''' <param name="studentId"></param>
    ''' <returns></returns>
    Public Function GetCurrentCheckin(studentId As Integer) As CourseAttendency
        Dim courseAttendency As CourseAttendency
        Using repository As New StudentRepository
            courseAttendency = repository.GetCurrentCheckin(studentId)
        End Using
        Return courseAttendency
    End Function

    ''' <summary>
    ''' Checks out the student from a course
    ''' </summary>
    ''' <param name="studentId">student id</param>
    ''' <returns>if the student was checked-in in a course</returns>
    Public Function CheckoutStudent(studentId As Integer) As Boolean
        Dim wasCheckedIn = False
        Using repository As New StudentRepository
            ' check if the student is already checked in
            Dim todayCheckin = repository.GetCurrentCheckin(studentId)
            If Not IsNothing(todayCheckin) Then
                todayCheckin.CheckoutDate = DateTime.Now
                repository.CheckOutStudent(todayCheckin)
                wasCheckedIn = True
            End If

        End Using
        Return wasCheckedIn
    End Function

End Class
