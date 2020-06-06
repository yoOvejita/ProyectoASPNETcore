var dataTable;
$(document).ready(function () {
    cargarDatosDesdeTabla();
});

function cargarDatosDesdeTabla() {
    dataTable = $('#cargar_miTabla').DataTable({
        "ajax": {
            "url": "/api/Producto",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nombre", "width": "25%" },
            { "data": "precio", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/ListaDeProductos/Editar?id=${data}" class="btn btn-success text-white" style="cursor:pointer">Editar</a>
                                &nbsp;
                                <a class="btn btn-danger text-white" style="cursor:pointer" onclick="Eliminar('/api/Producto?id=' + ${data})">Eliminar</a>
                            </div>
                    `
                }, "width": "50%"
            }
        ],
        "language": {
            "emptyTable": "¡No hay ningun producto disponible!"
        },
        "width": "100%"
    })
}


function Eliminar(miUrl) {
    swal({
        title: "¿Estás seguro?",
        text: "Cuando elimines este registro, no hay vuelta atrás",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((eliminara) => {
        if (eliminara) {
            $.ajax({
                type: "DELETE",
                url: miUrl,
                success: function (dato) {
                    if (dato.success) {
                        toastr.success(dato.mensaje);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(dato.mensaje);
                    }
                }

            })
        }
    })
}