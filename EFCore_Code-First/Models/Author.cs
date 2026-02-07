using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Code_First.Models
{
    internal class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Country { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
        public AuthorBiography AuthorBiography { get; set; }
    }
}
