function vSaveNewAuthor() {
    // Get the new author first and last names from the page.
    let strFirstName = document.getElementById("txtFName").value;
    let strLastName = document.getElementById("txtLName").value;

    //Use Ajax to send the author name back to the server to insert into the DB and return the updated list of <option> elements for the
    //drop-down list.
    let xhrNewAuthor = new XMLHttpRequest();
    let strURI = "/Home/InsertNewAuthor/?FirstName=" + encodeURIComponent(strFirstName) + "&LastName=" + encodeURIComponent(strLastName);
    //Configure the XMLHttpRequest object. Use a PUT request, because we are putting new data into the database.
    xhrNewAuthor.open("PUT", strURI, true);
    xhrNewAuthor.onreadystatechange = vInsertNewAuthors;
    //Send the request.
    xhrNewAuthor.send();
}

//Function to handle the response from the Ajax request. It will insert a new list of <option> elements into the author drop-down list.
function vInsertNewAuthors() {
    //Check that the ready state is 4 and the status code is 200
    if(this.readyState == 4) {
        if(this.status == 200) {
            // This code is executing in the popup window, but the author drop-down list is on the main window. We need to get access
            // to the main window. It works because the main window is the window that opened up this popup window. (i.e., the main
            // window is the opener of this popup window)
            let winMain = window.opener;
            let eltAuthorSelect = winMain.document.getElementById("selAuthors");
            eltAuthorSelect.innerHTML = this.responseText;
        } else {
            alert("Error. Status code: " + this.status);
        }
        // Finished with this popup window. Close it.
        window.close();
    }
}