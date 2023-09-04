$(function () {
    $('#btnAdd').on('click', function () {
        AddUser();
    });
    $('#btnUpdate').on('click', function () {
        UpdateUser();
    });
    $('#btn-login').on('click', function () {
        ValidateLoginUser();
    });

});

function AddUser() {
    var response = ValidateFilds();
    if (response == false) {
        return false;
    }
    var userObj = {
        UserName: $('#UserName').val(),
        LastName: $('#LastName').val(),
        Telephone: $('#Telephone').val(),
        Email: $('#Email').val(),
        Pass: $('#Password').val()
    };
    request.post("/Users/UsersAdd", userObj, function (result) {
        $("#succes-messege").show()
        setTimeout(function () {
            $("#succes-messege").hide();
        }, 4000);
        ClearFormRecord() 
    });
}

function ClearFormRecord() {
    $('#UserName').val(""),
    $('#LastName').val(""),
    $('#Telephone').val(""),
    $('#Email').val(""),
    $('#Password').val("")
}

function ValidateLoginUser() {
    var response = validateLogin();
    if (response == false) {
        return false;
    }
    var userObj = {
        Email: $('#Email').val(),
        Pass: $('#Password').val()
    };
    request.post("/Users/LoginValidate", userObj, function (result) {
        if (result.Id != 0) {
            window.location.href = "https://localhost:44314/Users/HomeView";
        }
        else {
            $("#danger-alert").show()
            setTimeout(function () {
                $("#danger-alert").hide();
            }, 4000);
        }
    });
}

function UpdateUser() {
    var response = ValidateFilds();
    if (response == false) {
        return false;
    }
    var userObj = {
        Id: $('#UserId-form').val(),
        UserName: $('#UserName-form').val(),
        LastName: $('#LastName-form').val(),
        Telephone: $('#Telephone-form').val(),
        Email: $('#Email-form').val(),
    };
    request.post("/Users/UsersUpdate", userObj, function (result) {
        $("#myModal .close").click();
        $("#succes-messege").show()
        setTimeout(function () {
            $("#succes-messege").hide();
        },4000);
    });
}

function ValidateFilds() {
    var validation = $("#form").validate({
        rules: {
            name: 'required',
            lastname: 'required',
            phone: { required: true, digits: true },
            email: { required: true, email: true },
            password: 'required',
        },
        messages: {
            name: 'Este campo es requerido',
            lastname: 'Este campo es requerido',
            phone: { required: 'Este campo es requerido', digits: 'Solo se aceptan numeros' },
            email: { required: 'Este campo es requerido', email: 'Email no valido' },
            password: 'Este campo es requerido',
        },
    });

    if (validation.form()) {
        return true;
    }

    return false;
}

function validateLogin() {
    var validation = $("#form").validate({
        rules: {
            email: 'required',
            password: 'required',
        },
        messages: {
            email: 'Este campo es requerido',
            password: 'Este campo es requerido',
        },
    });

    if (validation.form()) {
        return true;
    }

    return false;
}