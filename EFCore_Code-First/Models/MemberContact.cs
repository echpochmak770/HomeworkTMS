using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Code_First.Models
{
    internal class MemberContact
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }
    }
}
