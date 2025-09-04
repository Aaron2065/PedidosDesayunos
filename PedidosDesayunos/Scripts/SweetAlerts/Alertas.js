// Mostrar alertas generales (guardar, actualizar, eliminar OK/error)
function mostrarAlerta(titulo, mensaje, tipo) {
    Swal.fire({
        title: titulo,
        text: mensaje,
        icon: tipo,
        confirmButtonText: 'Aceptar'
    });
}

// Confirmación para eliminar con SweetAlert2
document.addEventListener("DOMContentLoaded", function () {
    const botonesEliminar = document.querySelectorAll(".eliminarCategoria");
    botonesEliminar.forEach(btn => {
        btn.addEventListener("click", function (e) {
            e.preventDefault(); // Evita postback directo

            Swal.fire({
                title: "¿Estás seguro?",
                text: "Esta acción no se puede deshacer",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#d33",
                cancelButtonColor: "#3085d6",
                confirmButtonText: "Sí, eliminar",
                cancelButtonText: "Cancelar"
            }).then((result) => {
                if (result.isConfirmed) {
                    // Forzar el postback al botón específico
                    __doPostBack(btn.getAttribute("name"), "");
                }
            });
        });
    });
});
