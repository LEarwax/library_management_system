using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace library_management_system.Data.MemberRepository
{
    public class MemberRepository : IMemberRepository
    {

        private readonly DataContext _context;

        public MemberRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member.MemberID;
        }

        public async Task DeleteMemberAsync(int memberID)
        {
            var dbMember = await _context.Members.FirstAsync(m => m.MemberID == memberID);
            _context.Members.Remove(dbMember);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Member>> GetCategoriesAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> GetMemberByIDAsync(int memberID)
        {
            return await _context.Members.FirstAsync(m => m.MemberID == memberID);
        }

        public async Task<Member> UpdateMemberAsync(Member member)
        {
            var dbMember = await _context.Members.FirstAsync(m => m.MemberID == member.MemberID);
            dbMember.MemberStatusID = member.MemberStatusID;
            dbMember.FirstName = member.FirstName;
            dbMember.LastName = member.LastName;
            await _context.SaveChangesAsync();
            return member;
        }
    }
}