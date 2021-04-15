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

            const { descripcion, intensidad, equipo } = datos;

            const inputs = document.querySelectorAll('.editar');


            inputs[0].value = descripcion;
            inputs[1].value = intensidad;
            inputs[2].value = equipo;
          

        },

        error(error) {

            console.log(datos);

        }

    });




}
    const botones_edit = document.querySelectorAll('.edit');

    botones_edit.forEach(boton => boton.addEventListener('click', getId));