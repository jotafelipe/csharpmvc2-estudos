/*
*
*/
$(document).ready(function () {
    $("#addTelefone").click(function () {
        $.ajax({
            url: "/Pessoa/AddTelefone",
            success: function (data) {
                $(".pessoaTelefones").append(data);
            }
        });
    });
    // Verifica CPF
    $("#txtCpf").change(function () {
        $.ajax({
            type: "GET",
            url: '/Pessoa/VerificarCpf',
            data: { cpf: $("#txtCpf").val() },
            success: function (data) {
                var classe = (data.toLowerCase() == "true") ? "ok" : "remove";
                $("#msgCpf").attr("class", "glyphicon glyphicon-" + classe);
            },
            async: true
        });
    });

    // Verifica Email
    $("#txtEmail").change(function () {
        $.ajax({
            type: "GET",
            url: '/Pessoa/VerificarEmail',
            data: { email: $("#txtEmail").val() },
            success: function (data) {
                var classe = (data.toLowerCase() == "true") ? "ok" : "remove";
                $("#msgEmail").attr("class", "glyphicon glyphicon-" + classe);
            },
            async: true
        });
    });
});