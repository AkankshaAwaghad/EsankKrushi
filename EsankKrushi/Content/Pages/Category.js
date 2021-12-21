var saveCategory = function () {
    var id = $("#hdnId").val();
    var productcategory = $("#txtProductCategory").val();
    
    var model = {
        Id: id,
        ProductCategory: productcategory
    };

    $.ajax({
        url: "/Category/SaveCategory",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("successfully");
        }
    })
};
