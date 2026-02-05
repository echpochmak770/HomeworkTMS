using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Code_First.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int Price { get; set; }

        public int AuthorId { get; set; }
        public int? PublisherId { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
        public BookDetail BookDetail { get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
