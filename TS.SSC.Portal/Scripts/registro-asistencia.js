"use strict";
var page = '';
var sumpersonas = 0;
var totalasistencia = 0.00;
$(document).ready(function () {
    var path = window.location.pathname;
    page = path.split("/").pop();
    //console.log(page);
    $('#divMensaje').delay(5000).fadeOut();

    $('#Fecha').datepicker({
        //defaultDate: 'today',
        //multidate: true,
        format: 'dd/mm/yyyy'
    });

    if (page != "Create") {
        //cargar los totales de la asistencia
        ObtenerResumen();
    }

});

//begin
$("form").on("click", "#btnSaveAll", function () {
    if (!confirm('Seguro que desea guardar?')) {
        return;
    }
    //if ($("#cantidadcajas").val() == "") {
    //    alert('Ingrese Cantidad de Cajas');
    //}
    //else {
    //    if ($("#cantidadcajastotal").val() == "") { alert('Ingrese Cantidad de Cajas') }
    //    else {

    var vardesc = $('#Descripcion').val();
    var varfechap = $('#FechaP').val();
    var varestado = $('#Estado').val();
    var varidplantilla = $('#idPlantilla').val();
    var vartipocaja = $('#idTipoCaja').val();
    var varfactorcon = $('#factorcon').val();
    var varcantcaja = $('#cantidadcajas').val();
    var varcostocaja = $('#costoxcaja').val();
    var varcantcajatot = $('#cantidadcajastotal').val();
    var varfinca = $('#idFinca').val();

    var detallepro = new Array();
    $("#tblProduccion TBODY TR").each(function () {
        var row = $(this);

        var linea = {};
        linea.idFuncionLaboral = row.find("TD").eq(0).html();
        linea.numeroplata = row.find("TD").eq(2).find('input').val();
        linea.numpersonas = row.find("TD").eq(3).find('input').val();
        linea.numpersonasreal = row.find("TD").eq(4).find('input').val();
        linea.totalplatas = row.find("TD").eq(5).find('input').val();
        linea.valorplata = row.find("TD").eq(6).find('input').val();
        linea.montototal = row.find("TD").eq(7).find('input').val();
        linea.valorxpersona = row.find("TD").eq(8).find('input').val();
        linea.tarifaxcaja = row.find("TD").eq(9).find('input').val();
        detallepro.push(linea);
    });
    $.ajax({
        type: "POST",
        url: "/tblRegistroAsistencia/Create",
        data: { Descripcion: vardesc, Estado: varestado, Fecha: varfechap, costoxcaja: varcostocaja, cantidadcajas: varcantcaja, cantidadcajastotal: varcantcajatot, idPlantilla: varidplantilla, idTipoCaja: vartipocaja, factorcon: varfactorcon, idFinca: varfinca, ProduccionDet: detallepro },
        //contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            alert(r + "Registros guardados...");
            //window.location.reload(true);
            window.location.href = "Index";
        }
    });



    //}


    //}//else interno
});
//end
$("#tblRegistroAsistencia").on("click", "#btnAddCampo", function () {
    var vartarifa = $("#TarifaProduccionf");
    var varobs = $("#Observacion");
    var varempid = $("#cmbempleadof");
    var varfunid = $("#cmbfuncionlaboralf");
    var varemp = $("#cmbempleadof option:selected");
    var varfun = $("#cmbfuncionlaboralf option:selected");

    var opciones = $('#cmbempleadof > option').clone();
    var opcionesbak = $('#cmbempleadof > option').clone();

    var opcionesf = $('#cmbfuncionlaboralf > option').clone();
    var opcionesfbak = $('#cmbfuncionlaboralf > option').clone();

    var tBody = $("#tblRegistroAsistencia > TBODY")[0];
    var row = tBody.insertRow(-1);


    var cell = $(row.insertCell(-1));
    var cmbempleadot = $("<select></select>");
    cmbempleadot.attr("style", " width:300px;height:35px");
    cmbempleadot.attr("class", "form-control input-sm");
    cmbempleadot.append(opciones);
    cmbempleadot.val(varempid.val());
    cell.append(cmbempleadot);

    //cell.append(cmbempleadot.append(optioncmbempleado.val(varempid.val()).text(varemp.text())));

    var cell = $(row.insertCell(-1));
    var cmbfunc = $("<select></select>")
    cmbfunc.attr("class", "form-control input-sm");
    cmbfunc.append(opcionesf);
    cmbfunc.val(varfunid.val());
    cmbfunc.attr("onchange", "fn_dar_tarifa(this);");
    cell.append(cmbfunc);
    //cell.append(cmbfunc.append(optioncmbfunc.val(varfunid.val()).text(varfun.text())));
    var cell = $(row.insertCell(-1));
    var txttarifa = $("<input />");
    txttarifa.attr("type", "text");
    //txttarifa.attr("style", " width:100px;height:35px");
    txttarifa.attr("class", "form-control input-sm text-center");
    txttarifa.val(vartarifa.val());
    cell.append(txttarifa);

    var cell = $(row.insertCell(-1));
    var txttextoobservac = $("<input />");
    txttextoobservac.attr("type", "text");
    //txttextoobservac.attr("style", " width:300px;height:35px");
    txttextoobservac.attr("class", "form-control input-sm");
    txttextoobservac.val(varobs.val());
    cell.append(txttextoobservac);

    if ($("#IdGrupoOperacion").val() == 2) {
        var opcionesn = $('#cmbnovf > option').clone();
        var opcionesnbak = $('#cmbnovf > option').clone();
        var varnovid = $("#cmbnovf");
        var cell = $(row.insertCell(-1));
        var cmbnovedadt = $("<select></select>");
        //cmbnovedadt.attr("style", " width:100px;height:35px");
        cmbnovedadt.attr("class", "form-control input-sm");
        cmbnovedadt.append(opcionesn);
        cmbnovedadt.val(varnovid.val());
        cell.append(cmbnovedadt);
        varnovid.empty();
        varnovid.append(opcionesnbak);
        varnovid.val("");
    }
    else {
        var cell = $(row.insertCell(-1));
        cell.hide();

    }

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
    varempid.empty();
    varempid.append(opcionesbak);
    varempid.val("");
    //varempid.append(opciones)
    //varempid.selectedIndex = 0;
    varfunid.empty();
    varfunid.append(opcionesfbak);
    varfunid.val("");

    varemp.val("");
    varfun.val("");
    vartarifa.val("");
});

