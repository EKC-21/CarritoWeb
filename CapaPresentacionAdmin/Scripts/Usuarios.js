var tabladata;
var filaSelecionada;

window.onload = function () {
    CargarDatos();
};

function CargarDatos() {
    tabladata = $("#tablaUsuarios").DataTable({
        responsive: true,
        ordering: false,
        "ajax": {
            //url: '@Url.Action("ListarUsuarios", "Home")',
            url: "../Home/ListarUsuarios",
            type: "GET",
            dataType: "json"
        },
        "columns": [
            { "data": "Nombre" },
            { "data": "Apellidos" },
            { "data": "Correo" },
            {
                "data": "Activo", "render": function (valor) {
                    if (valor) {
                        return '<span class="badge bg-success">Si</span>'
                    } else {
                        return '<span class="badge bg-danger">No</span>'
                    }

                }
            },
            {
                "defaultContent": '<button type="button" class="btn btn-primary btn-sm btn-editar"><i class="fas fa-pen"></i></button>' +
                    '<button type="button" class="btn btn-danger  btn-sm btn-eliminar"><i class="fas fa-trash"></i></button>',
                "orderable": false,
                "searchable": false,
                "width": 90
            }
        ],
        /*permite traducir a español los componentes de datatble*/
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.12.1/i18n/es-ES.json"
        }
    });

    $("#tablaUsuarios tbody").on("click", '.btn-editar', function () {
        filaSelecionada = $(this).closest("tr");
        var data = tabladata.row(filaSelecionada).data();

        console.log(data);
        AbrirModal(data);

    })
    $("#tablaUsuarios tbody").on("click", '.btn-eliminar', function () {
        filaSelecionada = $(this).closest("tr");
        var data = tabladata.row(filaSelecionada).data();

        console.log(data);
        AbrirModalEliminar(data);

    })
}
function AbrirModal(json) {
    $("#txtId").val(0);
    $("#txtNombre").val("");
    $("#txtApellidos").val("");
    $("#txtCorreo").val("");
    $("#cboActivo").val(1)

    if (json != null) {
        $("#txtId").val(json.IdUsuario);
        $("#txtNombre").val(json.Nombre);
        $("#txtApellidos").val(json.Apellidos);
        $("#txtCorreo").val(json.Correo);
        $("#cboActivo").val(json.Activo == true ? 1 : 0)
    }
    $("#ModalUsuarios").modal("show");
}
function AbrirModalEliminar(json) {
    $("#txtId").val(0);
    $("#txtNombre").val("");
    $("#txtApellidos").val("");
    $("#txtCorreo").val("");
    $("#cboActivo").val(1)

    if (json != null) {
        $("#txtId").val(json.IdUsuario);
        $("#txtNombre").val(json.Nombre);
        $("#txtApellidos").val(json.Apellidos);
        $("#txtCorreo").val(json.Correo);
        $("#cboActivo").val(json.Activo == true ? 1 : 0)
    }
    Eliminar();
}

function Guardar() {
    var Usuario = {
        IdUsuario: $("#txtId").val(),
        Activo: $("#cboActivo").val() == 1 ? true : false,
        Apellidos: $("#txtApellidos").val(),
        Correo: $("#txtCorreo").val(),
        Nombre: $("#txtNombre").val()
    }
    jQuery.ajax({
        url: "../Home/GuardarUsuarios",
        type: "POST",
        data: JSON.stringify({ usuario: Usuario }),
        dataType: "json",
        contentType: "application/json; chartset-UTF-8",
        success: function (data) {
            if (data.msg == "Usuario Registrado correctamente.") {
                tabladata.row.add(Usuario).draw(false);
                //CargarDatos();
            }
            else {

            }
            alert(data.msg);
            $("#ModalUsuarios").modal("hide");
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },

    });
    location.reload();
}
function Eliminar() {
    var Usuario = {
        IdUsuario: $("#txtId").val(),
        Activo: $("#cboActivo").val() == 1 ? true : false,
        Apellidos: $("#txtApellidos").val(),
        Correo: $("#txtCorreo").val(),
        Nombre: $("#txtNombre").val()
    }
    jQuery.ajax({
        url: "../Home/EliminarUsuarios",
        type: "POST",
        data: JSON.stringify({ usuario: Usuario }),
        dataType: "json",
        contentType: "application/json; chartset-UTF-8",
        success: function (data) {
            if (data.msg == "Usuario Eliminado correctamente.") {
                tabladata.row.add(Usuario).draw(false);
                //CargarDatos();
            }
            else {

            }
            alert(data.msg);
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },

    });
    location.reload();
}





