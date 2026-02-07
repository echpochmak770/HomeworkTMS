using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Code_First.Models
{
    internal class AuthorBiography
    {
        public int Id { get; set; }
        public string Education { get; set; }
        public string Awards { get; set; }
        public string BiographyText { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
