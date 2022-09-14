"use strict"
var page = '';
var TableBackgroundNormalColor = "#ffffff";
var TableBackgroundMouseoverColor = "#99ffbd";

$(document).ready(function () {
    var path = window.location.pathname;
    page = path.split("/").pop();
    $('#divMensaje').delay(5000).fadeOut();

    $('#FechaGeneracion').datepicker({
        format: 'dd/mm/yyyy'

    });
    $('#FechaFin').datepicker({

        format: 'dd/mm/yyyy'

    });

    ObtenerResumen();
    if (page != "Create") {
        //cargar los totales de la asistencia
        document.getElementById("FechaGeneracionV").disabled = true;
        document.getElementById("idGrupoOperacionV").disabled = true;
        document.getElementById("idCierrePeriodicoV").disabled = true;
    }

});

$("#tblDetlValores").on("click", "#btnAddCampo", function () {
    var varvalor = $("#valorf");
    var varobs = $("#Observacion");
    var varempid = $("#cmbempleado");
    var varfunid = $("#cmbfuncionlaboral");
    var varemp = $("#cmbempleado option:selected");


    var tBody = $("#tblDetlValores > TBODY")[0];
    var row = tBody.insertRow(-1);

    cell = $(row.insertCell(-1));


    cell = $(row.insertCell(-1));


    var cell = $(row.insertCell(-1));
    var cmbempleadot = $("<select></select>");
    var optioncmbempleado = $("<option/>");
    cmbempleadot.attr("style", " width:300px;height:30px");
    cmbempleadot.attr("class", "form-control input-sm");
    cell.append(cmbempleadot.append(optioncmbempleado.val(varempid.val()).text(varemp.text())));



    var cell = $(row.insertCell(-1));
    var txtvalor = $("<input />");
    txtvalor.attr("type", "text");
    txtvalor.attr("style", " width:100px;height:35px");
    txtvalor.attr("class", "form-control input-sm text-center");
    txtvalor.val(varvalor.val());
    cell.append(txtvalor);

    var cell = $(row.insertCell(-1));
    var txttextoobservac = $("<input />");
    txttextoobservac.attr("type", "text");
    txttextoobservac.attr("style", " width:300px;height:35px");
    txttextoobservac.attr("class", "form-control input-sm");
    txttextoobservac.val(varobs.val());
    cell.append(txttextoobservac);



    cell = $(row.insertCell(-1));
    var btnRemove3 = $("<input />");
    btnRemove3.attr("type", "button");
    btnRemove3.attr("class", "btn btn-danger");
    btnRemove3.attr("onclick", "Remove3(this);");
    btnRemove3.val("Remove");
    cell.append(btnRemove3);


    cell = $(row.insertCell(-1));
    var registro3 = $("<input />");
    registro3.attr("type", "text");
    registro3.attr("class", "hidden");
    registro3.attr("value", "0");
    registro3.val("0");
    cell.append(registro3);

    varobs.val("");
    varempid.val("");
    varemp.val("");
    varvalor.val("");
});

$("#btnGuardar").click(function () {
    if (!confirm('Seguro que desea guardar?')) {
        return;
    }
    var varIdLiquidacion = 0;
    var vargrupoOperacion = $('#idGrupoOperacion').val();
    var varcierreper = $('#idCierrePeriodico').val();
    var varFechaG = $('#FechaGeneracion').val();
    var varEstado = $('#Estado').val();
    var varcerrado = $('#Cerrado').val();
    var vurl = "/LiquidacionRol/Create";
    var lineasLiquidacionRol = new Array();
    $("#tblDetlValores tbody tr").each(function () {
        var row = $(this);
        var LiquidacionRol = {};
        LiquidacionRol.idEmpleado = row.find("td").eq(0).html();
        LiquidacionRol.Sueldo = row.find("td").eq(3).html();
        LiquidacionRol.Ingresos = row.find("td").eq(4).html();
        LiquidacionRol.Egresos = row.find("td").eq(5).html();
        LiquidacionRol.TotalaRecibir = row.find("td").eq(6).html();
        lineasLiquidacionRol.push(LiquidacionRol);

    });
    if (page != "Create") {
        vurl = "/LiquidacionRol/Edit"
        varIdLiquidacion = $('#Id').val();
    }


    $.ajax({
        type: "POST",
        url: vurl,
        data: { Id: varIdLiquidacion, ListLiquidacionRolEmpleado: lineasLiquidacionRol, FechaGeneracion: varFechaG, idGrupoOperacion: vargrupoOperacion, idCierrePeriodico: varcierreper, Estado: varEstado, Cerrado: varcerrado },
        dataType: "json",
        success: function (r) {
            if (isNumber(r)) {
                if (r = 1) {
                    alert("Proceso Exitoso");
                    window.location.href = "/LiquidacionRol/Index";
                    //  window.location.href = "/LaborEmpaque/Edit/" + r;
                } else {
                    alert("Proceso Fallido");
                    window.location.href = "LiquidacionRol/Index";
                }
            }
            else
                alert(r);
        }

    });
});

$(".sueldosf").click(function () {
    $(".modalSueldos").modal("show");
})

$(".Ingresosf").click(function () {
    $(".modalEgresos").modal("show");
})

$(".Egresosf").click(function () {
    $(".modalEgresos").modal("show");
})

