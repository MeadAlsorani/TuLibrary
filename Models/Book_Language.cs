using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuLibrary.Models
{
    public class Book_Language
    {
        public int Id { get; set; }

        public string Language { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}