$("#btnGuardar").click(function () {
    var varurl = "/RegistroAsistencia/CreateReg"
    if (!confirm('Seguro que desea guardar?')) {
        return;
    }
    $("#div-process").boxRefresh('load');
    var registroAsistencia = {};
    var listLineasDetalleAsistencia = new Array();
    $("#tblRegistroAsistencia tbody tr").each(function () {
        var row = $(this);
        var DetalleRegistroAsistencia = {};
        DetalleRegistroAsistencia.idEmpleado = row.find("TD").eq(0).find('select').val();
        DetalleRegistroAsistencia.idFuncionLaboral = row.find("TD").eq(1).find('select').val();
        DetalleRegistroAsistencia.tarifaproduccion = row.find("TD").eq(2).find('input').val();
        DetalleRegistroAsistencia.Observacion = row.find("TD").eq(3).find('input').val();
        DetalleRegistroAsistencia.idNovedad = row.find("TD").eq(4).find('select').val();
        listLineasDetalleAsistencia.push(DetalleRegistroAsistencia);

    });

    var grupoOperacion = $("#IdGrupoOperacion").val();
    var varcantidadcajastotal = $('#cantidadcajastotalv').val();
    var varFecha = $('#Fecha').val();
    var varSemana = $('#semanaC').val();
    var idfinc = $('#idFinca').val();
    var idfincacmb = $('#cmbFinca').val();
    var varAdminCuadrilla = $('#AdminCuadrillaC').val();
    var varEstado = $('#Estado').val();
    registroAsistencia.ListLineasDetalleAsistencia = listLineasDetalleAsistencia;
    if (page != 'Create') {
        var varid = $('#Id').val();
        registroAsistencia.Id = varid;
        varurl = "/RegistroAsistencia/Edit";
    }
    registroAsistencia.Fecha = varFecha;
    registroAsistencia.Semana = varSemana;
    registroAsistencia.cantidadcajastotal = varcantidadcajastotal;

    registroAsistencia.idFinca = idfinc;
    registroAsistencia.AdminCuadrilla = varAdminCuadrilla;
    registroAsistencia.Estado = varEstado;
    registroAsistencia.IdGrupoOperacion = grupoOperacion;

    $.ajax({
        type: "POST",
        url: varurl,
        data: { item: registroAsistencia },
        dataType: "json",
        success: function (r) {
            if (isNumber(r)) {
                if (r = 1) {
                    alert("Proceso Exitoso");
                    window.location.href = "/RegistroAsistencia/Index/" + grupoOperacion;
                    //  window.location.href = "/LaborEmpaque/Edit/" + r;
                } else {
                    alert("Proceso Fallido");
                    window.location.href = "/RegistroAsistencia/Index/" + grupoOperacion;
                }
            }
            else
                alert(r);
        }

    });
});

