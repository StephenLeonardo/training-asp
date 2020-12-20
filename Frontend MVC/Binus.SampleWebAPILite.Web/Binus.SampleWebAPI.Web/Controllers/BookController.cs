﻿using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.SampleWebAPI.Web.ViewModels;
using Binus.WebAPI.REST;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class BookController : Controller
    {
        
        public ActionResult Index()
        {

            try
            {
                RestClient restClient = new RestClient(Global.WebAPIBaseURL);
                var books = restClient.Get<List<BookModel>>(new RestRequest("/api/Training/BookDB/V1/App/Book/GetAllBook", Method.GET)).Data;

                HomeViewModel hvm = new HomeViewModel();
                hvm.Books = books;


                return View("index",hvm);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult InsertBook(BookModel model)
        {
            JsonResult RetData = new JsonResult();
            try
            {
                if(model.BookID != 0)
                {
                    RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/UpdateBook", REST.Method.POST, model)).Result;

                    if (Result.Success)
                    {
                        RetData = Json(new
                        {
                            Status = "Success",
                            URL = Global.BaseURL + "/Book"
                        });
                    }
                    else
                    {
                        RetData = Json(new
                        {
                            Status = "Failed",
                            Message = "Failed when updating data.."
                        });
                    }
                }
                else
                {
                    RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/InsertBookWithModel",REST.Method.POST,model)).Result;

                    if (Result.Success)
                    {
                        RetData = Json(new {
                            Status = "Success",
                            URL = Global.BaseURL + "/Book"
                        });
                    }
                    else
                    {
                        RetData = Json(new {
                            Status = "Failed",
                            Message = "Failed When Inserting Data.."
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                RetData = Json(new {
                    Status = "Failed",
                    Message = ex.Message
                });
            }

            return RetData;
        }

        public ActionResult Delete(BookModel Model)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/DeleteBook",REST.Method.POST,Model)).Result;

                if (Result.Success)
                {
                    retData = Json(new {
                        Status = "Success",
                        URL = Global.BaseURL + "/Book"
                    });
                }
                else
                {
                    retData = Json(new
                    {
                        Status = "Failed",
                        Message = "Failed When Deleting Data.."
                    });
                }
            }
            catch(Exception ex)
            {
                retData = Json(new
                {
                    Status = "Failed",
                    Message = ex.Message
                });
            }
            return retData;
        }

        public ActionResult Edit(BookModel model)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL,"/api/Training/BookDB/V1/App/Book/GetOneBook?BookID="+model.BookID,REST.Method.GET)).Result;
                
                if (Result.Success)
                {
                    retData = Json(new {
                        Status = "Success",
                        Data = Result.Deserialize<BookModel>()
                    });
                }
                else
                {
                    retData = Json(new
                    {
                        Status = "Failed",
                        Message = "Failed when getting data.."
                    });
                }
            }
            catch (Exception ex)
            {
                retData = Json(new
                {
                    Status = "Failed",
                    Message = ex.Message
                });
            }
            return retData;
        }

        //public ActionResult Borrow(BookModel model)
        //{
        //    JsonResult retData = new JsonResult();
        //    try
        //    {
        //        RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/BookDB/V1/App/Book/BorrowBook?BookID=" + model.BookID, REST.Method.GET)).Result;

        //        if (Result.Success)
        //        {
        //            retData = Json(new
        //            {
        //                Status = "Success",
        //                Data = Result.Deserialize<BookModel>()
        //            });
        //        }
        //        else
        //        {
        //            retData = Json(new
        //            {
        //                Status = "Failed",
        //                Message = "Failed when getting data.."
        //            });
        //        }
        //    } catch (Exception e)
        //    {
        //        retData = Json(new
        //        {
        //            Status = "Failed",
        //            Message = e.Message
        //        });
        //    }
        //}

    }
}