using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.App;
using Binus.SampleWebAPI.Services.Training.BookDB.MSSQL.App;
using Microsoft.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.BookDB.V1.App
{
    [ApiVersion("1.0")]
    public class MovieController : ApiController
    {
        private readonly MovieService movieService;

        public MovieController(MovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            List<MovieModel> movieModels = movieService.GetMovies();
            return Json(movieModels);
        }


        [HttpGet]
        public IHttpActionResult GetMovieByID(int movieId)
        {
            return Json(movieService.GetMovieById(movieId));
        }


    }
}