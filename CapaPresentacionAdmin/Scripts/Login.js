$("#btnLogin").on("click", function () {
    Login();
});

function Login() {
    var Usuario = {
        Correo: $("#userName").val(),
        Clave: $("#pwd").val()
    }
    jQuery.ajax({
        url: "../Login/Login",
        type: "POST",
        data: JSON.stringify({ usuario: Usuario }),
        dataType: "json",
        contentType: "application/json; chartset-UTF-8",
        success: function (data) {
            if (data.msg == "") {
                window.location.href = "../Home/Usuarios";
            }
            else {
                alert(data.msg);
            }            
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },

    });

}