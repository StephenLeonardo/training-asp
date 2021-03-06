﻿using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.App;
using Binus.SampleWebAPI.Services.Training.BookDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using Microsoft.Web.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.BookDB.V1.App
{
    [ApiVersion("1.0")]
    public class BookController : ApiController
    {
        private readonly IBookService _BookService;

        public BookController(IBookService _BookService)
        {
            this._BookService = _BookService;
        }

        [HttpGet]
        public IHttpActionResult GetAllBook()
        {
            var books = _BookService.GetAllBookWithSP();
            //ketika return sebuah object memory, object akan diserialize terlebih dahulu menjadi JSON.
            //string json = JsonConvert.SerializeObject(books);
            // Object dalam Memory --> JSON sebutannya Serialization
            // JSON --> Object dalam memory sebutannya Deserialization
            return Json(books);
        }

        [HttpGet]
        public IHttpActionResult GetAllBooks()
        {
            List<BookModel> Result = _BookService.GetBooks();
            return Json(Result);
        }
        [HttpPost]
        public IHttpActionResult InsertBook(string BookName, string BookDesc, int BookQty)
        {
            ExecuteResult Result = _BookService.InsertBook(BookName, BookDesc, BookQty);

            return Json(Result);
        }

        [HttpPost]
        public IHttpActionResult InsertBookWithModel(BookModel Model)
        {
            ExecuteResult Result = _BookService.InsertBookWithModel(Model);

            return Json(Result);
        }

        [HttpGet]
        public IHttpActionResult GetOneBook(int BookID)
        {
            BookModel Model = _BookService.GetOneBook(BookID);

            return Json(Model);
        }

        [HttpPost]
        public IHttpActionResult DeleteBook(BookModel Model)
        {
            ExecuteResult Result = _BookService.DeleteBook(Model);

            return Json(Result);
        }

        [HttpPost]
        public IHttpActionResult UpdateBook(BookModel Model)
        {
            ExecuteResult Result = _BookService.UpdateBook(Model);

            return Json(Result);
        }
    }
}