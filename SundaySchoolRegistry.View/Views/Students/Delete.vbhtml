@ModelType SundaySchoolRegistry.Model.Student
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Student</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
