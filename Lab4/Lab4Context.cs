using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Lab4Context : DbContext
    {
        private object options;

        public Lab4Context() { }

        public Lab4Context(object options)
        {
            this.options = options;
        }

        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Data Source = lab4.db");
        }
    }
}
