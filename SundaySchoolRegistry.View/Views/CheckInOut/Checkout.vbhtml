@ModelType IEnumerable(Of SundaySchoolRegistry.Model.Student)
@Code
    ViewData("Title") = "Checkout"
End Code

<h2>Checkout</h2>
@Html.ValidationSummary(True, "", New With {.class = "text-danger"})
<h4>@Html.Raw(ViewBag.Message)</h4>
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
            @Html.ActionLink("Checkout", "CheckoutStudent", New With {.id = item.Id})
        </td>
    </tr>
    Next

</table>
