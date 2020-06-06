$(document).ready(function () {
    $("#txtFromDate").datepicker();
    $("#txtToDate").datepicker();
    var buttonCommon = {
        exportOptions: {
            format: {
                body: function (data, row, column, node) {
                    // Strip $ from salary column to make it numeric
                    return data;
                }
            }
        }
    };

    var table = $('#tblPOlist').DataTable({
        ajax: 'GetPOList?supplierId=' + $('#txtSupplierId').val() + '&fromDate=' + $('#txtFromDate').val() + '&toDate=' + $('#txtToDate').val(),
        columns: [
            { data: 'POId' },
            { data: 'PONumber' },
            { data: 'Date' },
            { data: 'SupplierName' },
            { data: 'OrderDetail' },
            { data: 'GrandTotal' }
        ],
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false,
            },
            {
                "targets": [5],
                "className": "text-right",
            },
            {
                "targets": [6],
                "render": function (data, type, row) {
                    if (row.IsDeleted) {
                        return "<span ><a href='ManagePurchaseOrder/View/" + row.POId + "'><span class='glyphicon glyphicon-eye-open'></span>View</a></span>";
                    }
                    else {
                        return "<span s><a href='ManagePurchaseOrder/View/" + row.POId + "'><span class='glyphicon glyphicon-eye-open'></span>View</a> / " +
                            "<a href='ManagePurchaseOrder/Update/" + row.POId + "'><span class='glyphicon glyphicon-remove'></span>Modify</a></span> / " +
                            "<a href='#' id='deletePO' onclick='fnDeletePO(" + row.POId + ")' data-id=" + row.POId + "><span class='glyphicon glyphicon-remove'></span>Delete</a></span>";
                    }

                }
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            $.extend(true, {}, buttonCommon, {
                extend: 'copyHtml5'
            }),
            $.extend(true, {}, buttonCommon, {
                extend: 'excelHtml5'
            }),
            $.extend(true, {}, buttonCommon, {
                extend: 'print'
            }),
            $.extend(true, {}, buttonCommon, {
                extend: 'pdfHtml5'
            })
        ], "footerCallback": function (row, data, start, end, display) {
            var api = this.api(), data;

            // Total over all pages
            total = api
                .column(5)
                .data()
                .reduce(function (a, b) {
                    return parseFloat(a) + parseFloat(b);
                }, 0);

            // Update footer
            $(api.column(4).footer()).html(
                '<span style="font-weight:bold;padding-right: 100px;">Total Amt: ' + total.toFixed(2) + '</span>'
            );
        }
    });

    $("#btnGetData").on("click", function (event) {
        debugger
        table.ajax.url('GetPOList?supplierId=' + $('#txtSupplierId').val() + '&fromDate=' + $('#txtFromDate').val() + '&toDate=' + $('#txtToDate').val()).load();
    });

    $("#btnReset").on("click", function (event) {
        debugger
        $('#txtSupplierId').val('');
        $('#txtFromDate').val('');
        $('#txtToDate').val('');
    });
});

function fnDeletePO(purchaseOrderId) {
    debugger
    $.ajax({
        url: "/PurchaseOrder/DeletePurchaseOrder/" + purchaseOrderId, success: function (result) {
            window.location.href = "/PurchaseOrder/PurchaseOrderList";
        }
    });
}




