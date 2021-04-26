function idSucursal(id) {
    let sucursal = document.getElementById('deleteSucursal');
    sucursal.value = id;
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

        url: "Sucursal/GetSucursal",
        type: "POST",
        dataType: "json",
        data: {
            id
        },

        success(datos) {


            const { idSucursal, sede, telefono, email, direccion } = datos;

            const inputs = document.querySelectorAll('.editar');


            inputs[0].value = sede;
            inputs[1].value = direccion;
            inputs[2].value = telefono;
            inputs[3].value = email;

            const hidden = document.getElementById("IdSucursal");
            hidden.value = idSucursal;

        },

        error(error) {

            console.log(error);

        }

    });




}
const botones_edit = document.querySelectorAll('.edit');

botones_edit.forEach(boton => boton.addEventListener('click', getId));