using System;
using System.Collections.Generic;
using System.Text;
using EFCore_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EFCore_Code_First
{
    internal class LibraryService
    {
        private readonly LibraryDbContext _context;

        public LibraryService (LibraryDbContext context)
        {
            _context = context;
        }

        //Как я понимаю, в таких случаях следует создавать DTO.
        //Учитывая кол-во заданий, которое я решил выполнить, я посчитал рациональным вернуть анонимные объекты
        public object GetBooksAfter2010()
        {
            return _context.Books
                .Where(b => b.PublicationYear > 2010)
                .Select(b => new
                {
                    Title = b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                    Year = b.PublicationYear
                })
                .OrderBy(b => b.Title)
                .ToList();
        }

        public object GetAuthorsWithoutBio()
        {
            return _context.Authors
                .Where(a => a.AuthorBiography == null)
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    BirthYear = a.BirthDate.Year
                })
                .ToList();
        }

        public object GetMembersWithOverdues()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);

            return _context.Members
                .Where(m => m.Loans.Any(l => l.ReturnDate == null
                    && l.DueDate < today))
                .Select(m => new
                {
                    MemberName = m.FirstName + " " + m.LastName,
                    OverduesCount = m.Loans.Count(l => l.ReturnDate == null
                        && l.DueDate < today)
                })
                .ToList();
        }

        public object GetBooksFromEachCategory()
        {
            return _context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BooksCount = c.BookCategories.Count(),
                    AvgPageCount = c.BookCategories.Any(bc => bc.Book.BookDetail != null) ?
                        c.BookCategories
                        .Where(bc => bc.Book.BookDetail != null)
                        .Average(bc => bc.Book.BookDetail.PageCount) : 0
                })
                .OrderByDescending(s => s.BooksCount)
                .ToList();
        }

        public object GetPublishersWithoutBooks()
        {
            return _context.Publishers
                .Where(p => !p.Books.Any())
                .Select(p => new
                {
                    Name = p.Name,
                    Address = p.Address
                })
                .ToList();
        }

        public object GetBooksWithManyCategories()
        {
            return _context.Books
                .Where(b => b.BookCategories.Skip(1).Any())
                .Select(b => new
                {
                    BookName = b.Title,
                    CategoryData = b.BookCategories.Select(bc => new
                    {
                        bc.Category.Name,
                        bc.AddedDate
                    }).ToList()
                })
                .AsEnumerable()
                .Select(b => new
                {
                    b.BookName,
                    CategoriesInfo = b.CategoryData.ToDictionary(
                        x => x.Name,
                        x => x.AddedDate
                        )
                })
                .ToList();
        }

        public object GetAuthorsWithBooksCount()
        {
            return _context.Authors
                .Where(a => a.Books.Any())
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.Books.Count,
                    MostPopularBook = a.Books.Any() 
                        ? a.Books
                        .OrderByDescending(b => b.Loans.Count)
                        .Select(b => b.Title)
                        .FirstOrDefault()
                        : "Книг нет"
                })
                .ToList();
        }

        public object GetMembersWithFantasyOnly()
        {
            return _context.Members
                .Where(m => m.Loans.Any()
                    && m.Loans.All(l => l.Book.BookCategories.Any(bc => bc.Category.Name == "Фантастика")))
                .Select(m => new
                {
                    MemberName = m.FirstName + " " + m.LastName,
                    FantasyBooksCount = m.Loans.Count 
                })
                .ToList();
        }

        public object GetBooksInformation()
        {
            return _context.Books
                .Where(b => b.BookDetail != null)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookISBN = b.ISBN,
                    BookPageCount = b.BookDetail.PageCount,
                    BookPrice = b.Price
                })
                .OrderByDescending(res => res.BookPrice)
                .ToList();
        }

        public object GetPublisherDetails()
        {
            return _context.Publishers
                .Where(p => p.Books.Any())
                .Select(p => new
                {
                    PublisherName = p.Name,
                    BooksCount = p.Books.Count,
                    NewestBookName = p.Books
                        .OrderByDescending(b => b.PublicationYear)
                        .Select(b => b.Title)
                        .FirstOrDefault()
                })
                .ToList();
        }

        public object GetLoansGroupedByDates()
        {
            return _context.Loans
                .GroupBy(l => new
                {
                    l.LoanDate.Year,
                    l.LoanDate.Month
                })
                .Select(g => new
                {
                    TimePeriod = g.Key.Month + "/" + g.Key.Year,
                    LoanCount = g.Count(),
                    AvgLoanDuration = g.Average(l => (double?)EF.Functions.DateDiffDay(l.LoanDate, l.DueDate)) ?? 0
                })
                .ToList();
        }

        public object GetTopTotalPageCountAuthors()
        {
            return _context.Authors
                .Where(a => a.Books.Any())
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    TotalPageCount = a.Books.Sum(b => (int?)b.BookDetail.PageCount ?? 0)
                })
                .OrderByDescending(s => s.TotalPageCount)
                .Take(3)
                .ToList();
        }

        public object GetCategoriesWithAuthors()
        {
            return _context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BooksCount = c.BookCategories.Count(),
                    Authors = c.BookCategories
                        .Select(bc => bc.Book.Author)
                        .Distinct()
                        .Select(a => a.FirstName + " " + a.LastName)
                })
                .ToList();
        }

        public object GetMembersInformation()
        {
            return _context.Members
                .Select(m => new
                {
                    MemberFullName = m.FirstName + " " + m.LastName,
                    TotalLoanCount = m.Loans.Count(),
                    AvgRetentionPeriod = m.Loans.Average(l => (int?)EF.Functions.DateDiffDay(l.LoanDate, l.ReturnDate) ?? 0),
                    LastLoanDate = m.Loans.Max(l => (DateOnly?)l.LoanDate)
                })
                .ToList();
        }

        public object GetBooksWithoutLoans()
        {
            return _context.Books
                .Where(b => !b.Loans.Any())
                .Select(b => new
                {
                    BookTitle = b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                    BookPublicationYear = b.PublicationYear
                })
                .ToList();
        }

        public object GetBooksWithAboveAveragePrice()
        {
            return _context.Books
                .Where(b => b.Publisher != null)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    Price = b.Price,
                    AvgPublisherPrice = b.Publisher.Books.Average(allBooks => allBooks.Price)
                })
                .Where(s => s.Price > s.AvgPublisherPrice)
                .ToList();
        }

        public object GetBooksLoanedIn2023()
        {
            return _context.Books
                .Where(b => b.Loans.Any(l => l.LoanDate.Year == 2023))
                .Select(b => new
                {
                    BookTitle = b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName,
                    Categories = string.Join(", ", b.BookCategories.Select(bc => bc.Category.Name)),
                    LoanCount = b.Loans.Count(l => l.LoanDate.Year == 2023)
                })
                .ToList();
        }

        public object GetActiveMembers()
        {
            var sixMonthsAgo = DateOnly.FromDateTime(DateTime.Now.AddMonths(-6));

            return _context.Members
                .Where(m => m.Loans.Count(l => l.LoanDate >= sixMonthsAgo) > 5)
                .Select(m => new
                {
                    MemberName = m.FirstName + " " + m.LastName,
                    MemberEmail = m.Email,
                    LoanCount = m.Loans.Count()
                })
                .ToList();
        }

        public object GetAuthorsWithCategories()
        {
            return _context.Authors
                .Where(a => a.Books.Any())
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Categories = a.Books
                    .SelectMany(b => b.BookCategories.Select(bc => bc.Category.Name))
                    .Distinct()
                    .ToList()
                })
                .OrderBy(res => res.AuthorName)
                .ToList();
        }

        public object GetCategoriesPopularityReport()
        {
            var fourMonthsAgo = DateOnly.FromDateTime(DateTime.Now.AddMonths(-4));

            var totalLoanCount = _context.Loans
                .Count(l => l.LoanDate >= fourMonthsAgo);

            if (totalLoanCount == 0)
            {
                return new List<object>();
            }

            return _context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    LoanCount = c.BookCategories
                        .SelectMany(bc => bc.Book.Loans)
                        .Count(l => l.LoanDate >= fourMonthsAgo)
                })
                .Where(res => res.LoanCount > 0)
                .Select(res => new
                {
                    CategoryName = res.CategoryName,
                    LoanCount = res.LoanCount,
                    Percentage = Math.Round(((double)res.LoanCount / totalLoanCount) * 100, 2)
                })
                .ToList();
        }
    }
}
