<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= CSharpMVC2.Util.Constantes.APP_NAME %> / Home
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <h1>Home</h1>
    <br />
    <br />
    <%= Html.ActionLink("Empresa", "Index", "Empresa", null,
        new { @class = "col-lg-3 btn btn-primary btn-lg",
              style="color: #FFF; font-weight: bold; margin: 5px;"
    }) %>
    <%= Html.ActionLink("Tipo de Telefone", "Index", "TipoTelefone", null,
        new { @class = "col-lg-3 btn btn-primary btn-lg",
              style="color: #FFF; font-weight: bold; margin: 5px;"
    }) %>
    <%= Html.ActionLink("Pessoa", "Index", "Pessoa", null,
        new { @class = "col-lg-3 btn btn-primary btn-lg",
              style="color: #FFF; font-weight: bold; margin: 5px;"
    }) %>
</asp:Content>