
const getId = e => {

    console.clear();
    let id;
    if (e.target.tagName == "I") {

        id = e.target.parentElement.id;

    } else {

        id = e.target.id;

    }

    $.ajax({

        url: "Usuario/GetUsuario",
        type: "POST",
        dataType: "json",
        data: {
            id
        },

        success(datos) {



            const { apellidos, cedula, email, idRol, idSucursal, nombre, telefono, idUsuario } = datos;

            const inputs = document.querySelectorAll('.editar');


            inputs[0].value = cedula;
            inputs[1].value = nombre;
            inputs[2].value = apellidos;
            inputs[3].value = email;
            inputs[4].value = telefono;
            inputs[5].value = idRol;
            inputs[6].value = idSucursal;

            const hidden = document.getElementById("IdUsuario");

            hidden.value = idUsuario;

            console.log(hidden);

            //document.getElementById("IdUsuario").value = IdUsuario;


        },

        error(error) {

            console.log(datos);

        }

    });




}

const botones_edit = document.querySelectorAll('.edit');

botones_edit.forEach(boton => boton.addEventListener('click', getId));





const selectRol = () => {
    const value = IdRol.value;
    const entrenador = document.getElementById("entrenador");
    if (value == 3) {
        entrenador.removeAttribute("hidden")
    } else {
        entrenador.setAttribute("hidden", "")
    }

}

const IdRol = document.getElementById("rol_create");
IdRol.addEventListener("change", selectRol)