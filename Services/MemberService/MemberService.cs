using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system.Dtos.Member;
using library_management_system.Data.MemberRepository;
using AutoMapper;

namespace library_management_system.Services.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<object>> AddMemberAsync(AddMemberDto addMemberDto)
        {
            ServiceResponse<object> response = new ServiceResponse<object>();

            try
            {
                var memberID = await _memberRepository.AddMemberAsync(_mapper.Map<Member>(addMemberDto));
                response.Data = new { MemberID = memberID };
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;                
            }

            return response;
        }

        public async Task<ServiceResponse<string>> DeleteMemberAsync(int memberID)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            
            try
            {
                await _memberRepository.DeleteMemberAsync(memberID);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;
            }

            return response;
        }

        public async Task<ServiceResponse<GetMemberDto>> GetMemberByIDAsync(int memberID)
        {
            ServiceResponse<GetMemberDto> response = new ServiceResponse<GetMemberDto>();

            try
            {
                var dbMember = await _memberRepository.GetMemberByIDAsync(memberID);
                response.Data = _mapper.Map<GetMemberDto>(dbMember);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;   
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetMemberDto>>> GetMembersAsync()
        {
            ServiceResponse<List<GetMemberDto>> response = new ServiceResponse<List<GetMemberDto>>();

            try
            {
                var dbMembers = await _memberRepository.GetMembersAsync();
                response.Data = _mapper.Map<List<GetMemberDto>>(dbMembers);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;
            }

            return response;
        }

        public async Task<ServiceResponse<GetMemberDto>> UpdateMemberAsync(UpdateMemberDto updateMemberDto)
        {
            ServiceResponse<GetMemberDto> response = new ServiceResponse<GetMemberDto>();

            try
            {
                var dbMember = await _memberRepository.UpdateMemberAsync(_mapper.Map<Member>(updateMemberDto));
                response.Data = _mapper.Map<GetMemberDto>(dbMember);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.StackTrace = ex.StackTrace;
            }

            return response;
        }
    }
}