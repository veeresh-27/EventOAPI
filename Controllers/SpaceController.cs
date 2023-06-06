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
        private readonly AdminServices _adminServices;

        public SpaceController(AdminServices adminervices) {
            _adminServices = adminervices;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Space>> GetAllSpace() 
        {
            return _adminServices.GetAllSpaces();
        }

        [HttpPost("create")]
        public ActionResult<bool> PostSpace(Space space)
        {
            return _adminServices.AddSpace(space);
        }

        [HttpGet("id")]
        public ActionResult<Space> GetSpaceById(int id)
        {
            return _adminServices.GetSpaceById(id);
        }

        [HttpPut("update")]
        public ActionResult<bool> UpdateSpace(Space space)
        {
            return _adminServices.UpdateSpace(space);
        }


        [HttpDelete("delete")]
        public ActionResult<bool> DeleteSpace(int id)
        {
            return _adminServices.RemoveSpace(id);
        }


    }
}
