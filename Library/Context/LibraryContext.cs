using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }


        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<AuthorBook> AuthorBooks { get; set; }

        public DbSet<CategoryBook> CategoryBooks { get; set; }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(x => x.ToTable("Book"));
            builder.Entity<Author>(x => x.ToTable("Author"));
            builder.Entity<Category>(x => x.ToTable("Category"));
            builder.Entity<Publisher>(x => x.ToTable("Publisher"));
            builder.Entity<AuthorBook>(x => x.ToTable("AuthorBook"));
            builder.Entity<CategoryBook>(x => x.ToTable("CategoryBook"));
        }


    }
}
