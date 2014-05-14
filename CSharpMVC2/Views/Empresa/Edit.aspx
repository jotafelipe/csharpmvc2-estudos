<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<CSharpMVC2.Model.Empresa>" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/View/Empresa.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= CSharpMVC2.Util.Constantes.APP_NAME %>  / Empresa
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <h1>Empresa</h1>
    <h3 style="margin-left: 60px;"><%= Html.Encode(Model.Descricao) %></h3>
    <br />
    <% Html.RenderPartial(CSharpMVC2.Util.Constantes.PAGINA_MENSAGENS); %>
    <br />
    <% using(Html.BeginForm("Edit", "Empresa", FormMethod.Post,
            new { @class = "form-horizontal" })) { %>
    <%= Html.ValidationSummary(true) %>
    <div class="form-group">
        <%= Html.LabelFor(model => model.Descricao,
                new { @class="col-sm-1 control-label" }) %>
        <div class="col-sm-2 input-group">
            <%= Html.TextBoxFor(model => model.Descricao,
                    new { @class="form-control", id = "txtDescricao" } ) %>
            <span class="input-group-addon">
                <i id="msgDescricao" class="glyphicon glyphicon-remove"></i>
            </span>
        </div>
    </div>
    <div class="form-group">
        <%= Html.LabelFor(model => model.IsAtivo,
                new { @class="col-sm-1 control-label" }) %>
        <div class="col-sm-2">
            <%= Html.CheckBoxFor(model => model.IsAtivo,
                    new { @class="checkbox", style="width: 25px;" }) %>
        </div>
    </div>
    <br />
    <br />
    <button type="submit" class="btn btn-primary btn-lg" value="Save">
        Salvar
    </button>
    <% } %>
    <br />
    <div>
        <%= Html.ActionLink("Voltar", "Index", "Empresa", new { page = 0 },
                new { @class="btn btn-default pull-right" }) %>
    </div>
</asp:Content>