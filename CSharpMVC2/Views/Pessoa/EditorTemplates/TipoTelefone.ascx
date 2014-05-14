<%@ Control Language="C#"
    Inherits="System.Web.Mvc.ViewUserControl<CSharpMVC2.Model.Telefone>" %>
<label class="col-sm-1 control-label">Tipo:</label>
<div class="col-sm-2">
    <%= Html.DropDownListFor(model => model.TipoTelefone.Id,
            CSharpMVC2.Controllers.PessoaController.TipoTelefones,
            new { @class = "form-control" }) %>
</div>