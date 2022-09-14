using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Models
{
    public class ReservationStatus
    {
        public int ReservationStatusID { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<Reservation>? Reservation { get; set; }
    }
}