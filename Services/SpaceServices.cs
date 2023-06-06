using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class SpaceServices
    {
        private readonly EventContext context;
        private readonly AdminServices admins;

        public SpaceServices(EventContext context,AdminServices admins)
        {
            this.context = context;
            this.admins = admins;
        }

        public List<Space> GetAllSpaces()
        {
            return context.Spaces.ToList();
        }

        public bool AddSpace(Space space)
        {
            try
            {
                context.Spaces.Add(space);
                var admin = (space.AdminId);
                admin.Spaces.Add(space);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveSpace(int id)
        {
            try
            {
                var space = context.Spaces.FirstOrDefault(s => s.Id == id);
                if (space != null)
                {
                    context.Spaces.Remove(space);
                    var admin =admins.GetAdminById(space.AdminId);
                    admin.Spaces.Remove(space);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateSpace(Space space)
        {
            try
            {
                var existingSpace = context.Spaces.FirstOrDefault(s => s.Id == space.Id);
                if (existingSpace != null)
                {
                    var admin = admins.GetAdminById(existingSpace.AdminId);
                    admin.Spaces.Remove(existingSpace);
                    existingSpace.Name = space.Name;
                    existingSpace.Capacity = space.Capacity;
                    existingSpace.Location = space.Location;
                    existingSpace.Amenities = space.Amenities;
                    admin.Spaces.Add(existingSpace);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Space GetSpaceById(int id)
        {
            return context.Spaces.FirstOrDefault(s => s.Id == id)!;
        }
    }
}
