<%@ page title="" language="C#" masterpagefile="~/Views/Shared/Site.Master" inherits="System.Web.Mvc.ViewPage<CSharpMVC2.Model.Pessoa>" %>

<asp:content id="Content3" contentplaceholderid="head" runat="server">
    <script src="../../js/View/Pessoa.js" type="text/javascript"></script>
</asp:content>
<asp:content id="Content1" contentplaceholderid="TitleContent" runat="server">
    <%= CSharpMVC2.Util.Constantes.APP_NAME %>
    / Pessoa
</asp:content>
<asp:content id="Content2" contentplaceholderid="MainContent" runat="server">
    <br />
    <br />
    <h1>
        Pessoa</h1>
    <h3 style="margin-left: 60px;">
        <%= Html.Encode(Model.T_NomeCompleto) %></h3>
    <br />
    <% Html.RenderPartial(CSharpMVC2.Util.Constantes.PAGINA_MENSAGENS); %>
    <br />
    <ul class="nav nav-tabs">
        <li class="active">
            <a href="#pessoa" data-toggle="tab">
                Pessoa</a></li>
        <li>
            <a href="#telefones" data-toggle="tab">
                Telefones</a></li>
    </ul>
    <div class="tab-content">
        <br />
        <% using(Html.BeginForm("Edit", "Pessoa", FormMethod.Post,
                new {
                    @class = "form-horizontal", id = "FormPessoa"
                })) { %>
        <%= Html.ValidationSummary(true) %>
        <div id="pessoa" class="tab-pane active">
            <div class="form-group inline">
                <%= Html.LabelFor(model => model.Cpf,
                new { @class="col-sm-1 control-label" }) %>
                <div class="col-sm-2 input-group">
                    <%= Html.TextBoxFor(model => model.Cpf,
                    new { @class="form-control", id = "txtCpf",
                          onkeypress = "return somenteNumeros(event, this, '###.###.###-##');",
                          maxlength = "14"})%>
                    <span class="input-group-addon">
                        <i id="msgCpf" class="glyphicon glyphicon-remove">
                        </i>
                    </span>
                </div>
            </div>
            <div class="form-group">
                <%= Html.LabelFor(model => model.Nome,
                new { @class="col-sm-1 control-label" }) %>
                <div class="col-sm-2">
                    <%= Html.TextBoxFor(model => model.Nome,
                    new { @class="form-control" }) %>
                </div>
            </div>
            <div class="form-group">
                <%= Html.LabelFor(model => model.Sobrenome,
                new { @class="col-sm-1 control-label" }) %>
                <div class="col-sm-2">
                    <%= Html.TextBoxFor(model => model.Sobrenome,
                    new { @class="form-control" }) %>
                </div>
            </div>
            <div class="form-group">
                <%= Html.LabelFor(model => model.DataNascimento,
                new { @class="col-sm-1 control-label" }) %>
                <div class="col-sm-2">
                    <%= Html.TextBoxFor(model => model.DataNascimento,
                    new { @class="form-control" }) %>
                </div>
            </div>
            <div class="form-group">
                <%= Html.LabelFor(model => model.Email,
                    new { @class="col-sm-1 control-label" }) %>
                <div class="col-sm-2 input-group">
                    <%= Html.TextBoxFor(model => model.Email,
                        new { @class="form-control", id = "txtEmail"}) %>
                    <span class="input-group-addon">
                        <i id="msgEmail" class="glyphicon glyphicon-remove">
                        </i>
                    </span>
                </div>
            </div>
            <div class="form-group">
                <%= Html.LabelFor(model => model.Cep,
                new { @class="col-sm-1 control-label" }) %>
                <div class="col-sm-2">
                    <%= Html.TextBoxFor(model => model.Cep,
                    new { @class="form-control" }) %>
                </div>
            </div>
            <div class="form-group">
                <%= Html.LabelFor(model => model.Empresa,
                new { @class="col-sm-1 control-label" }) %>
                <div class="col-sm-2">
                    <%= Html.DropDownListFor(model => model.Empresa.Id,
                    CSharpMVC2.Controllers.PessoaController.Empresas,
                    new { @class="form-control" }) %>
                </div>
            </div>
            <div class="form-group">
                <%= Html.LabelFor(model => model.Salario,
                new { @class="col-sm-1 control-label" }) %>
                <div class="col-sm-2">
                    <%= Html.TextBoxFor(model => model.Salario,
                    new { @class="form-control" }) %>
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
        </div>
        <div id="telefones" class="tab-pane">
            <button id="addTelefone" type="button" class="btn btn-info btn-lg">
                +
            </button>
            <div class="pessoaTelefones">
            <% if(Model.Telefones != null) {
                foreach(CSharpMVC2.Model.Telefone t in Model.Telefones) { 
                    Response.Write(Html.EditorFor(model => t, "Telefones"));
                }
            } %>
            </div>
        </div>
        <br />
        <br />
        <button type="submit" class="btn btn-primary btn-lg" value="Save">
            Salvar
        </button>
        <% } %>
    </div>
    <br />
    <div>
        <%= Html.ActionLink("Voltar", "Index", "Pessoa", new { page = 0 },
                new { @class="btn btn-default pull-right" }) %>
    </div>
</asp:content>
