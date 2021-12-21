$(document).ready(function () {
    $("#txtCustomerName").focus();

    $("#txtCustomerName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Bill/SearchCustomer",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                   
                        return { label: item.CustomerName, value: item.CustomerName, id: item.ID, customeraddress: item.CustomerAddress, customernumber: item.CustomerNumber};
                    }))
                }
            })
        },
        minLength: 2,
        select: function (event, ui) {

            $("#txtCustomerAddress").val(ui.item.customeraddress);
            $("#txtCustomerNumber").val(ui.item.customernumber);
        }

    });
})


var saveBill = function () {
    var id = $("#lblID").val();
    var customername = $("#txtCustomerName").val();
    var customeraddress = $("#txtCustomerAddress").val();
    var date = $("#txtDate").val();
    var productname = $("#txtProductName").val();
    var price = $("#txtPrice").val();
    var noofunit = $("#txtNoofUnit").val();
    alert("Successfully");
    var model = {
        ID: id,
        CustomerName : customername,
        CustomerAddress : customeraddress,
        Date : date,
        ProductName : productname,
        Price : price,
        NoofUnit : noofunit
    };

    $.ajax({
        url: "/Bill/saveBill",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Successfully");
        }
    })
};

var getMainBillList = function () {
    var customername = $("#txtCustomerName").val();
    var model = { CustomerName: customername };
    $.ajax({
        url: "/Bill/GetBillList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblBill tbody").empty();
            $.each(response.model, function (index, elementValue) {"</td><td> "
                html += "<tr><td>" + elementValue.ID + "</td><td>" + elementValue.CustomerName + "</td><td>" + elementValue.CustomerAddress + "</td><td>" + elementValue.Date + "</td><td>" + elementValue.Price + "</td><td>" + elementValue.ProductName + "</td><td> " + elementValue.NoofUnit + "</td><td> "  + "</td></tr>";
            });
            $("#tblBill").append(html);
            $("#tblBill").DataTable();
        }
    });
}
var familyBill = function (id) {
    window.location.href = "/Bill/Index?ID=" + Id;
}




var deletebill = function (ID) {

    var model = {Id: ID };
        $.ajax({
        url: "/Bill/DeleteBill",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
                alert("Record Deleted Successfully ....");
        }
    });
}

var Editdata = function (ID) {

    var model = { Id: ID };
    alert("Record Edit Successfully ....");
    $.ajax({
        url: "/Bill/GetEditData ",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            $("#lblID").val(response.model.ID);
            $("#txtCustomerName").val(response.model.CustomerName);
            $("#txtCustomerAddress").val(response.model.CustomerAddress);
            $("#txtDate").val(response.model.Date);
            $("#txtProductName").val(response.model.ProductName);
            $("#txtPrice").val(response.model.Price);
            $("#txtNoofUnit").val(response.model.NoofUnit);
        }
    });
}
var ClearData = function () {

    $("#lblID").val("");
    $("#txtCustomerName").val("");
    $("#txtCustomerAddress").val("");
    $("#txtDate").val("");
    $("#txtProductName").val("");
    $("#txtPrice").val("");
    $("#txtNoofUnit").val("");
}





