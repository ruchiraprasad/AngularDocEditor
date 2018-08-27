using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentEditor.API.Models
{
    public class TestDocDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=104.41.223.4;Database=TestDocDB;User Id=sa; password=Welcome@321; MultipleActiveResultSets=True;");
        }

        public DbSet<Template> Templates { get; set; }
    }
}
