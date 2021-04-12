


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
   
            const { apellidos, cedula, email, idRol, idSucursal, nombre, telefono  } = datos;

            const inputs = document.querySelectorAll('.editar');


            inputs[0].value = cedula;
            inputs[1].value = nombre;
            inputs[2].value = apellidos;
            inputs[3].value = email;
            inputs[4].value = telefono;
            inputs[5].value = idRol;
            inputs[6].value = idSucursal;


        },

        error(error) {

            console.log(datos);

        }

    });
   



}

const botones_edit = document.querySelectorAll('.edit');

botones_edit.forEach(boton => boton.addEventListener('click', getId));


