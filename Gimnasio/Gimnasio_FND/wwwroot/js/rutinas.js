function crearRutina(url) {

    let descripcion = $('#descripcion_create').val();
    let usuario = $('#usuario_create').val();
    let entreno = $('#entreno_create').val();
    let fecha = $('#fecha_create').val();

    $.ajax({
        type: 'POST',
        url: url,
        data: {
            Descripcion: descripcion,
            IdUsuarioCliente: usuario,
            IdUsuarioEntrenador: entreno,
            FechaAsignacion: fecha
        },
        dataType: 'html',
        cache: false,
        success: function (data) {
            setTimeout(function () {
                alert("Rutina agregada con éxito.");
                location.reload();
            }, 100);
        },
        error: function (data) {
            alert("Se presentó un problema.");
        }
    });
}