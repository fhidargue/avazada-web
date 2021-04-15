function crearSucursal(url) {

    let sede = $('#sede_create').val();
    let telefono = $('#telefono_create').val();
    let email = $('#email_create').val();
    let direccion = $('#direccion_create').val();

    $.ajax({
        type: 'POST',
        url: url,
        data: {
            Sede: sede,
            Telefono: telefono,
            Email: email,
            Direccion: direccion
        },
        dataType: 'html',
        cache: false,
        success: function (data) {
                setTimeout(function () {
                    alert("Sucursal agregada con éxito.");
                    location.reload();
                }, 100);
        },
        error: function (data) {
            alert("Se presentó un problema.");
        }
    });
}