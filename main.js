// conexion a la API

const URL = "https://localhost:7225/api/SendEmail/cuentas"; //para registrarse y para loguearseutilizare esta url

const container = document.getElementById('container');
const registerBtn = document.getElementById('register');
const loginBtn = document.getElementById('login');


const login = {
    email: document.querySelector("mailLog"),
    pass: document.querySelector("PassLog"),
}

const inputs = {
    mailLog: document.querySelector(".mailLog"),
    passLog: document.querySelector(".passLog"),
    nombreSign: document.querySelector(".nombreSign"),
    mailSign: document.querySelector(".mailSign"),
    passSign: document.querySelector(".passSign"),
    passConfirmSign: document.querySelector(".passConfirmSign"),
    nombreSign: document.querySelector(".nombreSign"),
    
}

const btns = {
    btnLog: document.querySelector(".btnLog"),
    btnSign: document.querySelector(".btnSign"),
}

fetch(URL)
.then(res => res.json())
.then(data => {
    console.log(data);
})

//login completado

function iniciarSesion(){
    let mail = inputs.mailLog.value;
    let pass = inputs.passLog.value;

}



function registrarse(){

    let nombre = inputs.nombreSign.value;
    let mail = inputs.mailSign.value;
    let pass = inputs.passSign.value;
    let confirm = inputs.passConfirmSign.value;


    const model = {
        "clave": pass,
        "email": mail,
        "estatus" : false,
        "nombre": nombre,
        "pin" : "",
    };

    if(pass == confirm){ // si las 2 contrase?as son iguales procede a crear la cuenta
        fetch(URL, {
            method: "POST",
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify(model)
        })
        .then(res => {
    
            if(nombre == "" || mail == "" || pass == "" || confirm == ""){
                swal({
                    title: "ERROR!",
                    text: "no puede haber campos vacíos \n O no podemos encontrar su cuenta \n O crea una",
                    icon: "warning",
                })
            } else {
                console.log("success", res);
        
                swal({
                    title: "Cuenta creada con exito!",
                    text: "Su cuenta ha sido creada exitosamente!",
                    icon: "success",
                })
                .then(res => {
                    window.location = "./verification/verification.html";
                })
            }
    
        })
    } else {
        swal({
            title: "ERROR!",
            text: "Las contrase?as no coinciden",
            icon: "warning",
        })
    }

}


btns.btnLog.addEventListener("click", () => {
    event.preventDefault();
    iniciarSesion();

})

btns.btnSign.addEventListener("click", () => {
    event.preventDefault();
    registrarse();
})



//estos son los cambios de contenido de registrarse o iniciar sesion
registerBtn.addEventListener('click', () => {
    container.classList.add("active");
});

loginBtn.addEventListener('click', () => {
    container.classList.remove("active");
});