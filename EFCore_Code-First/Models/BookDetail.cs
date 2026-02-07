using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Code_First.Models
{
    internal class BookDetail
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public string Edition { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
