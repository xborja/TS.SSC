$(function () {
    $('#divMensaje').delay(4000).fadeOut();
    $.fn.dataTable.moment('DD/MM/YYYY');

    $('#tblpersona').DataTable({
        "responsive": true,
        //"columnDefs": [{ targets: 'datatable-nosort', orderable: false }],
        "language": { "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json" },
        "pageLength": 10,
        "lengthMenu": [[5, 10, 20,50,100 -1], [5, 10, 20,50,100, 'Todos']],
        //"order": [[3, "asc"]],
        "searching": true,
        "stateSave": true
    });

    $('#FechaNacimiento').datepicker({
        //defaultDate: 'today',
        //multidate: true,
        format: 'dd/mm/yyyy',
        orientation: 'bottom'

    });

    $('#FechaBautismo').datepicker({
        //defaultDate: 'today',
        //multidate: true,
        format: 'dd/mm/yyyy',
        orientation: 'bottom'

    });

    $('.confirm').on('click', function () {
        return confirm('Esta seguro?');
    });

    $("#submit").click(function () {
        document.forms[0].submit();
        return false;
    });
});