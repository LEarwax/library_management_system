using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime JoinedDate { get; set; }
        public int MemberStatusID { get; set; }
        public MemberStatus? MemberStatus { get; set; }
    }
}