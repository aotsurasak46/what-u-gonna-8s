function confirmDelete() {
    // Get the "Delete" button element
    var deleteButton = document.getElementById("deleteButton");

    // Add an onclick event listener to the button
    deleteButton.addEventListener("click", function (event) {
        // Display the confirmation dialog
        var confirmDelete = confirm("Are you sure you want to delete this object?");

        // If the user clicked "Cancel", prevent the form submission
        if (!confirmDelete) {
            event.preventDefault();
        }
    });
}