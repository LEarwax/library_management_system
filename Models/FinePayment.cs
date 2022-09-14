using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Models
{
    public class FinePayment
    {
        public int FinePaymentID { get; set; }
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
    }
}