using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library_management_system.Dtos.Member;
using library_management_system.Services.MemberService;
using Microsoft.AspNetCore.Mvc;

namespace library_management_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetMemberDto>>> GetAllAsync()
        {
            return Ok(await _memberService.GetMembersAsync());
        }

        [HttpGet("{memberID}")]
        public async Task<ActionResult<GetMemberDto>> GetOneAsync(int memberID)
        {
            return Ok(await _memberService.GetMemberByIDAsync(memberID));
        }

        [HttpPost]
        public async Task<ActionResult<GetMemberDto>> AddMemberAsync([FromBody] AddMemberDto newMember)
        {
            return Ok(await _memberService.AddMemberAsync(newMember));
        }

        [HttpPut]
        public async Task<ActionResult<GetMemberDto>> UpdateMemberAsync([FromBody] UpdateMemberDto updatedMember)
        {
            return Ok(await _memberService.UpdateMemberAsync(updatedMember));
        }

        [HttpDelete("{memberID}")]
        public async Task<ActionResult<string>> DeleteMemberAsync(int memberID)
        {
            return Ok(await _memberService.DeleteMemberAsync(memberID));
        }
    }
}