$("#Fecha").change(function () {
    var grupoOperacion = $("#IdGrupoOperacion").val();
    var Fecha = $("#Fecha").val();
    var requiereCierre = $("#requiereCierre").val();
    if (requiereCierre === "1") {
        this.form.submit();
    }

});


function fn_dar_tarifa(e) {
    var vFinca = $("#idFinca").val();
    var vdia = $("#Fecha").val();
    var vGrupoOperacion = $("#IdGrupoOperacion").val();
    //var cmbFuncionLaboral = e;
    var vValorPersona = e.parentElement.parentElement.children[2].children[0];
    var vEmpleado = e.parentElement.parentElement.children[0].children[0].value;
    var vFuncionLaboral = e.value;
    $.ajax({
        type: "POST",
        url: "/RegistroAsistencia/GetTarifa",
        data: { Fecha: vdia, idFinca: vFinca, idEmpleado: vEmpleado, idFuncionLaboral: vFuncionLaboral, idGrupoOperacion: vGrupoOperacion },
        success: function (data) {
            //var tarifa;
            // tarifa = $.parseJSON(data);
            //$("#TarifaProduccionf").val(data.valorxpersona);
            vValorPersona.value = data.valorxpersona;
            $("#cantidadcajastotalv").val(data.montototal);
        }
    });
}

