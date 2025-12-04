
const actionAddUser = document.getElementById('action-add-user');
const actionAddReservation = document.getElementById('action-add-reservation');
const actionDeleteUser = document.getElementById('action-delete-user');

const panelAddUser = document.getElementById("add-user");
const panelAddReservation = document.getElementById("add-reservation");
const panelDeleteUser = document.getElementById("delete-user");


actionAddUser.style.textDecoration = "underline";
panelAddUser.style.display = "flex";
panelAddReservation.style.display = "none";
panelDeleteUser.style.display = "none";


function hideAllPanels() {
    panelAddUser.style.display = "none";
    panelAddReservation.style.display = "none";
    panelDeleteUser.style.display = "none";

    actionAddUser.style.textDecoration = "none";
    actionAddReservation.style.textDecoration = "none";
    actionDeleteUser.style.textDecoration = "none";
}

actionAddUser.addEventListener('click', function (e) {
    e.preventDefault();

    hideAllPanels();

    actionAddUser.style.textDecoration = "underline";
    panelAddUser.style.display = "flex";
})


actionAddReservation.addEventListener('click', function (e) {
    e.preventDefault();

    hideAllPanels();

    actionAddReservation.style.textDecoration = "underline";
    panelAddReservation.style.display = "flex";
})


actionDeleteUser.addEventListener('click', function (e) {
    e.preventDefault();

    hideAllPanels();

    actionDeleteUser.style.textDecoration = "underline";
    panelDeleteUser.style.display = "flex";
})