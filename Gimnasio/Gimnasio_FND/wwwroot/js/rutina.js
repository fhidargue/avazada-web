const getId = e => {

    console.clear();
    let id;
    if (e.target.tagName == "I") {
        id = e.target.parentElement.id;
    } else {
        id = e.target.id;
    }

    $.ajax({
        url: "Rutina/GetRutinaEjercicio",
        type: "POST",
        dataType: "json",
        data: {
            id
        },
        success(datos) {

            const { idRutinaEjercicio, repeticiones, series, idEjercicio } = datos;
            const inputs = document.querySelectorAll('.editar');

            inputs[0].value = datos.idEjercicioNavigation.descripcion;
            inputs[1].value = repeticiones;
            inputs[2].value = series;

            const hidden = document.getElementById("idEjercicioEdit");
            hidden.value = idEjercicio;

            const hiddenRutinaEjericio = document.getElementById("IdRutinaEjercicio");
            hiddenRutinaEjericio.value = idRutinaEjercicio;
        },

        error(error) {

            console.log(error);

        }

    });

}
const botones_edit = document.querySelectorAll('.edit');

botones_edit.forEach(boton => boton.addEventListener('click', getId));