function Remove3(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(1).html();
    if (confirm("Seguro de borrar fila ")) {
        //Get the reference of the Table.
        var table = $("#tblRegistroAsistencia")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};

function fn_dar_valortipocaja() {
    var idtipo = $("#idTipoCaja").val();
    $.ajax({
        type: "POST",
        url: "/tblRegistroAsistencia/GetValTipoCaja",
        data: { idTipoCaja: idtipo },
        success: function (data) {
            if (data == "") {
            }
            $("#costoxcaja").val(data.valorcaja);
            $("#factorcon").val(data.FactorConversion);
        }
    });
}

function fn_dar_fn_dar_empfinca() {
    var vidfinca = $("#idFinca").val();
    $.ajax({
        type: "POST",
        url: "/tblRegistroAsistencia/GetEmpFinca",
        data: { idFinca: vidfinca },
        success: function (data) {
            if (data == "") {
                $("#tblRol tbody tr").remove();
                alert('No existen detalles de Roles para mostrar');
                $("#btnLink").removeClass("ocultar");
            }
            else cargar_detalle_pla(data);
        }
        //$("#TariffNew").val(data);

    });
}
//end
//begin
function cargar_detalle_pla(data) {
    $("#tblRol tbody tr").remove();
    $(data).each(function (index, itemP) {
        cargar_linea_detalle_pla(itemP.Items);
    });
}
//end

//begin
function cargar_linea_detalle_pla(mensaje) {
    $("#tfootpro").attr("hidden", false);
    var cadena = "<tr>"
    $(mensaje).each(function (index, item) {
        cadena = cadena + "<td class='ocultar'>" + (item.idfuncionlaboral) + "</td>";

        cadena = cadena + "<td> <input type='text' value=" + "'" + (item.nomfunlab) + "' class='form-control input-sm text-center' disabled /></td>";
        cadena = cadena + "<td> <input type='text' id='numplatas' value=" + "'" + (item.numeroplatas) + "' class='form-control input-sm text-center' /></td>";
        cadena = cadena + "<td><input type='text' required  id='numpersona' class='form-control input-sm text-center'/></td>";
        cadena = cadena + "<td><input type='text' required  id='numpersonareal' class='form-control input-sm text-center'/></td>";
        cadena = cadena + "<td><input type='text' required  id='numtotalplatas' class='form-control input-sm text-center'/></td>";
        cadena = cadena + "<td><input type='text' required  id='numvalorplata' class='form-control input-sm text-center'/></td>";
        cadena = cadena + "<td><input type='text' required  id='nummontototal' class='form-control input-sm text-center'/></td>";
        cadena = cadena + "<td><input type='text' required id='numvalorxpersona' class='form-control input-sm text-center'/></td>";
        cadena = cadena + "<td><input type='text' required  id='numtarifaxcaja' class='form-control input-sm text-center'/></td>";
        cadena = cadena + "</tr>"
    });

    $("#tblRol   tbody").append(cadena);
}
//end

//begin
function buscaEnTabla() {
    var input, filter, table, tr, tds, td, i;
    var textfound = false;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("tblRol");
    tds = table.rows[0].cells.length;
    tr = table.getElementsByTagName("tr");
    for (i = 1; i < tr.length; i++) {
        textfound = false;
        for (j = 3; j < tds - 1; j++) {
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
//end

//Funciones para el calculo de la tarifación de la producción
//begin
function ObtenerTotalPlata() {
    var valorPlata = 0.00;
    $("#tblProduccion tbody tr").each(function () {
        var numplata = $(this).find("td").eq(2).find("input").val();
        var numpersonas = $(this).find("td").eq(3).find("input").val();
        var totalplata = numpersonas * numplata;
        valorPlata += totalplata;
        $(this).find("td").eq(5).find("input").val(totalplata);
    });
    return valorPlata;
}
//end

//begin
function ObtenerCostoTotalCajas() {
    var cantidadcajas = $("#cantidadcajas").val();
    var factorconversion = $("#factorcon").val();
    var costocaja = $("#costoxcaja").val();
    var cantidadcajasfinal = cantidadcajas * factorconversion;
    var costototalcajas = cantidadcajasfinal * costocaja;
    $("#cantidadcajastotal").val(cantidadcajasfinal);
    return costototalcajas;
}
//end


//begin
function CalculaValoresProduccion(cantidadcajas, valorplata) {
    $("#tblProduccion tbody tr").each(function () {
        var numpersonas = $(this).find("td").eq(3).find("input").val();
        var numpersonasreal = $(this).find("td").eq(4).find("input").val();
        var totalplata = $(this).find("td").eq(5).find("input").val();
        var montototal = Math.round(valorplata * totalplata * 100) / 100;
        var montopersona = Math.round(montototal / numpersonasreal * 100) / 100;
        var tarifacaja = Math.round(montopersona / cantidadcajas * 1000) / 1000;
        $(this).find("td").eq(6).find("input").val(valorplata);
        $(this).find("td").eq(7).find("input").val(montototal);
        $(this).find("td").eq(8).find("input").val(montopersona);
        $(this).find("td").eq(9).find("input").val(tarifacaja);
    });

}
//end

//begin
function fn_calcularproduccion() {

    var totalPlata = Math.round(ObtenerTotalPlata() * 100) / 100;
    var costocajas = Math.round(ObtenerCostoTotalCajas() * 100) / 100;
    var valorplata = Math.round(costocajas / totalPlata * 100) / 100;
    var cantidadfinalcajas = $("#cantidadcajastotal").val();
    CalculaValoresProduccion(cantidadfinalcajas, valorplata);
}
//end

//begin
function ObtenerResultado(e) {
    var totalPlatas = 0;
    $(".numplatas").each(function () {
        totalPlatas += parseFloat($(this).html()) || 0;
        $("#numeroplataltotal").val(totalPlatas);
    });
}
                                                                                                //end
function ObtenerResumen() {
    sumpersonas = 0;
    totalasistencia = 0.00;
    var cadena = "";
    $("#tblRegistroAsistencia tbody tr").each(function () {
        sumpersonas++;
        totalasistencia += parseFloat($(this).find("td").eq(2).find("input").val());
    });
    cadena = "Personas: " + sumpersonas.toString() + " Total: " + totalasistencia.toFixed(2).toString();
    $("#divResumen").text(cadena);
}
function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

//begin
function IngresoNumerosValor(e) {
    var Valor = document.activeElement.value;
    //var Valor = $("#Valor").val();
    var ValidaValor = Valor.split('.');
    var charCode
    charCode = e.keyCode
    status = charCode
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        if (charCode == 46) {
            if (ValidaValor.length > 1) {
                return false
            }
            else return true
        }
        else return false
    }
    return true
}
//end
