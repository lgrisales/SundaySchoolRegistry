@ModelType IEnumerable(Of SundaySchoolRegistry.Model.Student)
@Code
    ViewData("Title") = "Check-in"
End Code

<h2>Check-in</h2>


<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateBirth)
        </th>
        
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FirstName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LastName)
        </td>
         <td>
             @Html.DisplayFor(Function(modelItem) item.DateBirth)
         </td>
        <td>
            @Html.ActionLink("Check-in", "Checkin", New With {.StudentId = item.Id}) 
        </td>
    </tr>
Next

</table>
