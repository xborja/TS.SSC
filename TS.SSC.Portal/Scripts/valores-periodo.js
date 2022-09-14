"use strict";
$(document).ready(function () {
    var path = window.location.pathname;
    var page = path.split("/").pop();
    //console.log(page);
    $('#divMensaje').delay(5000).fadeOut();
    $('#FechaInicio').datepicker({
        format: 'dd/mm/yyyy'
    });
    $('#FechaFin').datepicker({
        format: 'dd/mm/yyyy'
    });
    
    var customCellWriter = function (column, record) {
        var html = column.attributeWriter(record),
            td = '<td';
        if (column.hidden || column.textAlign) {
            td += ' style="';
            if (column.hidden) {
                td += 'display: none;';
            }
            if (column.textAlign) {
                td += 'text-align: ' + column.textAlign + ';';
            }
            td += '"';
        }
        return td + '><div>' + html + '<\/td>';
    };
    var makeElementEditable = function (element) {
        $('div', element).attr('contenteditable', true);
        $(element).focusout(function () {
            $('div', element).attr('contenteditable', false);
        });
        $(element).keydown(function (e) {
            if (e.which == 13) {
                e.preventDefault();
                $('div', element).attr('contenteditable', false);
                $(document).focus();
            }
        });
        $('div', element).on('paste', function (e) {
            e.preventDefault();
        });
    };
    $(document).on('keypress', 'textarea#excelPasteBox', function (e) {
        if (e.ctrlKey !== true && e.key != 'v') {
            e.preventDefault();
            e.stopPropagation();
        }
    });
    $(document).on('paste', 'textarea#excelPasteBox', function (e) {
        e.preventDefault();
        var cb;
        var clipText = '';
        if (window.clipboardData && window.clipboardData.getData) {
            cb = window.clipboardData;
            clipText = cb.getData('Text');
        } else if (e.clipboardData && e.clipboardData.getData) {
            cb = e.clipboardData;
            clipText = cb.getData('text/plain');
        } else {
            cb = e.originalEvent.clipboardData;
            clipText = cb.getData('text/plain');
        }
        var clipRows = clipText.split('\n');
        for (i = 0; i < clipRows.length; i++) {
            clipRows[i] = clipRows[i].split('\t');
        }
        var jsonObj = [];
        for (i = 0; i < clipRows.length - 1; i++) {
            var item = {};
            for (j = 0; j < clipRows[i].length; j++) {
                if (clipRows[i][j] != '\r') {
                    if (clipRows[i][j].length !== 0) {
                        item[j] = clipRows[i][j];
                    }
                }
            }
            jsonObj.push(item);
        }
        var tablePlaceHolder = document.getElementById('output');
        tablePlaceHolder.innerHTML = '';
        var table = document.createElement('table');
        table.id = 'excelDataTable';
        table.className = 'table table-striped';
        var header = table.createTHead();
        var row = header.insertRow(0);

        //var headerCell = document.createElement('th');
        //headerCell.innerHTML = 'Cedula';
        //var cell = row.insertCell(0);
        //cell.parentNode.insertBefore(headerCell, cell);
        //cell.parentNode.removeChild(cell);

        //var headerCell = document.createElement('th');
        //headerCell.innerHTML = 'Nombre';
        //var cell = row.insertCell(1);
        //cell.parentNode.insertBefore(headerCell, cell);
        //cell.parentNode.removeChild(cell);

        //var headerCell = document.createElement('th');
        //headerCell.innerHTML = 'Valor';
        //var cell = row.insertCell(2);
        //cell.parentNode.insertBefore(headerCell, cell);
        //cell.parentNode.removeChild(cell);

        //var headerCell = document.createElement('th');
        //headerCell.innerHTML = 'Observacion';
        //var cell = row.insertCell(3);
        //cell.parentNode.insertBefore(headerCell, cell);
        //cell.parentNode.removeChild(cell);

        var keys = [];
        for (var i = 0; i < jsonObj.length; i++) {
            var obj = jsonObj[i];
            for (var j in obj) {
                if ($.inArray(j, keys) == -1) {
                    keys.push(j);
                }
            }
        }
        keys.forEach(function (value, index) {
            var headerCell = document.createElement('th');
            headerCell.innerHTML = '<div>' + value + '<\/div>';
            $(headerCell).click(function () {
                makeElementEditable(this);
            });
            $(headerCell).keyup(function (e) {
                var ignoredClass = 'ignored';
                var ignoredAttr = 'data-attr-ignore';
                var columnCells = $('td, th', table).filter(':nth-child(' + ($(this).index() + 1) + ')');
                $(this).removeAttr(ignoredAttr);
                $(columnCells).each(function () {
                    $(this).removeClass(ignoredClass);
                    $(this).removeAttr(ignoredAttr);
                });
                if ($(this).is(':empty') || $(this).text().trim() === '') {
                    $(this).attr(ignoredAttr, '');
                    $(columnCells).each(function () {
                        $(this).addClass(ignoredClass);
                        $(this).attr(ignoredAttr, '');
                    });
                }
            });
            var cell = row.insertCell(index);
            cell.parentNode.insertBefore(headerCell, cell);
            cell.parentNode.removeChild(cell);
        });
        tablePlaceHolder.appendChild(table);
        var excelDynaTable = $('table#excelDataTable').dynatable({
            features: {
                paginate: false,
                search: false,
                recordCount: true,
                sort: false
            },
            dataset: {
                records: jsonObj
            },
            writers: {
                _cellWriter: customCellWriter
            }
        });
        $(document).on('click', 'table#excelDataTable td', function () {
            makeElementEditable(this);
        });
    });
    jQuery.fn.pop = [].pop;
    jQuery.fn.shift = [].shift;

    if (page == "Edit") {
        document.getElementById("idGrupoOperacion").disabled = true;
        document.getElementById("idCierrePeriodicos").disabled = true;
        document.getElementById("cmbrubro").disabled = true;
    }

});

