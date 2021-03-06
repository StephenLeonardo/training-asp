﻿using Binus.SampleWebAPI.Data.Infrastructures.Base.MSSQL;
using Binus.SampleWebAPI.Data.Infrastructures.Training.MSSQL;
using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Data.Repositories.Training.BookDB.MSSQL.App
{
    public interface IMovieRepository : IMSSQLRepository<MovieModel> { }

    public class MovieRepository : BookDBMSSQLRepositoryBase<MovieModel>, IMovieRepository
    {
        public MovieRepository(BookDBMSSQLIDBFactory DBFactory) : base(DBFactory)
        {
        }

    }
}
