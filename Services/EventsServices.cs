using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class EventsServices
    {
        private readonly EventContext context;
        private readonly UserServices eventServices;
       // private readonly EventServices eventService;
    public EventsServices(EventContext context,UserServices eventServices)
        {
            this.context = context; 
            this.eventServices = eventServices;
        }
        public bool AddEvent(Event evnt)
        {
            try
            {
                context.Events.Add(evnt);
                var user = eventServices.GetUserById(evnt.UserId);
                user.Events.Add(evnt);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool RemoveEvent(int id)
        {
            try
            {
                var evnt = context.Events.FirstOrDefault(e => e.Id == id);
                if (evnt != null)
                {
                    var user = eventServices.GetUserById(evnt.UserId);
                    user.Events.Remove(evnt);
                    context.Events.Remove(evnt);
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

        public bool UpdateEvent(Event evnt)
        {
            try
            {
                var existingEvent = context.Events.FirstOrDefault(e => e.Id == evnt.Id);
                if (existingEvent != null)
                {
                    var user = eventServices.GetUserById(evnt.UserId);
                    user.Events.Remove(evnt);
                    existingEvent.Name = evnt.Name;
                    existingEvent.SpaceId = evnt.SpaceId;
                    existingEvent.Date = evnt.Date;
                    existingEvent.Time = evnt.Time;
                    existingEvent.Duration = evnt.Duration;
                    existingEvent.Rules = evnt.Rules;
                    user.Events.Add(existingEvent);
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

        public Event GetEventById(int id)
        {
            return context.Events.FirstOrDefault(e => e.Id == id)!;
        }
    }
}
