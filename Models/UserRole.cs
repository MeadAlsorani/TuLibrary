using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TuLibrary.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        [DisplayName("Role")]
        public string RoleName { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}