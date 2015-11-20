@ModelType IEnumerable(Of SundaySchoolRegistry.Model.Cours)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StartHour)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EndHour)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MinimumAge)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.MaximumAge)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DayOfWeek)
        </th>
        
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StartHour)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EndHour)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MinimumAge)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.MaximumAge)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DayOfWeek)
        </td>
        
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
