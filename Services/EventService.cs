using EventOAPI.Data;
using EventOAPI.Dto;
using EventOAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventOAPI.Services
{
    public class EventService
    {
        private readonly EventContext context;
        public EventService(EventContext context)
        {
            this.context = context;
        }
        public Event AddEvent(EventDto dto)
        {
            var user = context.Users.Include(u => u.Events).FirstOrDefault(u => u.Id == dto.UserId);
            user!.Events.Add(new Event
            {
                Name = dto.Name,
                Date = dto.Date,
                Duration = dto.Duration,
                Rules = dto.Rules,
                Price = dto.Price,
                SpaceId = dto.SpaceId,
                CreatedAt = DateTime.Now
            });

            context.SaveChanges();
            return context.Events.OrderBy(e => e.Id).Last();
        }
        //public bool RemoveEvent(int id)
        //{
        //    try
        //    {
        //        var evnt = context.Events.FirstOrDefault(e => e.Id == id);
        //        if (evnt != null)
        //        {
        //            var user = eventServices.GetUserById(evnt.UserId);
        //            user.Events.Remove(evnt);
        //            context.Events.Remove(evnt);
        //            context.SaveChanges();
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateEvent(Event evnt)
        //{
        //    try
        //    {
        //        var existingEvent = context.Events.FirstOrDefault(e => e.Id == evnt.Id);
        //        if (existingEvent != null)
        //        {
        //            var user = eventServices.GetUserById(evnt.UserId);
        //            user.Events.Remove(evnt);
        //            existingEvent.Name = evnt.Name;
        //            existingEvent.SpaceId = evnt.SpaceId;
        //            existingEvent.Date = evnt.Date;
        //            existingEvent.Time = evnt.Time;
        //            existingEvent.Duration = evnt.Duration;
        //            existingEvent.Rules = evnt.Rules;
        //            user.Events.Add(existingEvent);
        //            context.SaveChanges();
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public Event GetEventById(int id)
        {
            return context.Events.FirstOrDefault(e => e.Id == id)!;
        }

        public List<Event> GetAllEvents()
        {
            return context.Events.ToList();
        }
    }
}
