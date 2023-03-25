/* Javascript functions used by the Bookstore application. */

//Function to request a new page whenever a new author is selected in the drop-down list.
function vRequestBooks(eltAuthorSelect) {
    //Get the author ID of the selected author from the drop-down list and use it to build the URI of the request to send to the server.
    //has the form /controller/action_method/authorID.
    var strAuthorID = eltAuthorSelect.value;
    // Use a new action method to handle this request "Get Books".
    var strURI = "/Home/GetBooks/" + strAuthorID;
    //Set up to use Ajax
    //Create XMLHttpRequest object, configure it
    var xhrGetBooks = new XMLHttpRequest();
    // Specify request method, URI, make an asynchronous request.
    xhrGetBooks.open("GET", strURI, true);
    // Specify the function to call to handle the request when it returns.
    xhrGetBooks.onreadystatechange = vDisplayBooks;
    // Send the request to the server.
    xhrGetBooks.send();
}
// Function to handle the response to the GetBooks request. Inside here the special variable this is a reference to the
// XMLHttpRequest object created in vRequestBooks
function vDisplayBooks() {
    //Check the current ready state of the XMLHttpRequest object. Only do something if the ready state is 4.
    if (this.readyState == 4) {
        //If reach here, the complete response has been received. Check that the server returned a valid response (status code 200)
        if (this.status == 200) {
            //If reach here, we have a valid response from the server.
            //Get the <tbody> element in the book table and put the rows received from the server into that element.
            var eltTBody = document.getElementById("tbdyBooks");
            eltTBody.innerHTML = this.responseText;
        } else {
            alert("Error: " + this.responseText);
        }
    }
}

//Function to start the process of inserting a new author in the DB.
function vNewAuthor() {
    // Pop up a new window to prompt for the author's name.
    var strNewWinFeatures = "width=300,height=200";
    window.open("/html/AuthorName.html", "NewAuthor", strNewWinFeatures);
}