using LabbTwoADotNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbTwoADotNet.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
                
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-HB2LGAV; Initial Catalog = LabbTwoADotNet; Integrated Security = True;Encrypt=False");
        }


    }
}
