using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_management_system.Data.MemberRepository
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<Member> GetMemberByIDAsync(int memberID);
        Task<int> AddMemberAsync(Member member);
        Task<Member> UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(int memberID);
    }
}