<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% if(ViewData[CSharpMVC2.Util.Constantes.VD_MSG_SUCESSO] != null) { %>
    <div class="alert alert-success" style="font-size: 12pt;">
        <%= ViewData[CSharpMVC2.Util.Constantes.VD_MSG_SUCESSO]%>
    </div>
<% } %>
<% if (ViewData[CSharpMVC2.Util.Constantes.VD_MSG_ERRO] != null) { %>
    <div class="alert alert-danger" style="font-size: 12pt;">
        <%= ViewData[CSharpMVC2.Util.Constantes.VD_MSG_ERRO]%>
    </div>
<% } %>