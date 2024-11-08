// Seleccionar el botón de Log Out
const logoutButton = document.querySelector('.logout-button');

const inputs = {
    nombre: document.querySelector(".name"),
    correo: document.querySelector(".mail"),
    pass : document.querySelector(".pass"),
}



showInfo();


// Añadir un evento para el click en el botón
logoutButton.addEventListener('click', function() {
    // Confirmar si el usuario realmente desea cerrar sesión
    const confirmLogout = confirm('¿Estás seguro de que deseas cerrar sesión?');
    if (confirmLogout) {
        // Aquí puedes agregar la lógica para cerrar sesión (por ejemplo, limpiar datos de sesión o redirigir)

        let url = "https://localhost:7225/api/Sesion";

        fetch(url)
        .then(res =>res.json())
        .then(data => {
            for(let i = 0; i < data.length; i++){
                borrarSesion(data[i].email);
            }
        })
        alert('Has cerrado sesión');
        window.location.href = '../index.html'; // Redirigir a la página de login 
    }
});




fetch("https://localhost:7225/api/Sesion")
.then(res => res.json())
.then(data => console.log(data))

function borrarSesion(mail){
    const url = `https://localhost:7225/api/Sesion?email=${encodeURIComponent(mail)}`;

    fetch(url, {
        method: "DELETE",
        headers : {
          'Content-Type' : 'application/json'
        },
    })
    .then(res => {
        console.log("success", res);
    })

    console.log(data);
}

function showInfo(){
    let url = "https://localhost:7225/api/Sesion";




    fetch(url)
    .then(res => res.json())
    .then(data => {
        for(let i = 0; i < data.length; i++){

            let nombre = inputs.nombre.value = data[i].nombre ;
            let mail = inputs.correo.value = data[i].email;
            let pass = inputs.pass.value = data[i].clave;

            console.log(nombre, mail, pass);
        }
    })
}

function toggleProfile() {
    const profile = document.getElementById('profile');
    profile.style.display = profile.style.display === 'none' || profile.style.display === '' ? 'block' : 'none';
}

