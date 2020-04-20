using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuLibrary.Models
{
    public class Book_Type
    {
        public int Id { get; set; }

        public string Type_Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}