////COMBOS MULTIPLES

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
    $.ajax({
        type: "POST",
        url: "/Empleado/ListarporGrupo",
        data: { id: selectedgrupo },
        success: function (data) {
            cargarempleados(data);
        }
    });
}

function cargarcierresperiodicos(data) {
    var cbmcperiodo = $("#idCierrePeriodicos");
    cbmcperiodo.empty();
    $(data).each(function (index, itemP) {
        $(document.createElement('option'))
            .attr('value', itemP.Id)
            .text(itemP.Descripcion)
            .appendTo(cbmcperiodo);

    })
}

function cargarempleados(data) {
    var cbmcempleado = $("#cmbempleado");
    cbmcempleado.empty();
    $(data).each(function (index, itemP) {
        $(document.createElement('option'))
            .attr('value', itemP.Id)
            .text(itemP.NombreCompleto)
            .appendTo(cbmcempleado);

    })
}

    ///END COMBOS
$("#btnCargar").click(function () {
    var cbmCierrePeriodicos = $("#idCierrePeriodicos");
    var cbmRubroNomina = $("#idRubroNomina");
    if ($("#idGrupoOperacion").val() == "") {
        alert('Seleccione Grupo de Operacion');
        return false;
    }
    else {
        $("#divdetallevaloresperiodo").attr("hidden", false);
        document.getElementById("idGrupoOperacion").disabled = true;
        document.getElementById("idCierrePeriodicos").disabled = true;
        document.getElementById("cmbrubro").disabled = true;
    }
});

$("#tblDetlValores").on("click", "#btnAddCampo", function () {
    var varvalor = $("#valorf");
    var varobs = $("#Observacionf");
    var varempid = $("#cmbempleadof");
    var varemp = $("#cmbempleadof option:selected");

    var opciones = $('#cmbempleadof > option').clone();
    var opcionesbak = $('#cmbempleadof > option').clone();

    var tBody = $("#tblDetlValores > TBODY")[0];
    var row = tBody.insertRow(-1);

    cell = $(row.insertCell(-1));



    cell = $(row.insertCell(-1));
    var registro3 = $("<input />");
    registro3.attr("type", "text");
    registro3.attr("class", "hidden");
    registro3.attr("value", "0");
    registro3.val("0");
    cell.append(registro3);

    var cell = $(row.insertCell(-1));
    var cmbempleadot = $("<select></select>");
    cmbempleadot.attr("style", " width:300px;height:35px");
    cmbempleadot.attr("class", "form-control col-xs-2");
    cmbempleadot.append(opciones);
    cmbempleadot.val(varempid.val());
    cell.append(cmbempleadot);

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
    btnRemove3.attr("class", "btn btn-danger btn-xs");
    btnRemove3.attr("onclick", "Remove3(this);");
    btnRemove3.val("Quitar");
    cell.append(btnRemove3);

    varobs.val("");
    varempid.empty();
    varempid.append(opcionesbak);
    varempid.val("");
    varemp.val("");
    varvalor.val("");
});



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

