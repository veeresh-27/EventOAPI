using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class AdminServices
    {
       
        private readonly EventContext context;

        private readonly SpaceServices space;
        public AdminServices(EventContext context, SpaceServices space)
        {
            this.context = context;
            this.space = space;
            
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
                        space.RemoveSpace(sp.Id);
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
    }
}
