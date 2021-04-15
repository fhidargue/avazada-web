function crearMedida(url) {

    let usuario = $('#usuario_create').val();
    let peso = $('#peso_create').val();
    let masa = $('#masa_create').val();
    let grasa = $('#grasa_create').val();
    let altura = $('#altura_create').val();

    $.ajax({
        type: 'POST',
        url: url,
        data: {
            IdUsuario: usuario,
            Peso: peso,
            PorcentajeMasa: masa,
            PorcentajeGrasa: grasa,
            Altura: altura
        },
        dataType: 'html',
        cache: false,
        success: function (data) {
            setTimeout(function () {
                alert("Usuario agregado con éxito.");
                location.reload();
            }, 100);
        },
        error: function (data) {
            alert("Se presentó un problema.");
        }
    });
}