function idEjercicio(id) {
    let ejercicio = document.getElementById('deleteEjercicio');
    ejercicio.value = id;
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

        url: "Ejercicio/GetEjercicio",
        type: "POST",
        dataType: "json",
        data: {
            id
        },

        success(datos) {

            const { descripcion, intensidad, equipo, idEjercicio } = datos;

            const inputs = document.querySelectorAll('.editar');


            inputs[0].value = descripcion;
            inputs[1].value = equipo;
            inputs[2].value = intensidad;

            const hidden = document.getElementById("IdEjercicio");
            hidden.value = idEjercicio;

        },

        error(error) {

            console.log(datos);

        }

    });

}
const botones_edit = document.querySelectorAll('.edit');

botones_edit.forEach(boton => boton.addEventListener('click', getId));