using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModel
{
    public class BookListVM
    {
        public List<BookModel> listBooks { get; set; }
        public List<MovieModel> listMovies { get; set; }
    }
}