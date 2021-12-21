
var saveCustomer = function () {
    var message = "";
    $formData = new FormData();
    var Photo = document.getElementById('file1');
    if (Photo.files.length > 0) {
        for (var i = 0; i < Photo.files.length; i++) {
            $formData.append('file-' + i, Photo.files[i]);
        }
    }
    var customername = $("#txtCustomerName").val();
    var customeraddress = $("#txtCustomerAddress").val();
    var customerdob = $("#txtDOB").val();
    var fieldarea = $("#txtFieldArea").val();
    var contactnumber = $("#txtContactNumber").val();
    var contactemail = $("#txtContactEmail").val();
    var aadharnumber = $("#txtAadharNumber").val();
    var bankaccountnumber = $("#txtBankAccountNumber").val();

    $formData.append('CustomerName', customername);
    $formData.append('CustomerAddress', customeraddress);
    $formData.append('CustomerDOB', customerdob);
    $formData.append('FieldArea', fieldarea);
    $formData.append('ContactNumber', contactnumber);
    $formData.append('ContactEmail', contactemail);
    $formData.append('AadharNumber', aadharnumber);
    $formData.append('BankAccountNumber', bankaccountnumber);
    $.ajax({
        url: "/Customer/SaveCustomer",
        method: "post",
        data: $formData,

        //data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        //dataType: "json",
        contentType: false,
        processData: false,

        success: function (response) {
            alert("submitted");
        }
    });
}