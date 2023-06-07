using EventOAPI.Dto;
using EventOAPI.Models;
using EventOAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventOAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly AdminServices _adminServices;

        public OwnerController(AdminServices adminServices)
        {
            _adminServices = adminServices;
        }
        [HttpGet("{ownerid}/spaces")]
        public ActionResult<IEnumerable<Space>> GetSpacesOfOwner(int ownerid)
        {
            return _adminServices.GetSpacesByOwnerId(ownerid);
        }
        [HttpPost("{ownerId}/spaces")]
        public ActionResult<Space> AddSpaceToOwner(int ownerId, SpaceDto dto)
        {
            return _adminServices.AddSpaceToOwner(ownerId, dto);

        }
        [HttpPut("{ownerId}/spaces/{spaceId}")]
        public ActionResult<ApiResponse> UpdateSpaceOfOwner(int ownerId, int spaceId, SpaceDto dto)
        {
            return new ApiResponse { Message = _adminServices.UpdateSpace(ownerId, spaceId, dto) };
        }
        [HttpDelete("{ownerId}/spaces/{spaceId}")]
        public ActionResult<ApiResponse> DeleteSpaceOfOwner(int ownerId, int spaceId)
        {
            return new ApiResponse { Message = _adminServices.RemoveSpaceByOwnerId(ownerId, spaceId) };

        }



    }
}
