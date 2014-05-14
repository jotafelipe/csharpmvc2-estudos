<%@ control language="C#"
    inherits="System.Web.Mvc.ViewUserControl<CSharpMVC2.Model.Telefone>" %>
<%@ import namespace="CSharpMVC2.Helpers" %>
<div class="form-group inline">
    <% using(Html.BeginAjaxContentValidation("FormPessoa")) {
           using(Html.BeginCollectionItem("Telefones")) { %>
    <div class="form-group inline">
        <%= Html.Partial("EditorTemplates/TipoTelefone", Model) %>
        <%= Html.LabelFor(model => model.Ddd,
                new { @class="col-sm-1 control-label" }) %>
        <div class="col-sm-1">
            <%= Html.TextBoxFor(model => model.Ddd,
                    new { @class = "form-control" }) %>
        </div>
        <%= Html.LabelFor(model => model.Fone,
                new { @class = "col-sm-1 control-label"}) %>
        <div class="col-sm-2">
            <%= Html.TextBoxFor(model => model.Fone,
                    new { @class = "form-control"}) %>
        </div>
    </div>
    <% } %>
    <% } %>
</div>