$("#btnGuardar").click(function () {
    if (!confirm('Seguro que desea guardar?')) {
        return;
    }
    var idgrupooperacion = $("#idGrupoOperacion").val();
    var idcierreperiodico = $("#idCierrePeriodicos").val();
    var idrubronomina = $("#cmbrubro").val();
    $("#tblValores tbody tr").each(function () {
        var row = $(this);
        idgrupooperacion = row.find("TD").eq(0).find('select').val();
        idcierreperiodico = row.find("TD").eq(1).find('select').val();
        idrubronomina = row.find("TD").eq(2).find('select').val();

    });

    //var lineasValorPeriodo = new Array();
    //$("#tblDetlValores tbody tr").each(function () {
    //    var row = $(this);
    //    var ValorPeriodo = {};
    //    ValorPeriodo.Id = 0;
    //    ValorPeriodo.idGrupoOperacion = idgrupooperacion;
    //    ValorPeriodo.idCierrePeriodicos = idcierreperiodico;
    //    ValorPeriodo.idRubroNomina = idrubronomina;
    //    ValorPeriodo.idEmpleado = row.find("TD").eq(2).find('select').val();
    //    ValorPeriodo.Valor = row.find("TD").eq(3).find('input').val();
    //    ValorPeriodo.Observacion = row.find("TD").eq(4).find('input').val();
    //    lineasValorPeriodo.push(ValorPeriodo);

    //});



    var lineasValorPeriodo = new Array();
    $("#excelDataTable tr").each(function () {
        var row = $(this);
        var ValorPeriodo = {};
        ValorPeriodo.Id = 0;
        ValorPeriodo.idGrupoOperacion = idgrupooperacion;
        ValorPeriodo.idCierrePeriodicos = idcierreperiodico;
        ValorPeriodo.idRubroNomina = idrubronomina;
        ValorPeriodo.Cedula = row.find("TD").find('div').eq(0).html();
        ValorPeriodo.Nombre = row.find("TD").find('div').eq(1).html();
        ValorPeriodo.Valor = row.find("TD").find('div').eq(2).html();
        ValorPeriodo.Observacion = row.find("TD").find('div').eq(3).html();
        lineasValorPeriodo.push(ValorPeriodo);

    });



    $.ajax({
        type: "POST",
        url: "/ValoresPeriodo/Create",
        data: { ListLineasValores: lineasValorPeriodo },
        dataType: "json",
        success: function (r) {
            if (isNumber(r)) {
                if (r = 1) {
                    alert("Proceso Exitoso");
                    window.location.href = "Index";
                    //  window.location.href = "/LaborEmpaque/Edit/" + r;
                } else {
                    alert("Proceso Fallido");
                    window.location.href = "../Index";
                }
            }
            else
                alert(r);
        }

    });
});


$("#btnEditar").click(function () {
    if (!confirm('Seguro que desea guardar?')) {
        return;
    }
    var idgrupooperacion;
    var idcierreperiodico;
    var idrubronomina;
    $("#tblValores tbody tr").each(function () {
        var row = $(this);
        idgrupooperacion = row.find("TD").eq(0).find('select').val();
        idcierreperiodico = row.find("TD").eq(1).find('select').val();
        idrubronomina = row.find("TD").eq(2).find('select').val();
    });

    var lineasValorPeriodo = new Array();
    $("#tblDetlValores tbody tr").each(function () {
        var row = $(this);
        var ValorPeriodo = {};
        //ValorPeriodo.Id = 0;
        ValorPeriodo.Id = row.find("TD").eq(1).find('input').val();
        ValorPeriodo.idGrupoOperacion = idgrupooperacion;
        ValorPeriodo.idCierrePeriodicos = idcierreperiodico;
        ValorPeriodo.idRubroNomina = idrubronomina;
        ValorPeriodo.idEmpleado = row.find("TD").eq(2).find('select').val();
        ValorPeriodo.Valor = row.find("TD").eq(3).find('input').val();
        ValorPeriodo.Observacion = row.find("TD").eq(4).find('input').val();
        lineasValorPeriodo.push(ValorPeriodo);

    });


    $.ajax({
        type: "POST",
        url: "/ValoresPeriodo/Edit",
        data: { ListLineasValores: lineasValorPeriodo, idRubrop: idrubronomina, idCierreP: idcierreperiodico },
        dataType: "json",
        success: function (r) {
            if (isNumber(r)) {
                if (r = 1) {
                    //alert("Proceso Exitoso");
                    //window.location.href = "Index";
                    window.location.reload(true);
                    //  window.location.href = "/LaborEmpaque/Edit/" + r;
                } else {
                    alert("Proceso Fallido");
                    //window.location.href = "../Index";
                }
            }
            else
                alert(r);
        }

    });
});

//Para validar la entrada de un numero
function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}