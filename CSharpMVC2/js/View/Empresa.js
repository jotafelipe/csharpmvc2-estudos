/*
*
*/
$(document).ready(function () {
    // Verifica Descrição
    $("#txtDescricao").change(function () {
        $.ajax({
            type: "GET",
            url: '/Empresa/VerificarDescricao',
            data: { descricao: $("#txtDescricao").val() },
            success: function (data) {
                var classe = (data.toLowerCase() == "true") ? "ok" : "remove";
                $("#msgDescricao").attr("class", "glyphicon glyphicon-" + classe);
            },
            async: true
        });
    });
});