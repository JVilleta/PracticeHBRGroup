var request = {
    post: function (url, params, method) {
        $.ajax({
            url: url,
            data: JSON.stringify(params),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                method(result);
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    },

    get: function (url, method) {
        $.ajax({
            url: url,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                method(result);
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    }
}