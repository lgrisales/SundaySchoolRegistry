@ModelType SundaySchoolRegistry.Model.Student
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Student</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.FirstName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LastName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LastName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Address)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Address)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.City)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.City)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DateBirth)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DateBirth)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Allergies)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Allergies)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SpecialInstructions)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SpecialInstructions)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
