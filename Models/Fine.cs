using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Models
{
    public class Fine
    {
        public int FineID { get; set; }
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public int LoanID { get; set; }
        public Loan Loan { get; set; }
        public DateTime FineDate { get; set; }
        public double FineAmount { get; set; }
    }
}