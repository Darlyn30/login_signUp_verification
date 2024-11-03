// Seleccionar el botón de Log Out
const logoutButton = document.getElementById('logoutButton');

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
        window.location.href = '../index.html'; // Redirigir a la página de login (ajusta la ruta según tu proyecto)
    }
});


function borrarSesion(mail){
    const url = `https://localhost:7225/api/Sesion?email=${encodeURIComponent(mail)}`;

    fetch(URL, {
        method: "DELETE",
        headers : {
          'Content-Type' : 'application/json'
        },
    })
    .then(res => {
        console.log("success", res);
    })
}
