using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuLibrary.Models
{
    public class Book
    {
        private const int V = 50;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        private string yearOfPublish;

        public string GetYearOfPublish()
        {
            return yearOfPublish;
        }

        public void SetYearOfPublish(string value)
        {
            yearOfPublish = value;
        }

        [Required]
        [StringLength(V)]
        public string Author { get; set; }

        [DefaultValue(0)]
        public int DownloadTimes { get; set; }

        public string BookPath { get; set; }
        public int LanguageId { get; set; }

        public int PublisherId { get; set; }

        public int TypeId { get; set; }

        public string Picture { get; set; }

        public User publisher { get; set; }
        public Book_Language language { get; set; }
        public Book_Type type { get; set; }


    }
}