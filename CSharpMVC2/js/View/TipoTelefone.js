/*
*
*/
$(document).ready(function () {
    $("#txtDescricao").change(function () {
        // Verifica Descrição
        $.ajax({
            type: "GET",
            url: '/TipoTelefone/VerificarDescricao',
            data: { descricao: $("#txtDescricao").val() },
            success: function (data) {
                var classe = (data.toLowerCase() == "true") ? "ok" : "remove";
                $("#msgDescricao").attr("class", "glyphicon glyphicon-" + classe);
            },
            async: true
        });
    });
});