using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Code_First.Models
{
    internal class Loan
    {
        public int Id { get; set; }
        public DateOnly LoanDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        public DateOnly? DueDate { get; set; }

        public int BookId { get; set; }
        public int MemberId { get; set; }

        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
