using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Code_First.Models
{
    internal class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly MembershipDate { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public MemberContact MemberContact { get; set; }
    }
}
