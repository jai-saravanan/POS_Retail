$(document).ready(function () {
    $("#selSupplierName").change(function () {
        $('#Supplier_ID').val(this.value);
        $('#Balance').text($('option:selected', this).attr('data-balance'));
        $('#Address').val($('option:selected', this).attr('data-address'));
        $('#City').val($('option:selected', this).attr('data-city'));
        $('#Mobile').val($('option:selected', this).attr('data-mobile'));
    });

    $("#ProductId").change(function () {
        // clear exisiting values // TODO
        if (this.value == '') {
            $('#txtBarCode').val('');
            $('#txtUnit').val('');
            $('#txtRate').val('');
            $('#txtProductAmt').val('');
            return
        }
        $('#txtBarCode').val($('option:selected', this).attr('data-barcode'));
        $('#txtUnit').val($('option:selected', this).attr('data-puchase-unit'));

        $.get("GetPurchasePriceByProductId?pid=" + this.value, function (data) {
            $("#txtRate").val(data);
        });
    });

    $("#TaxType").change(function () {
        $('#txtTaxPercentage').val(this.value);
    });

    $("#TaxType").change(function () {
        calculateTotalAmt();
    });

    jQuery('#txtQty').on('input', function () {
        var rate = $('#txtRate').val();
        $('#txtProductAmt').val(rate * this.value);
    });
    jQuery('#txtRate').on('input', function () {
        debugger
        var qty = $('#txtQty').val();
        $('#txtProductAmt').val(qty * this.value);
    });

    $('#btnAddProduct').click(function () {
        $('#errorProductId,#errorQty,#errorRate').addClass('hide')
        var isValidToAdd = true;
        var productId = $('#ProductId').val();
        var barCode = $('#txtBarCode').val();
        var qty = $('#txtQty').val();
        var rate = $('#txtRate').val();
        var amt = $('#txtProductAmt').val();
        if (productId == '' || isNaN(productId)) {
            $('#errorProductId').removeClass('hide')
            isValidToAdd = false;
        }
        if (qty == '' || isNaN(qty) || parseInt(qty) < 0) {
            $('#errorQty').removeClass('hide')
            isValidToAdd = false;
        }
        if (rate == '' || isNaN(rate) || parseInt(rate) < 0) {
            $('#errorRate').removeClass('hide')
            isValidToAdd = false;
        }
        debugger
        if (isValidToAdd) {
            tableBody = $("#productList tbody")
            var row = "<tr> \
                        <td class='hide'>"+ $('#ProductId').val() + "</td>\
                       <td>"+ $("#ProductId option:selected").text() + "</td> \
                       <td>"+ barCode + "</td> \
                       <td>"+ qty + "</td> \
                       <td>"+ rate + "</td> \
                       <td>"+ amt + "</td> \
                       <td><button type='button' onclick='fnRemoveRow(this)'>Delete</button></td> \
                       </tr>";
            tableBody.append(row);
        }
        fnClearProductInfo();
        calculateTotalAmt();


    });


    function fnClearProductInfo() {
        $('#ProductId').val('');
        $('#txtBarCode').val('');
        $('#txtUnit').val('');
        $('#txtRate').val('');
        $('#txtProductAmt').val('');
        $('#txtQty').val('');
    }
});

function fnRemoveRow(event) {
    event.parentNode.parentNode.remove();
    calculateTotalAmt();
}

function calculateTotalAmt() {
    var rows = $("#productList tbody tr");
    var totalAmt = 0;
    for (var i = 0; i < rows.length; i++) {
        totalAmt = totalAmt + parseFloat(rows[i].cells[4].innerText);
    }
    $('#txtSubTotal').val(totalAmt);
    $('#txtTaxValue').val(totalAmt * ($('#txtTaxPercentage').val() / 100));
    $('#txtGrandTotal').val(parseFloat($('#txtSubTotal').val()) + parseFloat($('#txtTaxValue').val()));
    $('#txtTotalAmt').val($('#txtGrandTotal').val());
}

function fnFormSave() {
    var rows = $("#productList tbody tr");
    for (var i = 0; i < rows.length; i++) {
        $('#tempProductDetail').append("<input type='text' name='ProductDetail[" + i + "].ProductID'  \
            value = '" + rows[i].cells[0].innerText + "' /> ");
        $('#tempProductDetail').append("<input type='text' name='ProductDetail[" + i + "].Qty'  \
            value = '" + rows[i].cells[3].innerText + "' /> ");
        $('#tempProductDetail').append("<input type='text' name='ProductDetail[" + i + "].PricePerUnit'  \
            value = '" + rows[i].cells[4].innerText + "' /> ");
        $('#tempProductDetail').append("<input type='text' name='ProductDetail[" + i + "].Amount'  \
            value = '" + rows[i].cells[5].innerText + "' /> ");
    }
    return true;
}