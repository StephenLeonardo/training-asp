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
    public interface IBookService
    {
        List<BookModel> GetAllBook();
        List<BookModel> GetAllBookWithSP();
        ExecuteResult InsertBook(string BookName, string BookDesc, int BookQty);
        ExecuteResult InsertBookWithModel(BookModel Model);
        BookModel GetOneBook(int BookID);
        ExecuteResult DeleteBook(BookModel Model);
        ExecuteResult UpdateBook(BookModel Model);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;

        public BookService(IBookRepository _BookRepository)
        {
            this._BookRepository = _BookRepository;
        }

        public ExecuteResult DeleteBook(BookModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@BookID", Model.BookID)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_BookDB_DeleteBook @BookID",
                SQLParam = Param
            });

            ExecuteResult Result = _BookRepository.ExecMultipleSPWithTransaction(Data);

            return Result;
        }

        public List<BookModel> GetAllBook()
        {
            return _BookRepository.GetBooks();
        }

        public List<BookModel> GetAllBookWithSP()
        {
            return _BookRepository.GetBooksWithSP();
        }

        public BookModel GetOneBook(int BookID)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@BookID", BookID)
            };

            BookModel Model = _BookRepository.ExecSPToSingle("bn_BookDB_GetOneBook @BookID", Param);

            return Model;
        }

        public ExecuteResult InsertBook(string BookName, string BookDesc, int BookQty)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@BookName", BookName),
                new SqlParameter("@BookDesc", BookDesc),
                new SqlParameter("@BookQty", BookQty)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_BookDB_InsertBook @BookName, @BookDesc, @BookQty",
                SQLParam = Param
            });

            ExecuteResult Result = _BookRepository.ExecMultipleSPWithTransaction(Data);

            return Result;
        }

        public ExecuteResult InsertBookWithModel(BookModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@BookName", Model.BookName),
                new SqlParameter("@BookDesc", Model.BookDesc),
                new SqlParameter("@BookQty", Model.BookQty)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_BookDB_InsertBook @BookName, @BookDesc, @BookQty",
                SQLParam = Param
            });

            ExecuteResult Result = _BookRepository.ExecMultipleSPWithTransaction(Data);

            return Result;
        }

        public ExecuteResult UpdateBook(BookModel Model)
        {
            var Param = new SqlParameter[]
            {
                new SqlParameter("@BookID", Model.BookID),
                new SqlParameter("@BookName", Model.BookName),
                new SqlParameter("@BookDesc", Model.BookDesc),
                new SqlParameter("@BookQty", Model.BookQty)
            };

            List<StoredProcedure> Data = new List<StoredProcedure>();
            Data.Add(new StoredProcedure
            {
                SPName = "bn_BookDB_UpdateBook @BookID, @BookName, @BookDesc, @BookQty",
                SQLParam = Param
            });

            ExecuteResult Result = _BookRepository.ExecMultipleSPWithTransaction(Data);

            return Result;
        }
    }
}
