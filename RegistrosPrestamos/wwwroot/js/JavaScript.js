
function PrestamoConfirm(titulo, mensaje, tipo) {
    return new Promise((resolve) => {

        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {
                resolve(true);
            } else {
                resolve(false);
            }
        });
    });
}