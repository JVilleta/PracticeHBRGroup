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
                var doc = $.parseHTML(error.responseText);
                var titleNode = doc.filter(function (node) {
                    return node.localName === "title";
                });
               alert(titleNode[0].textContent);
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
                var doc = $.parseHTML(error.responseText);
                var titleNode = doc.filter(function (node) {
                    return node.localName === "title";
                });
                alert(titleNode[0].textContent);
            }
        });
    }
}