'File: StudentRepository.vb
'Author: Lina M.Grisales
'Date: 2015
'Description: Data Access Layer
Imports System.Data.Entity
Imports SundaySchoolRegistry.Model

Public Class StudentRepository
    Inherits BaseRepository

    ''' <summary>
    ''' Creates a Student
    ''' </summary>
    ''' <param name="student">student information</param>
    Public Sub Create(student As Student)
        DBContext.Students.Add(student)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Updates a student's information
    ''' </summary>
    ''' <param name="student">student information</param>
    Public Sub Update(student As Student)
        DBContext.Entry(student).State = EntityState.Modified
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Deletes a student
    ''' </summary>
    ''' <param name="student">student information</param>
    Public Sub Delete(student As Student)
        DBContext.Students.Remove(student)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' returns a the a student details
    ''' </summary>
    ''' <param name="id">student id</param>
    ''' <returns>student information</returns>
    Public Function Find(id As Integer) As Student

        Return DBContext.Students.Find(id)
    End Function

    ''' <summary>
    ''' Returns all students 
    ''' </summary>
    ''' <returns>list of students</returns>
    Public Function FindAll() As IEnumerable
        Return DBContext.Students.ToList()
    End Function

    ''' <summary>
    ''' Associates a guardian to a student
    ''' </summary>
    ''' <param name="guardianStudent">guardian information</param>
    Public Sub AddGuardian(guardianStudent As GuardianStudent)
        DBContext.GuardianStudents.Add(guardianStudent)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Remove the relation between a guardian and an student
    ''' </summary>
    ''' <param name="guardianStudent">guardian student information</param>
    Public Sub RemoveGuardian(guardianStudent As GuardianStudent)
        guardianStudent = DBContext.GuardianStudents.Find(guardianStudent.GuardianId, guardianStudent.StudentId)
        DBContext.GuardianStudents.Remove(guardianStudent)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Returns the today's student checkin
    ''' </summary>
    ''' <param name="studentId"></param>
    ''' <returns></returns>
    Public Function GetCurrentCheckin(studentId As Integer) As CourseAttendency
        Dim current = From c In DBContext.CourseAttendencies Where DbFunctions.TruncateTime(c.CheckinDate) = DbFunctions.TruncateTime(DateTime.Now) And c.CheckoutDate Is Nothing
        Return current.SingleOrDefault()
    End Function

    ''' <summary>
    ''' Checks in the student in a course
    ''' </summary>
    ''' <param name="courseAttendency">checkin information</param>
    Public Sub CheckInStudent(courseAttendency As CourseAttendency)
        DBContext.CourseAttendencies.Add(courseAttendency)
        DBContext.SaveChanges()
    End Sub

    ''' <summary>
    ''' Checks out the student from a course
    ''' </summary>
    ''' <param name="courseAttendency">checkout information</param>
    Public Sub CheckOutStudent(courseAttendency As CourseAttendency)
        DBContext.Entry(courseAttendency).State = EntityState.Modified
        DBContext.SaveChanges()
    End Sub
End Class
