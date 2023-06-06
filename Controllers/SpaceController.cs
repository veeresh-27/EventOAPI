using EventOAPI.Dto;
using EventOAPI.Models;
using EventOAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventOAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
        private readonly SpaceServices _spaceServices;

        public SpaceController(SpaceServices spaceServices) {
            _spaceServices = spaceServices;
        }

        [HttpGet("space/all")]
        public ActionResult<IEnumerable<Space>> GetAllSpace() 
        {
            return _spaceServices.GetAllSpaces();
        }

        [HttpPost("space/post")]
        public ActionResult<bool> PostSpace(Space space)
        {
            return _spaceServices.AddSpace(space);
        }

        [HttpGet("space/id")]
        public ActionResult<Space> GetSpaceById(int id)
        {
            return _spaceServices.GetSpaceById(id);
        }

        [HttpPut("space/update")]
        public ActionResult<bool> UpdateSpace(Space space)
        {
            return _spaceServices.UpdateSpace(space);
        }


        [HttpDelete("space/delete")]
        public ActionResult<bool> DeleteSpace(int id)
        {
            return _spaceServices.RemoveSpace(id);
        }


    }
}
