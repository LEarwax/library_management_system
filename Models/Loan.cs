using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Models
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}