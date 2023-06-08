using EventOAPI.Dto;
using EventOAPI.Models;
using EventOAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventOAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunitiesServices _service;

        public CommunityController(ICommunitiesServices service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Community>> GetAll()
        {
            return _service.GetAllCommunities();
        }
        [HttpGet("{communityId}")]
        public ActionResult<Community> GetCommunity(int communityId)
        {
            return _service.GetCommunityById(communityId);
        }
        [HttpPost]
        public ActionResult<Community> CreateCommunity(CommunityDto dto)
        {
            return _service.AddCommunity(dto);
        }
        [HttpPut("{communityId}")]
        public ActionResult<Community> UpdateCommunity(int communityId, CommunityDto dto)
        {
            return _service.UpdateCommunity(communityId, dto);
        }
        [HttpDelete("{communityId}")]
        public ActionResult<ApiResponse> DeleteCommunity(int communityId)
        {
            return new ApiResponse { Message = _service.RemoveCommunity(communityId) };
        }
        [HttpPost("{communityId}/members")]
        public ActionResult<IEnumerable<DetailsDto>> GeCommunityMembers(int communityId)
        {
            return _service.GetCommunityMembers(communityId);
        }
        [HttpPost("{communityId}/add/{memberId}")]
        public ActionResult<ApiResponse> AddMemeberToCommunity(int communityId, int memberId)
        {
            return new ApiResponse { Message = _service.AddMembeToCommunity(communityId, memberId) };
        }
        [HttpDelete("{communityId}/add/{memberId}")]
        public ActionResult<ApiResponse> RemoveMemberFromCommunity(int communityId, int memberId)
        {
            return new ApiResponse { Message = _service.RemoveMemberFromCommunity(communityId, memberId) };
        }
        [HttpGet("{communityId}/events")]
        public ActionResult<IEnumerable<Event>> GetCommunityEvents(int communityId)
        {
            return _service.GetCommunityEvents(communityId);
        }
        [HttpPost("{communityId}/events/{eventId}")]
        public ActionResult<ApiResponse> AddEventToCommunity(int communityId, int eventId)
        {
            return new ApiResponse { Message = _service.AddEventToCommunity(communityId, eventId) };
        }
        [HttpDelete("{communityId}/events/{eventId}")]
        public ActionResult<ApiResponse> DeleteEventFromCommunity(int communityId, int eventId)
        {
            return new ApiResponse { Message = _service.DeleteEventFromCommunity(communityId, eventId) };
        }
    }
}
