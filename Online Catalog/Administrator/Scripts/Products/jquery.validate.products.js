$(function () {
    loadData();
    $('#btnAdd').on('click', function () {
        AddProducts();
    });
    $('#btnUpdate').on('click', function () {
        UpdateProducts();
    });
});


function loadData() {
    request.get("/Products/ProductsList", function (result) {
        var html = '';
        $.each(result, function (key, item) {
            html += '<tr>';
            html += '<td>' + item.Id + '</td>';
            html += '<td>' + item.ProductCode + '</td>';
            html += '<td>' + item.ProductName + '</td>';
            html += '<td>' + item.Stock + '</td>';
            html += '<td>' + item.Author + '</td>';
            html += '<td>' + item.CreationDate + '</td>';
            html += '<td>' + item.UpdateDate + '</td>';
            html += '<td>' + item.Category.CategoryName + '</td>';
            html += '<td><a href="#" class="btn btn-outline-primary" onclick="return LoadModalUpdate(' + item.Id + ')"><i class="bi bi-arrow-clockwise"></i>Actualizar</a>' +
                '  <a href="#" class="btn btn-outline-danger" onclick="DeleteProducts(' + item.Id + ')"> <i class="bi bi-trash-fill"></i>Eliminar</a></td>';
            html += '</tr>';
        });
        $('.tbody').html(html);
    });
}

function AddProducts() {
    var response = ValidateFilds();
    if (response == false) {
        return false;
    }
    var productObj = {

        ProductCode : $('#Codigo').val(),
        ProductName : $('#Name').val(),
        Stock : $('#Stock').val(),
        IdCategory : $('#Id_Category').val(),
        Status : $('#Status').val()
    };

    request.post("/Products/ProductsAdd", productObj, function (result) {
        $("#myModal .close").click();
        loadData();
        CleanModal();
    });
}

function LoadModalUpdate(Id) {
    request.get("/Products/ProductsByID/" + Id, function (result) {
        $('#Id').val(result.Id);
        $('#Codigo').val(result.ProductCode);
        $('#Name').val(result.ProductName);
        $('#Stock').val(result.Stock);
        $('#Id_Category option:contains("' + result.Category.CategoryName + '")').prop('selected', true);
        $(`#Status option[value='${result.Status}']`).prop('selected', true);

        $('#myModal').modal('show');
        $('#btnUpdate').show();
        $('#btnAdd').hide();
    });
    return false;
}

function UpdateProducts() {
    var response = ValidateFilds();

    if (response == false)
        return false;
    
    var productObj = {
        Id: $('#Id').val(),
        ProductCode : $('#Codigo').val(),
        ProductName: $('#Name').val(),
        Stock: $('#Stock').val(),
        IdCategory: $('#Id_Category').val(),
        Status: $('#Status').val()
    };

    request.post("/Products/ProductsUpdate", productObj, function (result) {
        loadData();
        CleanModal();
        $("#myModal .close").click();
        $('#Id').val("");
        $('#Codigo').val("");
        $('#Id_Category').val("");
        $('#Name').val("");
        $('#Stock').val("");
        $('#Status').val("");
    });
}

function DeleteProducts(Id) {
    var ans = confirm("Seguro que desea eliminar este producto?");
    if (ans) {
        request.post("/Products/ProductsDelete/Id" + Id, null, function (result) {
            loadData();
        });
    }
}

function CleanModal() {
    $('#Id_Product').val("");   
    $('#Name').val("");
    $('#Stock').val("");
    $('#Id_Category').val("");
    $('#Status').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
}

function ValidateFilds() {

    var validation = $("#form").validate({
        rules: {
            id_category: 'required',
            name: 'required',
            stock: { required: true, digits: true },
            status: 'required',
        },
        messages: {
            id_category: 'Este campo es requerido',
            name: 'Este campo es requerido',
            stock: { required: 'Este campo es requerido', digits: 'Solo se aceptan numeros' },
            status: 'Este campo es requerido',
        },
    });

    if (validation.form()) {
        return true;
    }

    return false;
}  