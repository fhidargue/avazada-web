function idSubscripcion(id) {
    let subscripcion = document.getElementById('deleteSubscripcion');
    subscripcion.value = id;
}

const getId = e => {

    console.clear();
    let id;
    if (e.target.tagName == "I") {

        id = e.target.parentElement.id;

    } else {

        id = e.target.id;

    }

    $.ajax({

        url: "Subscripcion/GetSubscripcion",
        type: "POST",
        dataType: "json",
        data: {
            id
        },

        success(datos) {

            const { idUsuario, fechaInicio, fechaFin, metodoPago, monto, idSubscripcion } = datos;

            console.log(datos);

            const inputs = document.querySelectorAll('.editar');

            inputs[0].value = idUsuario;
            inputs[1].value = fechaInicio;
            inputs[2].value = fechaFin;
            inputs[3].value = metodoPago;
            inputs[4].value = monto;

            const hidden = document.getElementById("IdSubscripcion");

            hidden.value = idSubscripcion;

            console.log(hidden);
        },
        error(error) {
            console.log(datos);
        }
    });
}

const botones_edit = document.querySelectorAll('.edit');

botones_edit.forEach(boton => boton.addEventListener('click', getId));