$(document).ready(function () {
    $('#btnAddCategory').show();
    $('#btnAddProduct').hide();
    $('#divCategory').hide();
    $('#divProduct').hide();
    $('#divProductTable').hide();

    $('table.display').DataTable();

    //$('#tblCategory').DataTable({
    //    destroy: true,
    //    pagingType: 'full_numbers',
    //});
    //$('#divProductTable').DataTable({
    //    destroy: true,
    //    pagingType: 'full_numbers',
    //});
});

$("#btnAddCategory").click(function () {
    
    $('#divCategory').show();
  //  $('#divProduct').hide();

    
})
$("#btnAddProduct").click(function () {
    
    $('#divCategory').hide();
    $('#btnAddCategory').hide();
    $('#divProduct').show();
    $('#btnAddProduct').show();
    //  $('#divProduct').hide();


})

$("#btnCategotyMaster").click(function () {
    
    $('#btnAddCategory').show();
    $('#btnAddProduct').hide();
    $('#divCategory').hide();
    $('#divProductTable').hide();
    $('#divCategoryTable').show();
    $('#divProduct').hide();
    
    //window.location.href = '/Home/Index';    
   // window.location.href = '/Home/Index';    
});

$("#btnProductMaster").click(function () {
   
    $('#btnAddCategory').hide();
    $('#btnAddProduct').show();
    $('#divProductTable').show();
    $('#divCategoryTable').hide();
    $('#divCategory').hide();
});

$("#btnCategorySubmit").click(function () {
    debugger;
    var CategoryID = localStorage.getItem("CategoryID");
    var CategoryName = $('#txtCategoryName').val();
    var Method;
    if (CategoryID == "" || CategoryID == null || CategoryID === undefined) {
        CategoryID = 0;
        Method = 'INSERT';
    }
    else {
        Method = 'UPDATE'
    }
    if (CategoryName == "") {
        $('#lblCategoryError').text('Please Enter Category Name');
        return false;
    }
    else {
        $('#lblCategoryError').text('');

        var jsonObject = {
            CategoryName: CategoryName,
            CategoryID: CategoryID,
            Method: Method,
        };
        $.ajax({
            type: 'POST',
            async: false,
            url: '/Home/AddUpdateCategoryMaster',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(jsonObject),
            dataType: 'json',
            success: function (msg) {
                localStorage.clear();
               // var data = JSON.parse(msg);
                $('#txtCategoryName').val('');
                console.log("msg", msg);
               // $('#succesufullMsg').modal('show');
                alert(msg);
                window.location.href = '/Home/Index';    
              //  window.URL = '\Home\Index';
                
            }
        });
    }
    //$('#divCategory').show();
    //$('#divProduct').hide();
});


$("#btnProductSubmit").click(function () {
    debugger;
    var ProductID = localStorage.getItem("ProductID");
    var ProductName = $('#txtProductName').val();
    var CategoryID = $('#drpCtg').val();
    var Method;
    if (ProductID == "" || ProductID == null || ProductID === undefined) {
        ProductID = 0;
        Method = 'INSERT';
    }
    else {
        CategoryID =0
        Method = 'UPDATE'
    }
    if (ProductName == "") {
        $('#lblProductError').text('Please Enter Product Name');
        return false;
    }
    if (Method == "INSERT" && CategoryID == "") {
        
            $('#lblddlCategoryError').text('Please Select Category Name');
            return false;
        
    }
    else {
        $('#lblProductError').text('');
        $('#lblddlCategoryError').text('');
        var jsonObject = {
            ProductID: ProductID,
            ProductName: ProductName,
            CategoryID: CategoryID,
            Method: Method,
        };
        $.ajax({
            type: 'POST',
            async: false,
            url: '/Home/AddUpdateProductMaster',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(jsonObject),
            dataType: 'json',
            success: function (msg) {
                localStorage.clear();
                // var data = JSON.parse(msg);
                $('#txtProductName').val('');
                $('#drpCtg').prop('selectedIndex', 0);
                console.log("msg", msg);
                // $('#succesufullMsg').modal('show');
                alert(msg);
                window.location.href = '/Home/Index';
                //  window.URL = '\Home\Index';

            }
        });
    }
    //$('#divCategory').show();
    //$('#divProduct').hide();
});

$("#divCategoryTable").on('click', '#EditCategoryDetails', function () {
    debugger;
    $('#divCategory').show();
    // get the current row
    var currentRow = $(this).closest("tr");

    var CategoryID = currentRow.find("td:eq(0)").text(); // get current row 1st TD value
    var CategoryName = currentRow.find("td:eq(1)").text(); // get current row 2nd TD
    $('#txtCategoryName').val(CategoryName);
    localStorage.setItem("CategoryID", CategoryID);
    
    
});

$("#tbl_Product").on('click', '#EditProductDetails', function () {
    debugger;
    $('#divProduct').show();
    // get the current row
    var currentRow = $(this).closest("tr");

    var ProductID = currentRow.find("td:eq(0)").text(); // get current row 1st TD value
    var ProductName = currentRow.find("td:eq(1)").text(); // get current row 2nd TD
    var CategoryName = currentRow.find("td:eq(3)").text(); // get current row 2nd TD
    $('#txtProductName').val(ProductName);
    $('#drpCtg option:selected').text(CategoryName);//.trigger('chosen:updated');
    $("#drpCtg").prop("disabled", true);
   // $('#drpCtg).attr("selected", "selected");
  /*  $("#drpCtg option[value='Adidas Shoes']").attr("selected", "selected");*/
   // $("#drpCtg").val(CategoryName).attr("selected", "selected");

    localStorage.setItem("ProductID", ProductID);


});