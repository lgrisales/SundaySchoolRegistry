@ModelType SundaySchoolRegistry.Model.GuardianStudent
@Code
    ViewData("Title") = "Add Guardian"
End Code

<h2>Add Guardian to Student</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()

    @Html.HiddenFor(Function(model) model.StudentId)

    @<div class="form-horizontal">
        <h4>Student: @Html.DisplayFor(Function(model) model.Student.FirstName) @Html.DisplayFor(Function(model) model.Student.LastName)</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(Function(model) model.GuardianId, "GuardianId", htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.DropDownList("GuardianId", CType(ViewBag.Guardians, SelectList), htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.GuardianId, "", New With { .class = "text-danger" })
            </div>
        </div>


        <div class="form-group">
            @Html.LabelFor(Function(model) model.GuardianTypeId, "GuardianTypeId", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownList("GuardianTypeId", CType(ViewBag.GuardianTypes, SelectList), htmlAttributes:=New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.GuardianTypeId, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
