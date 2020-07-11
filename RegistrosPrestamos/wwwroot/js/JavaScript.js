
function PrestamoConfirm(titulo, mensaje, tipo) {
    return new Promise((resolve) => {

        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, eliminar prestamo',
            closeOnClickOutside: false,
            allowOutsideClick: false
        }).then((result) => {
            if (result.value) {
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}

function ConfirmDelete() {

    var Respuesta = confirm("Permitir notificaciones de este sitio en su computador");

    return Respuesta;
}

function Permiso() {
    if (Notification.permission !== "granted")
        return Notification.requestPermission();
    else
        return false;
}

function NotificarBienvenido() {

    if (Notification.permission !== "granted")
        Notification.requestPermission();
    else {
        var notification = new Notification(
        "Ferreteria FBF",
            {
            icon: "LOGO.jpg",
            body : "Bienvenido al sistema"
        }
    );
    }
        

}

function NotificarEliminar() {

    var notification = new Notification(
        "Ferreteria FBF",
        {
            icon: "LOGO.jpg",
            body: "Se ha eliminado un usuario del sistema"
        }
    );

}

function NotificarGuardado() {

    Notification.requestPermission();

    var notification = new Notification(
        "Ferreteria FBF",
        {
            icon: "LOGO.jpg",
            body: "Se ha guardado un prestamo en el sistema",
            
        }
    );

}


