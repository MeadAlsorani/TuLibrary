using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuLibrary.Models
{
    public class Publisher_Requests
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Request_Text { get; set; }

        public int PublisherId { get; set; }
        public User Publisher { get; set; }


    }
}