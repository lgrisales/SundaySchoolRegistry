@ModelType SundaySchoolRegistry.Model.Cours
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Course</h4>
    <hr />
    <dl class="dl-horizontal">
        

       
        <dt>
            @Html.DisplayNameFor(Function(model) model.Name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StartHour)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StartHour)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.EndHour)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EndHour)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MinimumAge)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MinimumAge)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.MaximumAge)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.MaximumAge)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DayOfWeek)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DayOfWeek)
        </dd>

        

        

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>

<h2>Students</h2>
<table class="table">
    <tr>
        <th>
            First Name
        </th>
        <th>
            Last Name
        </th>

    </tr>

    @For Each item In Model.Students
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.FirstName)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LastName)
            </td>

        </tr>
    Next

</table>

