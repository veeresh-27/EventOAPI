using EventOAPI.Data;
using EventOAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EventOAPI.Services
{
    public class SpaceService
    {
        private readonly EventContext _context;

        public SpaceService(EventContext context)
        {
            _context = context;
        }
        public Space GetSpaceById(int spaceId)
        {
            return _context.Spaces.Include(s => s.Events).FirstOrDefault(s => s.Id.Equals(spaceId))!;
        }
        public List<Space> GetAllSpaces()
        {
            return _context.Spaces.Include(s => s.Events).ToList();
        }
        public List<Event> GetEventsOfASpace(int spaceId)
        {
            var space = _context.Spaces.Include(s => s.Events).FirstOrDefault(s => s.Id.Equals(spaceId));
            return space!.Events.ToList();
        }
    }
}
