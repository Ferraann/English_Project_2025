// Pillamos los botones del menú (Add User y Search User)
const actionAddUser = document.getElementById('action-add-user');
const actionSearchUser = document.getElementById('action-search-user');

// Pillamos los div contenedores de la informacion (el div del Add User y el div del Search User)
const panelAddUser = document.getElementById("add-user");
const panelSearchUser = document.getElementById("search-user");

// Esto esta mal porque no hay nada que sea ActivePanel, así que su valor será null
const activePanelField = document.getElementById('ActivePanel');

// Funcion para esconder los dos div y quitar el subrayado a los dos botones. Para reiniciar
function hideAllPanels() {
    // Esconder los divs
    panelAddUser.style.display = "none";
    panelSearchUser.style.display = "none";
    // Quitar subrayados
    actionAddUser.style.textDecoration = "none";
    actionSearchUser.style.textDecoration = "none";
}

// Funcion para mostrar un panel u otro
function showPanel(panelType) {
    // Llamamos primero al hideAllPanels(), es decir, escondemos los dos div y quitamos los dos subrayados
    hideAllPanels();

    // Si el panelType es Search --> Ponemos el display grid al div del SearchUser y le ponemos un subrayado al texto del boton de Search User
    if (panelType === "Search") {
        panelSearchUser.style.display = "grid";
        actionSearchUser.style.textDecoration = "underline";
    }
    // Si no, ponemos display grid al div del AddUser y le ponemos subrayado al texto del boton de Add User
    else {
        panelAddUser.style.display = "grid"; 
        actionAddUser.style.textDecoration = "underline";
    }
}

// Configuracion inicial: initialPanel == 'Add'
const initialPanel = activePanelField.value || "Add";
// Llama la funcion showPanel pasandole initialPanel (Add)
showPanel(initialPanel);

// Eventos:

// Si hace click en el boton de Add User
actionAddUser.addEventListener('click', function (e) {
    e.preventDefault();
    // Cambia el valor de activePanelField y le pone add y llama a showPanel con 'Add'
    activePanelField.value = "Add";
    showPanel("Add");
})

// Si hace click en el boton de Search User
actionSearchUser.addEventListener('click', function (e) {
    e.preventDefault();
    // Cambia el valor de activePanelField y le pone Search y llama a showPanel con 'Search'
    activePanelField.value = "Search";
    showPanel("Search");
})