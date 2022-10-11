using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system.Dtos.Member;

namespace library_management_system.Services.MemberService
{
    public interface IMemberService
    {
        Task<ServiceResponse<List<GetMemberDto>>> GetMembersAsync();
        Task<ServiceResponse<GetMemberDto>> GetMemberByIDAsync(int memberID);
        Task<ServiceResponse<object>> AddMemberAsync(AddMemberDto addMemberDto);
        Task<ServiceResponse<GetMemberDto>> UpdateMemberAsync(UpdateMemberDto updateMemberDto);
        Task<ServiceResponse<string>> DeleteMemberAsync(int memberID);
    }
}