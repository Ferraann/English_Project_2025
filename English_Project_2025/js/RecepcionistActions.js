
const actionAddUser = document.getElementById('action-add-user');
const actionSearchUser = document.getElementById('action-search-user');

const panelAddUser = document.getElementById("add-user");
const panelSearchUser = document.getElementById("search-user");


actionAddUser.style.textDecoration = "underline";
panelAddUser.style.display = "grid";
panelSearchUser.style.display = "none";


function hideAllPanels() {
    panelAddUser.style.display = "none";
    panelSearchUser.style.display = "none";

    actionAddUser.style.textDecoration = "none";
    actionSearchUser.style.textDecoration = "none";
}

actionAddUser.addEventListener('click', function (e) {
    e.preventDefault();

    hideAllPanels();

    actionAddUser.style.textDecoration = "underline";
    panelAddUser.style.display = "grid";
})


actionSearchUser.addEventListener('click', function (e) {
    e.preventDefault();

    hideAllPanels();

    actionSearchUser.style.textDecoration = "underline";
    panelSearchUser.style.display = "grid";
})