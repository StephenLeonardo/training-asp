using Binus.SampleWebAPI.Data.Infrastructures.Base.MSSQL;
using Binus.SampleWebAPI.Data.Infrastructures.Training.MSSQL;
using Binus.SampleWebAPI.Model.Training.BookDB.MSSQL.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Data.Repositories.Training.BookDB.MSSQL.App
{
    public interface IBookRepository : IMSSQLRepository<BookModel>
    {
        List<BookModel> GetBooks();
        List<BookModel> GetBooksWithSP();
    }

    public class BookRepository : BookDBMSSQLRepositoryBase<BookModel>, IBookRepository
    {
        public BookRepository(BookDBMSSQLIDBFactory DBFactory) : base(DBFactory)
        {
        }

        public List<BookModel> GetBooks()
        {
            List<BookModel> books = DBContext.Database.SqlQuery<BookModel>("SELECT BookID, BookName, BookDesc, BookQty FROM MsBook").ToList();
            return books;
        }

        public List<BookModel> GetBooksWithSP()
        {
            List<BookModel> books = DBContext.Database.SqlQuery<BookModel>("bn_BookDB_GetAllbook").ToList();
            return books;
        }

    }
}
