function IngresoNumerosValor(e) {
    var Valor = document.activeElement.value;
    //var Valor = $("#Valor").val();
    var ValidaValor = Valor.split('.');
        var charCode;
        charCode = e.keyCode;
        status = charCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                if (charCode === 46) {
                    if (ValidaValor.length > 1) {
                        return false;
                    }
                    else return true;
                }
                else return false;
    }
    return true;
}

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function limitText(limitField, limitNum) {
    if (limitField.value.length > limitNum) {
        limitField.value = limitField.value.substring(0, limitNum);
    }
} 

var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,'
        , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><meta http-equiv="content-type" content="application/vnd.ms-excel; charset=UTF-8"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>'
        , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
        , format = function (s, c) { return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; }) }
    return function (table, name) {
        if (!table.nodeType) table = document.getElementById(table)
        var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }
        window.location.href = uri + base64(format(template, ctx))
    }
})();

function buscaEnTabla(tbDatos, myInput ) {
    var input, filter, table, tr, tds, td, i;
    var textfound = false;
    input =myinput;
    filter = input.value.toUpperCase();
    table =tbDatos;
    tds = table.rows[0].cells.length;
    tr = table.getElementsByTagName("tr");
    for (i = 1; i < tr.length; i++) {
        textfound = false;
        for (j = 1; j < tds - 1; j++) {
            td = tr[i].getElementsByTagName("td")[j];
            if (td) {
                if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                    textfound = true;
                    break;
                }
            }
        }
        if (textfound == true) {
            tr[i].style.display = "";
        } else {
            tr[i].style.display = "none";
        }
    }
}

$(".up,.down").click(function () {

    var $element = this;
    var row = $($element).parents("tr:first");

    if ($(this).is('.up')) {
        row.insertBefore(row.prev());
    }

    else {
        row.insertAfter(row.next());
    }

});

function Move(button) {
    var $element = button;
    var row = $($element).parents("tr:first");

    if ($(button).is('.up')) {
        row.insertBefore(row.prev());
    }

    else {
        row.insertAfter(row.next());
    }
}