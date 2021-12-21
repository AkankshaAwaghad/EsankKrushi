var saveOrder = function () {
    var id = $("#lbld").val();
    var productcategory = $("#txtProductcategory").val();
    var productname = $("#txtProductname").val();
    var unittopurchase = $("#txtUnittopurchase").val();
    var distributorname = $("#txtDistributorname").val();
    var distributoraddress = $("#txtDistributoraddress").val();
    var rateofpreviousorder = $("#txtRateofpreviousorder").val();
    alert("Successfully");
    var model = {
        Id: id,
        Productcategory: productcategory,
        Productname: productname,
        Unittopurchase: unittopurchase,
        Distributorname: distributorname,
        Distributoraddress: distributoraddress,
        Rateofpreviousorder: rateofpreviousorder,
    };

    $.ajax({
        url: "/Order/SaveOrder",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Successfully");
        }
    })
};