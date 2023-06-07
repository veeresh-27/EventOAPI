using EventOAPI.Data;
using EventOAPI.Dto;
using EventOAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public bool RemoveSpaceByOwnerId(int ownerId, int spaceId)
        {
            try
            {
                var owner = context.Admins.Include(a => a.Spaces).FirstOrDefault(a => a.Id.Equals(ownerId));
                if (owner != null)
                {
                    var space = owner.Spaces.FirstOrDefault(s => s.Id == spaceId);
                    owner.Spaces.Remove(space!);
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
        public bool UpdateSpace(int ownerId, int spaceId, SpaceDto spaceDto)
        {
            try
            {
                var owner = context.Admins.Include(a => a.Spaces).FirstOrDefault(a => a.Id == ownerId);
                var space = owner!.Spaces.FirstOrDefault(s => s.Id == spaceId);
                if (owner != null && space != null)
                {
                    space.Capacity = spaceDto.Capacity;
                    space.Location = spaceDto.Location;
                    space.Name = spaceDto.Name;
                    space.Amenities = spaceDto.Amenities;
                    space.Price = spaceDto.Price;
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
        public List<Space> GetSpacesByOwnerId(int ownerId)
        {
            return context.Spaces.Where(s => s.AdminId == ownerId).Include(s => s.Events).ToList();
        }
        public Space AddSpaceToOwner(int ownerId, SpaceDto dto)
        {
            var owner = context.Admins.Include(a => a.Spaces).FirstOrDefault(a => a.Id.
            Equals(ownerId))!;
            owner.Spaces.Add(new Space
            {
                AdminId = ownerId,
                Name = dto.Name,
                Capacity = dto.Capacity,
                Location = dto.Location,
                Amenities = dto.Amenities,
                Price=dto.Price,
                CreatedAt = DateTime.Now

            });
            context.SaveChanges();
            return context.Spaces.Include(a => a.Admin).Where(a => a.AdminId.Equals(ownerId)).OrderBy(s => s.Id).Last();


        }

        
    }
}
