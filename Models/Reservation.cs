using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ReservationStatusID { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
    }
}