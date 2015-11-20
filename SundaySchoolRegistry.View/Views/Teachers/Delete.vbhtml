﻿@ModelType SundaySchoolRegistry.Model.Teacher
@Code
    ViewData("Title") = "Delete Teacher"
End Code

<h2>Delete Teacher</h2>

<h3>Are you sure you want to delete this?</h3>
<div>

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
            @Html.DisplayNameFor(Function(model) model.PhoneNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PhoneNumber)
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
