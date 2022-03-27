using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestovoeV3DAL.Entities;

namespace TestovoeV3DAL.EF
{
    public class FilesContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public FilesContext(DbContextOptions<FilesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