function GrupoChanged() {
    var selectedgrupo = $("#idGrupoOperacion").val();
    $.ajax({
        type: "POST",
        url: "/CierrePeriodico/ListarporGrupo",
        data: { id: selectedgrupo },
        success: function (data) {
            cargarcierresperiodicos(data);
        }
    });
}

function cargarcierresperiodicos(data) {
    var cbmcperiodo = $("#idCierrePeriodico");
    cbmcperiodo.empty();
    $(data).each(function (index, itemP) {
        $(document.createElement('option'))
            .attr('value', itemP.Id)
            .text(itemP.Descripcion)
            .appendTo(cbmcperiodo);

    })
}

function fnCargaDetalleSueldo(idEmpleado) {
    $("#tblDetSueldos tbody tr").remove();
    var vargrupoOperacion = $('#idGrupoOperacion').val();
    var varcierreper = $('#idCierrePeriodico').val();

    //var idEmpleadot;
    //$("#tblDetlValores tbody tr").click(function () {
    //    idEmpleadot = find("TD").eq(0).html();
    //});
    $.ajax({
        type: "GET",
        url: "/LiquidacionRol/CargarDetalleSueldos",
        data: { idEmpleado: idEmpleado, idCierre: varcierreper, idGrupoOperacion: vargrupoOperacion },
        dataType: "json",
        success: function (mensaje) {

            cargar_detalle_sueldo(mensaje);
        }

    });
}

function cargar_detalle_sueldo(mensaje) {
    $("#tblDetSueldos tbody tr").remove();
    $(mensaje).each(function (index, itemP) {
        cargar_linea_detalle_sueldo(itemP);
    })
}

function cargar_linea_detalle_sueldo(mensaje) {
    cadena = "<tr>"
    $(mensaje).each(function (index, item) {

        cadena = cadena + "<td align='center'>" + (item.Fechastr) + "</td>";
        cadena = cadena + "<td align='center'>" + (item.Finca) + "</td>";
        cadena = cadena + "<td align='center'>" + (item.CantidadProducida) + "</td>";
        cadena = cadena + "<td align='center'>" + (item.FuncionLaboral) + "</td>";
        cadena = cadena + "<td align='center'>" + (item.Valor.toFixed(2)) + "</td>";

    });
    cadena = cadena + "</tr>"
    $("#tblDetSueldos tbody").append(cadena);

}

function fnCargaDetalleValores(idEmpleado, TipoDetalle) {
    var varcierreper = $('#idCierrePeriodico').val();
    $("#tblDetalleValores tbody tr").remove();
    $.ajax({
        type: "GET",
        url: "/LiquidacionRol/CargarDetalleValores",
        data: { idEmpleado: idEmpleado, tipoValor: TipoDetalle, idCierre: varcierreper },
        dataType: "json",
        success: function (mensaje) {
            cargar_detalle_val(mensaje);
        }

    });
}

function cargar_detalle_val(mensaje) {
    $("#tblDetalleValores tbody tr").remove();
    $(mensaje).each(function (index, itemP) {
        cargar_linea_detalle_valores(itemP);
    })
}
function cargar_linea_detalle_valores(mensaje) {
    var cadena = "<tr>"


    $(mensaje).each(function (index, item) {

        cadena = cadena + "<td>" + (item.Rubro) + "</td>";
        cadena = cadena + "<td align='right'>" + (item.Valor.toFixed(2)) + "</td>";

    });
    cadena = cadena + "</tr>"
    $("#tblDetalleValores tbody").append(cadena);

}

function fnVerEgresos(e) {
    //var row = e.parentNode.parentNode;
    //var fila = row.getElementsByTagName("td");
    //var codemp = fila[2].innerHTML.trim();
    //var nomEmp = fila[3].innerHTML.trim();
    //var fecha = fila[4].innerHTML.trim();
    //$("#fechaMarcacion").val(fecha);
    //$("#idEmpleado").val(codemp);
    //$("#txtNombreEmpleado").val(nomEmp);

    //$("#fechaMarcacion").val()
    //var fila = e.parent();
}

function ObtenerResumen() {
    var sumpersonas = 0;
    var totalsueldo = 0.00;
    var totalingresos = 0.00;
    var totalegresos = 0.00;
    var totalarecibir = 0.00;
    $("#tblDetlValores tbody tr").each(function () {
        sumpersonas++;
        totalsueldo += parseFloat($(this).find("td").eq(3).text());
        totalingresos += parseFloat($(this).find("td").eq(4).text());
        totalegresos += parseFloat($(this).find("td").eq(5).text());
        totalarecibir += parseFloat($(this).find("td").eq(6).text());
    });
    $("#tdtotalPersonas").text(sumpersonas.toString());
    $("#tdsueldo").text(totalsueldo.toFixed(2).toString());
    $("#tdingresos").text(totalingresos.toFixed(2).toString());
    $("#tdegresos").text(totalegresos.toFixed(2).toString());
    $("#tdTotalaRecibir").text(totalarecibir.toFixed(2).toString());

}

function Remove3(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(1).html();
    if (confirm("Seguro de borrar fila ")) {
        //Get the reference of the Table.
        var table = $("#tblDetlValores")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};

function ChangeBackgroundColor(row) { row.style.backgroundColor = TableBackgroundMouseoverColor; }

function RestoreBackgroundColor(row) { row.style.backgroundColor = TableBackgroundNormalColor; }

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}