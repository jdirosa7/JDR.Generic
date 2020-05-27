$(document).ready(function () {
    $('.date-picker').datepicker();
    var table = $('#tableAccounts').DataTable({
        "ajax": {
            "type": "GET",
            "url": "GetData",
            "datatype": "JSON"
        },
        "columns": [
            {},
            { "data": "Id" },
            { "data": "Name" }
        ],
        columnDefs: [{
            orderable: false,
            className: 'select-checkbox',
            targets: 0,
            defaultContent: ""
        }],
        select: {
            style: 'single',
            selector: 'td:first-child'
        },
        "language": {
            "lengthMenu": "Visualizando _MENU_ registros por página",
            "zeroRecords": "No se encontraron registros",
            "info": "Mostrando _PAGE_ de _PAGES_",
            "infoEmpty": "No se encontraron registros"
        }
    });
    table.on('select', function (e, dt, type, indexes) {
        $('.saldo').removeClass('hidden');
        $('.btn-primary').removeClass('hidden');
    }).on('deselect', function (e, dt, type, indexes) {
        $('.saldo').addClass('hidden');
        $('.btn-primary').addClass('hidden');
    });


    
});


function transfer() {

    var data = $("#formsubmit").serialize();
    if (!DataValida()) {
        return;
    }
    $.ajax({
        type: "POST",
        url: "@Url.Action('Transfer','BankAccount')",
        data: data,
        success: function (response) {
            if (response == "success") {
                $('.add').show();
                setTimeout(function () { window.location.reload() }, 1500);
            }
        },
        error: function (msg) {
            $('.error').show();
        }
    });
}

function extract() {

    var data = $("#formsubmit").serialize();
    if (!DataValida()) {
        return;
    }
    $.ajax({
        type: "POST",
        url: "@Url.Action('Extract','BankAccount')",
        data: data,
        success: function (response) {
            if (response == "success") {
                $('.add').show();
                setTimeout(function () { window.location.reload() }, 1500);
            }
        },
        error: function (msg) {
            $('.error').show();
        }
    });
}

function deposit() {

    var data = $("#formsubmit").serialize();
    if (!DataValida()) {
        return;
    }
    $.ajax({
        type: "POST",
        url: "@Url.Action('Deposit','BankAccount')",
        data: data,
        success: function (response) {
            if (response == "success") {
                $('.add').show();
                setTimeout(function () { window.location.reload() }, 1500);
            }
        },
        error: function (msg) {
            $('.error').show();
        }
    });
}

