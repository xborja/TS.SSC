$(document).ajaxStart(function () {
    $('#modal-default-loading').modal('show');
    console.log('Ajax happening');
}).ajaxStop(function () {
    setTimeout(function () {

        console.log("fin de ajax");
        $('#modal-default-loading').modal('hide');
        //$('#kt_modal_loading').hide();
        console.log('Ajax success');
    }, 500);

    //$('#kt_modal_loading').modal('hide');
    //console.log('Ajax complete');
});


$(document).ready(function () {
    $('#divMensaje').delay(4000).fadeOut();

    var table = $('#tblsacramentos').DataTable({
        "orderCellsTop": true,
        "fixedHeader": true,
        "responsive": true,
        "columnDefs": [
            { "orderable": false, "targets": 0 }
        ],
        "language": { "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json" },
        "pageLength": 10,
        "lengthMenu": [[5, 10, 20,50,100 -1], [5, 10, 20,50,100, 'Todos']],
        //"order": [[3, "asc"]],
        "searching": true,
        "stateSave": false
    });
    //Creamos una fila en el head de la tabla y lo clonamos para cada columna
    $('#tblsacramentos thead tr').clone(true).appendTo('#tblsacramentos thead');

    $('#tblsacramentos thead tr:eq(1) th').each(function (i) {
        var title = $(this).text(); //es el nombre de la columna
        if (title != '') {
            $(this).html('<input type="text" style="color: black; width: 75px;" placeholder="' + title + '" />');

            $('input', this).on('keyup change', function () {
                if (table.column(i).search() !== this.value) {
                    table
                        .column(i)
                        .search(this.value)
                        .draw();
                }
            });

        }
    });
    //$(".select2").select2({
    //    width: "100%",
    //    height: "200px",
    //    placeholder: "Seleccione"
    //});
    $('#fechaRegistro').datepicker({
        //defaultDate: 'today',
        //multidate: true,
        format: 'dd/mm/yyyy'

    });
    $('#PersonaM_FechaNacimiento').datepicker({
        defaultDate: 'today',
        format: 'dd/mm/yyyy'

    });
    $('#PersonaM_FechaBautismo').datepicker({
        defaultDate: 'today',
        format: 'dd/mm/yyyy'

    });

    $('.confirm').on('click', function () {
        return confirm('Esta seguro?');
    });

    $("#submit").click(function () {
        document.forms[0].submit();
        return false;
    });

});

function fncargarpersona(e) {
    if (e.value === "-1") {
        $("#id").val(0);
        $("#idSacramento").select2("val", "Seleccione");
        $("#fechaRegistro").val("");
        //$("#idPersona").select2("val", "Seleccione");
        $("#divnombre").attr("hidden", false);
        $("#PersonaM_id").val(0);
        $("#PersonaM_Nombre").val("");
        $("#PersonaM_Cedula").val("");
        $("#PersonaM_LugarNacimiento").val("");
        $("#PersonaM_FechaNacimiento").val("");
        $("#PersonaM_LugarBautismo").val("");
        $("#PersonaM_FechaBautismo").val("");
        $("#PersonaM_NombrePadre").val("");
        $("#PersonaM_NombreMadre").val("");
        $("#Ministro").val("");
    } else {
        var vidParroquia = $("#idParroquia").val();
        $.ajax({
            type: "POST",
            url: "/Persona/PersonaSacramento",
            data: { id: e.value, idParroquia: vidParroquia },
            success: function (data) {
                cargarpersona(data);
            }
        });

    }
}
function cargarpersona(data) {
    $("#idPersona").val(data.id);
    $("#PersonaM_id").val(data.id);
    $("#divnombre").attr("hidden", true);
    $("#PersonaM_Nombre").val(data.Nombre);
    $("#PersonaM_Cedula").val(data.Cedula);
    $("#PersonaM_LugarNacimiento").val(data.LugarNacimiento);
    $("#PersonaM_FechaNacimiento").val(data.FechaN);
    $("#PersonaM_LugarBautismo").val(data.LugarBautismo);
    $("#PersonaM_FechaBautismo").datepicker({ dateFormat: "dd M yy" }).datepicker("setDate", data.FechaBautismo);
    $("#PersonaM_FechaBautismo").val(data.FechaB);
    $("#PersonaM_NombrePadre").val(data.NombrePadre);
    $("#PersonaM_NombreMadre").val(data.NombreMadre);

}


