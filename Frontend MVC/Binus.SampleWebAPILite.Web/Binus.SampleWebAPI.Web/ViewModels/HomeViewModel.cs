using Binus.SampleWebAPI.Model.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.SampleWebAPI.Web.ViewModels
{
    // https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/adding-validation -- Referensi Server-side validation
    public class HomeViewModel
    {
        public List<BookModel> Books { get; set; }
    }
}