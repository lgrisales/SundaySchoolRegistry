@Code
    Layout = ""
End Code

@ModelType SundaySchoolRegistry.Model.Student
@Code
    ViewData("Title") = "Student Label"
End Code



@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

<div>
@If Not IsNothing(Model) Then
@<table>
    <tr>
        <td colspan = "2" >@Html.DisplayFor(Function(model) model.FirstName) @Html.DisplayNameFor(Function(model) model.LastName)</td>
    </tr>
    <tr >
        <td><b>Allergies: </b> </td>
        <td>@Html.DisplayFor(Function(model) model.Allergies)</td>
    </tr>
    <tr>
        <td><b>Special Instructions: </b> </td>
        <td>@Html.DisplayFor(Function(model) model.SpecialInstructions)</td>
    </tr>
    <tr>
        <td colspan="2">@DateTime.Now </td>
    </tr>
</table>
@<a Class="btn btn-default"  href="javascript:print()">Print</a>
End If  

</div>
