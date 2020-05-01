using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuLibrary.Models
{
    public class Book_Type_LanguageViewModel
    {
        public List< Book> book { get; set; }

        public List<Book_Language> Book_Language { get; set; }

        public List<Book_Type> Book_Type { get; set; }

        public List<User> Publisher { get; set; }
    }
}