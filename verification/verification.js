// conexion a la API

const URL = "https://localhost:7225/api/Trigger/cuenta_nueva"; // debe borrar desde aqui luego de verificar


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
    .then(res => res.json())
    .then(data => {
        for(let i = 0; i < data.length; i++){
            if(code == data[i].pin){
                deleteD(data[i].email);
            } else {
                alert("Codigo de verificacion no valido");
            }
        }
    })
}


function deleteD(email){
    const urlD = `https://localhost:7225/api/Trigger/cuenta_nueva?correo=${encodeURIComponent(email)}`;//para eliminar desde aqui despues de verificar
    
    fetch(urlD, {
        method: "DELETE",
        headers : {
          'Content-Type' : 'application/json'
        },
    })
    .then(res => {
        console.log("success", res);

        swal({
            title: "Cuenta verificada exitosamente!",
            text: `Puedes iniciar sesion`,
            icon: "success",
        })
        .then(res => {
            window.location = "../index.html";
        })
    })
}

button.addEventListener("click", () => {
    verificarCodigo();
})