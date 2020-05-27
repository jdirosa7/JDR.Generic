$(document).ready(function () {
    var table = $('#tableAccounts').DataTable({
        "ajax": {
            "type": "GET",
            "url": "GetData",
            "datatype": "JSON"
        },
        "columns": [    
            {},
            { "data": "Id" },
            { "data": "AccountNumber" },
            { "data": "Balance" }
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
        $('div.accountText').removeClass('hidden');
        $('p.accountName').removeClass('hidden');

        var rowData = table.rows({ selected: true }).data()[0];

        $('p.accountName').text("en cuenta " + rowData.AccountNumber);

    }).on('deselect', function (e, dt, type, indexes) {
        $('.saldo').addClass('hidden');
        $('.btn-primary').addClass('hidden');
        $('div.accountText').addClass('hidden');
        $('p.accountName').addClass('hidden');
    });

    $('.saldo').addClass('hidden');
    $('.btn-primary').addClass('hidden');
    $('div.accountText').addClass('hidden');
    $('p.accountName').addClass('hidden');
    
});


function transfer() {

    var data = $("#formsubmit").serialize();
    //if (!DataValida()) {
    //    return;
    //}
    $.ajax({
        type: "POST",
        url: "@Url.Action('SubmitTransfer','BankAccount')",
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
        url: "@Url.Action('SubmitExtract','BankAccount')",
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
        url: "@Url.Action('SubmitDeposit','BankAccount')",
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

