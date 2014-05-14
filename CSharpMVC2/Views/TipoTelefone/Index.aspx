<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<CSharpMVC2.Model.TipoTelefone>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= CSharpMVC2.Util.Constantes.APP_NAME %>  / Tipo de Telefone
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <h1>Tipo de Telefone</h1>
    <br />
    <% Html.RenderPartial(CSharpMVC2.Util.Constantes.PAGINA_MENSAGENS); %>
    <p>
        <%= Html.ActionLink("Novo", "Edit", "TipoTelefone", new { id = 0 },
            new {@class = "btn btn-info btn-lg pull-right"}) %>
    <% using (Html.BeginForm("Index", "TipoTelefone", FormMethod.Get)) { %>
    <div class="form-group inline">
        <label class="col-xs-1 control-label">Busca</label>
        <div class="col-xs-3">
            <%= Html.TextBox(CSharpMVC2.Util.Constantes.IX_FORM_TEXTO_BUSCA,"",
                    new { @class="form-control" }) %>
        </div>
        <label class="col-xs-2 control-label">Mostrar Inativos</label>
        <div class="col-xs-1" style="outline: none; border: none;">
            <%= Html.CheckBox(CSharpMVC2.Util.Constantes.IX_FORM_MOSTRAR_INATIVOS,
                    false, new { @class="checkbox", style = "width: 30px;"}) %>
        </div>
        <button type="submit" class="btn btn-primary btn-sm" value="Search">
            Buscar
        </button>
    </div>
    <% } %>
    </p>
    <hr />
    <table class="table table-striped table-responsive">
        <thead>
            <th>Editar</th>
            <th>Descrição</th>
            <th>Ativo</th>
            <th>Excluir</th>
        </thead>
        <tbody>
            <% foreach(var item in Model) { %>
            <tr>
                <td>
                    <button type="button" class="btn btn-default btn-md"
                            style="border: 0;">
                        <%= Html.ActionLink(" ", "Edit", "TipoTelefone",
                            new { id = item.Id },
                            new { @class="glyphicon glyphicon-edit",
                                  style = "color: black;" }) %>
                    </button>
                </td>
                <td><%= Html.Encode(item.Descricao) %></td>
                <td><%= Html.Encode(item.IsAtivo ? "Sim" : "Não") %></td>
                <td>
                    <% using(Html.BeginForm("Delete", "TipoTelefone",
                            new { id = item.Id }, FormMethod.Post, null)) { %>
                    <button type="submit" class="btn btn-default btn-md"
                            style="border: 0;">
                        <i class="glyphicon glyphicon-remove"></i>
                    </button>
                    <% } %>
                </td>
            </tr>
            <% } %>
        </tbody>
    </table>
    <br />
    <%= Html.ActionLink("Voltar", "Index", "Home", null,
            new {@class = "btn btn-default btn-lg pull-right"}) %>
</asp:Content>