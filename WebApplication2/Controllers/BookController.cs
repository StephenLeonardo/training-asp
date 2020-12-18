using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        public static List<BookModel> listBooks = new List<BookModel>();
        public static List<MovieModel> listMovies = new List<MovieModel>();


        // GET: Book
        [HttpGet]
        public ActionResult Index()
        {

            //var book1 = new BookModel()
            //{
            //    BookID = 1,
            //    Judul = "Sang Pendekar",
            //    Author = "Budi"
            //};

            //var book2 = new BookModel()
            //{
            //    BookID = 2,
            //    Judul = "Percy Jackson",
            //    Author = "Jojo"
            //};

            

            //listBooks.Add(book1);
            //listBooks.Add(book2);


            //var movie1 = new MovieModel()
            //{
            //    MovieID = 1,
            //    Title = "John Wick",
            //    Actor = "Keanu"
            //};

            //var movie2 = new MovieModel()
            //{
            //    MovieID = 2,
            //    Title = "Harry Potter",
            //    Actor = "Emma Watson"
            //};

            
            //listMovies.Add(movie1);
            //listMovies.Add(movie2);

            BookListVM bookListVM = new BookListVM();
            bookListVM.listBooks = listBooks;
            bookListVM.listMovies = listMovies;

            return View("List", bookListVM);
        }


        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        public JsonResult GetAllBooks()
        {
            return Json(listBooks);
        }


        [HttpPost]
        public ActionResult SubmitForm(BookModel book)
        {


            // save to database
            listBooks.Add(book);

            return RedirectToAction("Index");
        }



        public ActionResult DeleteBook(int BookID)
        {

            // LINQ

            listBooks.Remove(
                listBooks.Where(e => e.BookID == BookID).FirstOrDefault()
                );

            return RedirectToAction("Index");
            
        }


        public ActionResult UpdateBook(int BookID)
        {
            BookModel book =  listBooks.Where(e => e.BookID == BookID).FirstOrDefault();


            return View("FormUpdate", book);
        }

        public ActionResult SubmitUpdateBook(BookModel newBook)
        {

            BookModel oldBook = listBooks.Where(e => e.BookID == newBook.BookID).FirstOrDefault();

            foreach (var item in listBooks)
            {
                if (item == oldBook)
                {
                    item.BookID = newBook.BookID;
                    item.Judul = newBook.Judul;
                    item.Author = newBook.Author;
                }
            }

            return RedirectToAction("Index");
        }


    }



}