
const actionLinks = document.querySelectorAll('.actions-container a');
const contentPanels = document.querySelectorAll('.action-panel');

function hideAllPanels() {
    contentPanels.forEach(panel => {
        panel.style.display = 'none';
    });
}

actionLinks.forEach(link => {
    link.addEventListener('click', function (event) {
        event.preventDefault();

        // Determine which panel to show based on the link's ID
        // e.g., 'action-add-user' becomes 'add-user'
        const panelIdToShow = this.id.replace('action-', '');

        // Execute the logic
        hideAllPanels();

        // Show the specific panel
        const panelToShow = document.getElementById(panelIdToShow);
        if (panelToShow) {
            // Use 'flex' or 'block' depending on how you want the content formatted.
            // Since .content_container is a column flex, 'block' or 'flex' should work well for a panel.
            panelToShow.style.display = 'flex';
        }
    });
});