﻿using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.App;
using Binus.SampleWebAPI.Services.Training.BookDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using Microsoft.Web.Http;
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
        public async Task<IHttpActionResult> GetAllBook()
        {
            return Json(new
            {
                Test = "Hello World"
            });
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertBook(string BookName, string BookDesc, int BookQty)
        {
            ExecuteResult Result = (await _BookService.InsertBook(BookName, BookDesc, BookQty));

            return Json(Result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertBookWithModel(BookModel Model)
        {
            ExecuteResult Result = (await _BookService.InsertBookWithModel(Model));

            return Json(Result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOneBook(int BookID)
        {
            BookModel Model = (await _BookService.GetOneBook(BookID));

            return Json(Model);
        }

        [HttpPost]
        public async Task<IHttpActionResult> DeleteBook(BookModel Model)
        {
            ExecuteResult Result = (await _BookService.DeleteBook(Model));

            return Json(Result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdateBook(BookModel Model)
        {
            ExecuteResult Result = (await _BookService.UpdateBook(Model));

            return Json(Result);
        }
    }
}