using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // The "Index" action method. Note that its parameter is a nullable integer, so that "id" is null if no parameter is
        //provided in the request.
        public IActionResult Index(int? id)
        {
            //Set up to use the database.
            using (BookstoreContext dbContext = new BookstoreContext())
            {
                // Use a LINQ query to get a list of all of the authors in the bookstore, ordered alphabetically by name.
                var listAuthors =
                    from author in dbContext.TAuthors
                    orderby author.FAuthorName
                    select author;
                // Get the author ID of the author whose books we want to display. no author ID is passed in as the parameter, use the ID
                //Of the first author in the list of authors
                int iAuthorID = (int)listAuthors.First().FAuthorId;
                //Construct a list of the books written by the given author, use LINQ.
                var listBooks =
                    from book in dbContext.TBooks
                    where book.FAuthorId == iAuthorID
                    orderby book.FTitle
                    select book;
                //Send the lists of authors and books to the view page. Note that we are using the default name for the view which is 
                // "Index.cshtml" derived from the name of the method.
                //To send two lists to the view, we put the lists together into an ordered pair (author_list, book_list)
                return View((listAuthors.ToList(), listBooks.ToList()));
            }
        }

        //Action method for getting a new list of books (written by the specified author)
        public IActionResult GetBooks(int id)
        {
            using (BookstoreContext dbContext = new BookstoreContext())
            {
                //Construct a list of the books written by the given author, use LINQ.
                var listBooks =
                    from book in dbContext.TBooks
                    where book.FAuthorId == id
                    orderby book.FTitle
                    select book;
                //Return a part of the page containing the table rows with the book info.
                //Use the view file named "BookRows.cshtml" for the partial view.
                return PartialView("BookRows", listBooks.ToList());
            }
        }

        //Action method to insert a new author into the DB.
        public IActionResult InsertNewAuthor(string FirstName, string LastName)
        {
            // Set up to access the DB.
            using (BookstoreContext dbContext = new BookstoreContext())
            {
                //Put together full name in form last_name, first_name.
                string strFullName = LastName + ", " + FirstName;
                // Create a new TAuthor object.
                TAuthor taNewAuthor = new TAuthor() { FAuthorName = strFullName };
                //Add the new TAuthor object to the TAuthors table.
                dbContext.TAuthors.Add(taNewAuthor);
                // Save the change to the database.
                dbContext.SaveChanges();
                // Generate new list of author <option> elements, send back to the browser.
                var listAuthors =
                   from author in dbContext.TAuthors
                   orderby author.FAuthorName
                   select author;
                return PartialView("AuthorOptions", listAuthors.ToList());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}