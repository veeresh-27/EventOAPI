using EventOAPI.Data;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class UserServices
    {
        private readonly EventContext context;
        public UserServices(EventContext context)
        {
            this.context = context;
        }
        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public bool AddUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveUser(int id)
        {
            try
            {
                var users = context.Users.ToList();
                var user = users.FirstOrDefault(user => user.Id == id);
                if (user != null)
                {
                    context.Remove(user);
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

        public bool UpdateUser(User user)
        {
            try
            {
                var users = context.Users.ToList();
                var find = users.FirstOrDefault(u => u.Id == user.Id);
                if (find != null)
                {
                    find.Username = user.Username;
                    find.Password = user.Password;
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

        public User GetUserById(int id)
        {
            var users = context.Users.ToList();
            var user = users.FirstOrDefault(user => user.Id == id);
            return user!;
        }
    }
   
}
