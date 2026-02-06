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

        public LibraryDbContext()
        {
        }

        private void ConfigureBook(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(b => b.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(b => b.PublisherId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(b => b.ISBN)
                    .IsUnique();

                entity.HasCheckConstraint("CK_Book_Price_Positive", "[Price] > 0");
                entity.HasCheckConstraint("CK_Book_PublicationYear_Range", "[PublicationYear] BETWEEN 1900 AND YEAR(GETDATE())");
            });
        }

        private void ConfigureAuthorBiography(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBiography>(entity =>
            {
                entity.HasKey(ab => ab.Id);

                entity.HasOne(ab => ab.Author)
                    .WithOne(a => a.AuthorBiography)
                    .HasForeignKey<AuthorBiography>(ab => ab.AuthorId);
            });
        }

        private void ConfigureBookCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(bc => new { bc.BookId, bc.CategoryId });

                entity.HasOne(bc => bc.Category)
                    .WithMany(c => c.BookCategories)
                    .HasForeignKey(bc => bc.CategoryId);

                entity.HasOne(bc => bc.Book)
                    .WithMany(b => b.BookCategories)
                    .HasForeignKey(bc => bc.BookId);

                entity.Property(bc => bc.AddedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("CAST(GETDATE() AS date)");
            });
        }

        private void ConfigureBookDetail(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.HasOne(d => d.Book)
                    .WithOne(b => b.BookDetail)
                    .HasForeignKey<BookDetail>(d => d.BookId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureLoan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.HasOne(l => l.Book)
                    .WithMany(b => b.Loans)
                    .HasForeignKey(l => l.BookId)
                    .IsRequired();

                entity.HasOne(l => l.Member)
                    .WithMany(m => m.Loans)
                    .HasForeignKey(l => l.MemberId)
                    .IsRequired();

                entity.Property(l => l.ReturnDate)
                    .HasColumnType("date");

                entity.Property(l => l.DueDate)
                    .HasColumnType("date");

                entity.Property(l => l.LoanDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("CAST(GETDATE() AS date)");

                entity.HasCheckConstraint("CK_Loan_LoanDate_DueDate", "[LoanDate] <= [DueDate]");
                entity.HasCheckConstraint("CK_Loan_ReturnDate_Valid", "[ReturnDate] IS NULL OR [ReturnDate] >= [LoanDate]");
            });
        }

        private void ConfigureMemberContact(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberContact>(entity =>
            {
                entity.HasKey(mc => mc.Id);

                entity.HasOne(mc => mc.Member)
                    .WithOne(m => m.MemberContact)
                    .HasForeignKey<MemberContact>(mc => mc.MemberId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureAuthor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.BirthDate)
                    .HasColumnType("date");

                entity.Property(a => a.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(a => a.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasCheckConstraint("CK_Member_FirstLastName_NotEmpty", "LEN([FirstName]) > 0 AND LEN([LastName]) > 0");
            });
        }

        private void ConfigureMember(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.MembershipDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("CAST(GETDATE() AS date)");

                entity.HasIndex(m => m.Email)
                    .IsUnique();

                entity.Property(m => m.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(m => m.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasCheckConstraint("CK_Member_FirstLastName_NotEmpty", "LEN([FirstName]) > 0 AND LEN([LastName]) > 0");
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureAuthor(modelBuilder);
            ConfigureAuthorBiography(modelBuilder);
            ConfigureBook(modelBuilder);
            ConfigureBookCategory(modelBuilder);
            ConfigureBookDetail(modelBuilder);
            ConfigureLoan(modelBuilder);
            ConfigureMember(modelBuilder);
            ConfigureMemberContact(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
