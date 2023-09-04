
$(function () {
    $(document).ready(function () {
        loadData("/Home/ProductsList");
    });

    $("#input-productName").keyup(function (event) {
        loadData("/Home/GetByName/" + event.target.value);
    });

    $("#select-idCategory").change(function () {
        loadData("/Home/GetListProductsByCategory/" + $(this).val());
    });
});


function loadData(url) {
    request.get(url, function (result) {
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
            html += '<td><a href="#" class="btn btn-outline-info" onclick="return getbyID(' + item.Id + ')"><i class="bi bi-eye-fill"></i> Ver detalles</a></td>';
            html += '</tr>';
        });
        $('.tbody').html(html);
    });
}


function getbyID(id) {
    request.get("/Home/ProductsById/" + id, function (result) {
        $('#ProductId').val(result.Id);
        $('#ProductName-modal').text(result.ProductName)
        $('#Stock-modal').text(result.Stock)
        $('#Category-modal').text(result.Category.CategoryName)
        $('#myModal').modal('show');
    });
    return false;
}