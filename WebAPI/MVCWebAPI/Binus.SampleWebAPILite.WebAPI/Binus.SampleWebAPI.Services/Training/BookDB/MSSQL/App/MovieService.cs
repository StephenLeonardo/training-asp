using Binus.SampleWebAPI.Data.Repositories.Training.BookDB.MSSQL.App;
using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Services.Training.BookDB.MSSQL.App
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieModel> GetMovies()
        {
            List<MovieModel> movieModels = _movieRepository.ExecSPToList("bn_GetMovies").ToList();
            return movieModels;
        }

        public MovieModel GetMovieById(int movieId)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter("@MovieID", movieId),
            };
            MovieModel movie = _movieRepository.ExecSPToSingle("bn_GetMovieByID @MovieID", param);
            return movie;
        }

        public ExecuteResult InsertMovie(string movieName, int movieRating)
        {
            List<StoredProcedure> storedProcedures = new List<StoredProcedure>();
            StoredProcedure sp = new StoredProcedure();
            sp.SPName = "bn_InsertMovie @MovieName, @MovieRating";
            sp.SQLParam = new SqlParameter[]
            {
                new SqlParameter("@MovieName", movieName),
                new SqlParameter("@MovieRating", movieRating),
            };
            ExecuteResult Result = _movieRepository.ExecMultipleSPWithTransaction(storedProcedures);

            return Result;
        }
    }
}
