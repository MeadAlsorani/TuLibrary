using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TuLibrary.Models
{
    public class ApplicationDbContext :DbContext
    {
        private const string NameOrConnectionString = "DefaultConnection";

        public ApplicationDbContext() : base(NameOrConnectionString)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public System.Data.Entity.DbSet<TuLibrary.Models.Book_Language> Book_Language { get; set; }

        public System.Data.Entity.DbSet<TuLibrary.Models.Book_Type> Book_Type { get; set; }
    }
}