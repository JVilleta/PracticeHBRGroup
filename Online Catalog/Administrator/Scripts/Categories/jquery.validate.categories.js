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
    request.get("/Categories/CategoriesList", function (result) {
        var html = '';
        $.each(result, function (key, item) {
            html += '<tr>';
            html += '<td>' + item.Id + '</td>';
            html += '<td>' + item.CategoryCode + '</td>';
            html += '<td>' + item.CategoryName + '</td>';
            html += '<td>' + item.Descriptions + '</td>';
            html += '<td>' + (item.Status ? 'Inactivo' : 'Activo') + '</td>';
            html += '<td>' + item.Author + '</td>';
            html += '<td>' + item.CreationDate + '</td>';
            html += '<td>' + item.UpdateDate + '</td>';
            html += '<td><a href="#" class="btn btn-outline-primary" onclick="return LoadModalUpdate(' + item.Id + ')"><i class="bi bi-arrow-clockwise"></i>Actualizar</a>' +
                '  <a href="#" class="btn btn-outline-danger" onclick="ProductDelete(' + item.Id + ')"> <i class="bi bi-trash-fill"></i>Eliminar</a></td>';
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

        CategoryCode: $('#CategoryCode').val(),
        CategoryName: $('#CategoryName').val(),
        Descriptions: $('#Descriptions').val(),
        Status: $('#Status').val()
    };

    request.post("/Categories/CategoriesAdd", productObj, function (result) {
        $("#myModal .close").click();
        loadData();
        CleanModal();
    });
}

function LoadModalUpdate(Id) {
    request.get("/Categories/CategoriesByID/" + Id, function (result) {
        $('#Id').val(result.Id);
        $('#CategoryCode').val(result.CategoryCode);
        $('#CategoryName').val(result.CategoryName);
        $('#Descriptions').val(result.Descriptions);
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
        CategoryCode: $('#CategoryCode').val(),
        CategoryName: $('#CategoryName').val(),
        Descriptions: $('#Descriptions').val(),
        Status: $('#Status').val()
    };

    request.post("/Categories/CategoriesUpdate", productObj, function (result) {
        loadData();
        CleanModal();
        $("#myModal .close").click();
        $('#Id').val("");
        $('#CategoryCode').val("");
        $('#CategoryName').val("");
        $('#Descriptions').val("");
        $('#Status').val("");
    });
}

function DeleteProducts(Id) {
    var ans = confirm("Seguro que desea eliminar este producto?");
    if (ans) {
        request.post("/Categories/CategoriesDelete/" + Id, null, function (result) {
            if (result)
                alert('Esta categoria posee productos asociados');

            loadData();
        });
    }
}

function CleanModal() {
    $('#Id').val("");
    $('#CategoryCode').val("");
    $('#CategoryName').val("");
    $('#Status').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
}

function ValidateFilds() {

    var validation = $("#form").validate({
        rules: {
            id: 'required',
            categorycode: 'required',
            categoryname: 'required',
            desciption: 'required',
            status: 'required',
        },
        messages: {
            id: 'Este campo es requerido',
            categorycode: 'Este campo es requerido',
            categoryname: 'Este campo es requerido',
            description: 'Este campo es requerido',
            stock: { required: 'Este campo es requerido', digits: 'Solo se aceptan numeros' },
            status: 'Este campo es requerido',
        },
    });

    if (validation.form()) {
        return true;
    }

    return false;
}  