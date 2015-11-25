@ModelType SundaySchoolRegistry.Model.Student
@Code
    ViewData("Title") = "Check in Summary"
End Code

<h2>Check-in Summary</h2>

<div>

@Html.ValidationSummary(True, "", New With {.class = "text-danger"})

@If Not IsNothing(ViewBag.IsCheckedIn) Then


    @<h4>The following student has been checked in successfuly</h4>
    @<hr />
    @<dl Class="dl-horizontal">
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

End If
</div>

<p>
    <a class="btn btn-default" target="_blank" href="/CheckInout/Print/@Model.Id">Print</a>

    @Html.ActionLink("Back", "Checkin")
</p>
