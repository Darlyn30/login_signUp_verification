// conexion a la API

const URL = "https://localhost:7225/api/SendEmail/cuentas";


const button = document.querySelector(".verify-button");
function moveToNext(current, nextFieldID) {
    if (current.value.length === 1) {
      document.getElementById(nextFieldID).focus(); // hace que cada vez que se entra un digito del codigo, cambie el 
      //enfoque al siguiente
    }
}



function verificarCodigo() {
    const code = Array.from(document.querySelectorAll('.code-input')).map(input => input.value).join('');
    fetch(URL)
    .then(res=>res.json())
    .then(data => {
        for(let i = 0; i < data.length; i++){
            if(code == data[i].pin){
                editarModel(data[i].clave, data[i].email, true, data[i].nombre);
            } else {
                alert("Codigo de verificacion no valido");
            }
        }
    })    

}

function editarModel(pass, mail, estatus, nombre){

    const model = {
        "clave": pass,
        "email": mail,
        "estatus" : estatus,
        "nombre": nombre,
        "pin": "",
    };

    fetch(URL, {
        method : "PUT",
        headers: {
          'Content-Type' : 'application/json'
        },
        body : JSON.stringify(model)
    })
    .then(res => {
        console.log("success", res);
        alert("Cuenta verificada");
        window.location = "../index.html";
    })
}


button.addEventListener("click", () => {
    verificarCodigo();
})