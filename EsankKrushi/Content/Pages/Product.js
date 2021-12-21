var saveProd = function () {
    var id = $("#lblProductId").val();
    var productname = $("#txtproductName").val();
    var productcategory = $("#txtproductCategory").val();
    var productprice = $("#txtproductPrice").val();
    var productduration = $("#txtproductDuration").val();
    var productimage = $("#txtproductImage").val();
    
    alert("Successfully");
    var model = {
        ProductId:id,
        ProductName: productname,
        ProductCategory: productcategory,
        ProductPrice: productprice,
        ProductDuration: productduration,
        ProductImage: productimage,
    };

    $.ajax({
        url: "/Product/Saveproduct",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Successfully");
        }
    })
};