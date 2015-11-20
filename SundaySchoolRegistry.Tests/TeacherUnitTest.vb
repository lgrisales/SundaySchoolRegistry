Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SundaySchoolRegistry.Service
Imports SundaySchoolRegistry.Model

''' <summary>
''' Unit test for Teachers
''' </summary>
<TestClass()>
Public Class TeacherUnitTest

    ' static attribute use to keep the id between test executions
    Shared id As Integer


    ''' <summary>
    ''' Tests if a teacher can be created
    ''' </summary>
    <TestMethod()>
    Public Sub Test_001_CreateTeacher()
        Dim teacher As New Teacher()
        teacher.FirstName = "Lina"
        teacher.LastName = "Grisales"
        teacher.PhoneNumber = "613 998 9989"

        Dim service = New TeacherService()
        service.Create(teacher)
        id = teacher.Id
        Assert.AreNotEqual(teacher.Id, 0)
    End Sub

    ''' <summary>
    ''' Tests if a teacher can be updated
    ''' </summary>
    <TestMethod()>
    Public Sub Test_002_UpdateTeacher()
        Dim teacher As New Teacher()
        teacher.Id = id
        teacher.FirstName = "Lina Marcela"
        teacher.LastName = "Grisales"
        teacher.PhoneNumber = "613 998 9989"

        Dim service = New TeacherService()
        service.Update(teacher)
        teacher = service.Find(id)
        Assert.AreEqual(teacher.FirstName, "Lina Marcela")

    End Sub

    ''' <summary>
    ''' Test if a teacher can be deleted
    ''' </summary>
    <TestMethod()>
    Public Sub Test_003_DeleteTeacher()
        Dim service = New TeacherService()
        service.Delete(id)
    End Sub

    ''' <summary>
    ''' Tests a if test cannot be created if the information is invalid
    ''' </summary>
    <ExpectedException(GetType(System.Data.Entity.Validation.DbEntityValidationException))>
    <TestMethod()>
    Public Sub Test_004_CreateTeacherInvalidParameters()
        Dim teacher As New Teacher()
        teacher.FirstName = "Lina"
        teacher.LastName = "Grisales Grisales Grisales Grisales Grisales Grisales Grisales Grisales Grisales Grisales Grisales Grisales Grisales Grisales Grisales Grisales "
        teacher.PhoneNumber = "613 998 9989"

        Dim service = New TeacherService()
        service.Create(teacher)
        id = teacher.Id
        Assert.AreNotEqual(teacher.Id, 0)
    End Sub

    ''' <summary>
    ''' Tests if a teacher cannot be updated if does not exist
    ''' </summary>
    <ExpectedException(GetType(TeacherException))>
    <TestMethod()>
    Public Sub Test_005_UpdateTeacherNotExists()
        Dim teacher As New Teacher()
        teacher.Id = 88888
        teacher.FirstName = "Lina"
        teacher.LastName = "Grisales Grisales"
        teacher.PhoneNumber = "613 998 9989"

        Dim service = New TeacherService()
        service.Update(teacher)
    End Sub

    ''' <summary>
    ''' Tests if a teacher cannot be deleted if does not exist
    ''' </summary>
    <ExpectedException(GetType(TeacherException))>
    <TestMethod()>
    Public Sub Test_006_DeleteTeacherNotExists()
        Dim service = New TeacherService()
        service.Delete(100000)
    End Sub

    ''' <summary>
    ''' Tests if teachers in database has the first name
    ''' </summary>
    <TestMethod()>
    Public Sub Test_007_FindAllTeacher()
        Dim service = New TeacherService()
        Dim teachers As IEnumerable = service.FindAll()

        For Each teacher As Teacher In teachers
            Assert.IsNotNull(teacher.FirstName)
        Next
    End Sub

End Class