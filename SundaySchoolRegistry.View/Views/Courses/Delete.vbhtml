@ModelType SundaySchoolRegistry.Model.Cours
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>Cours</h4>
    <hr />
    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
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

        <dt>
            @Html.DisplayNameFor(Function(model) model.Status)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Status)
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
