using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EFCore_Code_First.Models;

namespace EFCore_Code_First
{
    internal class LibraryDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBiography> AuthorBiographies { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberContact> MemberContacts { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected LibraryDbContext()
        {
        }

        private void ConfigureAuthor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasMany(a => a.Books)
                    .WithOne(a => a.Author)
                
                entity.HasOne(a => a.AuthorBiography)
                    .WithOne(a => a.Author)
                    .HasForeignKey(a => a.auth)
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
    }
}
