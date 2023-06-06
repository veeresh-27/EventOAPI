using EventOAPI.Dto;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class AdminServices
    {
       
        private readonly EventContext context;
        public AdminServices(EventContext context)
        {
            this.context = context;
            
        }
        public List<Admin> GetAllAdmins()
        {
            return context.Admins.ToList();
        }
        public bool AddAdmin(Admin admin)
        {
            try
            {
                context.Admins.Add(admin);

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveAdmin(int id)
        {
            try
            {
                var admin = context.Admins.FirstOrDefault(a => a.Id == id);
                if (admin != null)
                {
                    foreach (var sp in admin.Spaces)
                    {
                        RemoveSpace(sp.Id);
                    }
                    context.Admins.Remove(admin);
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
        public bool UpdateAdmin(Admin admin)
        {
            try
            {
                var existingAdmin = context.Admins.FirstOrDefault(a => a.Id == admin.Id);
                if (existingAdmin != null)
                {
                    existingAdmin.Username = admin.Username;
                    existingAdmin.Password = admin.Password;
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
        public Admin GetAdminById(int id)
        {
            return context.Admins.FirstOrDefault(a => a.Id == id)!;
        }
        public List<Space> GetAllSpaces()
        {
            return context.Spaces.ToList();
        }

        public bool AddSpace(SpaceDto tempSpace)
        {
            try
            {
                Space space = new Space();
                space.Name = tempSpace.Name;
                space.AdminId = tempSpace.AdminId;
                space.Capacity = tempSpace.Capacity;
                space.Location =    tempSpace.Location;
                space.Amenities = tempSpace.Amenities;
                space.CreatedAt = tempSpace.CreatedAt;
                context.Spaces.Add(space);
                var admin = GetAdminById(space.AdminId);
                space.Admin = admin;
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
                    var admin = GetAdminById(space.AdminId);
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
        public bool UpdateSpace(SpaceDto space)
        {
            try
            {
                var existingSpace = context.Spaces.FirstOrDefault(s => s.Id == space.Id);
                if (existingSpace != null)
                {
                    var admin = GetAdminById(existingSpace.AdminId);
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
