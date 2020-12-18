using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {

            var book1 = new BookModel()
            {
                Judul = "Sang Pendekar"
            };

            return View("List", book1);
        }

        public class Dummy
        {
            public string Test { get; set; }
        }

    }



}