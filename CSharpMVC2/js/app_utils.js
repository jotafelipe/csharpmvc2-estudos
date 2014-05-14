function mascara(element, mask) {
    var i = element.value.length;
    var saida = mask.substring(0, 1);
    var texto = mask.substring(i)
    if (texto.substring(0, 1) != saida) {
        element.value += texto.substring(0, 1);
    }
}

function somenteNumeros(e, element, mask) {
    if ((e.keyCode > 47 && e.keyCode < 58)) { // numeros de 0 a 9
        mascara(element, mask);
        return true;
    }
    else {
        if (e.keyCode == 8) { // backspace
            return true;
        } else {
            //event.keyCode = 0;
            return false;
        }
    }
}

var carregarListaGruposLdapCargo = function () {
    var selectedValue = $("#cbUnidadeOrganizacional").val();
    var lb = $("#lbGrupos");
    $.getJSON('/Cargo/PopulaComboGruposLdap/', "idObjetoLdapPai=" + selectedValue)
    .done(function (data) {
        lb.empty();
        $(data).each(function () {
            $(document.createElement('option'))
            .attr('value', this.Id)
            .text(this.Text)
            .appendTo(lb);
        });
    })
    .fail(function () {
        lb.empty();
    });
};