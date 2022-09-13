using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Models
{
    public class MemberStatus
    {
        public int MemberStatusID { get; set; }
        public string StatusValue { get; set; } = string.Empty;
        public List<Member>? Members { get; set; }
    }
}