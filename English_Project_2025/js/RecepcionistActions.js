const actionAddUser = document.getElementById('action-add-user');
const actionSearchUser = document.getElementById('action-search-user');

const panelAddUser = document.getElementById("add-user");
const panelSearchUser = document.getElementById("search-user");


const activePanelField = document.getElementById('ActivePanel');

function hideAllPanels() {
    panelAddUser.style.display = "none";
    panelSearchUser.style.display = "none";
    actionAddUser.style.textDecoration = "none";
    actionSearchUser.style.textDecoration = "none";
}

function showPanel(panelType) {
    hideAllPanels();

    if (panelType === "Search") {
        panelSearchUser.style.display = "grid";
        actionSearchUser.style.textDecoration = "underline";
    } else {
        panelAddUser.style.display = "grid"; 
        actionAddUser.style.textDecoration = "underline";
    }
}

const initialPanel = activePanelField.value || "Add";
showPanel(initialPanel);



actionAddUser.addEventListener('click', function (e) {
    e.preventDefault();
    activePanelField.value = "Add";
    showPanel("Add");
})


actionSearchUser.addEventListener('click', function (e) {
    e.preventDefault();
    activePanelField.value = "Search";
    showPanel("Search");
})