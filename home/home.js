// Seleccionar el botón de Log Out
const logoutButton = document.getElementById('logoutButton');

// Añadir un evento para el click en el botón
logoutButton.addEventListener('click', function() {
    // Confirmar si el usuario realmente desea cerrar sesión
    const confirmLogout = confirm('¿Estás seguro de que deseas cerrar sesión?');
    if (confirmLogout) {
        // Aquí puedes agregar la lógica para cerrar sesión (por ejemplo, limpiar datos de sesión o redirigir)
        alert('Has cerrado sesión');
        window.location.href = '../index.html'; // Redirigir a la página de login (ajusta la ruta según tu proyecto)
    }
});
