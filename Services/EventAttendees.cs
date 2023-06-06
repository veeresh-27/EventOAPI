using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class EventAttendees
    {
        private readonly EventContext context;
        private readonly EventService events;
        private readonly EventsServices eventsservices;
        public EventAttendees(EventContext context, EventService events, EventsServices eventsservices)
        {
            this.context = context;
            this.events = events;
            this.eventsservices = eventsservices;
        }


        public List<EventAttendee> GetAllEventAttendees()
        {
            return context.EventAttendees.ToList();
        }

        public bool AddEventAttendee(EventAttendee attendee)
        {
            try
            {
                context.EventAttendees.Add(attendee);
                var user = events.GetUserById(attendee.UserId);
                user.AttendedEvents.Add(attendee);
                var ev = eventsservices.GetEventById(attendee.EventId);
                ev.Attendees.Add(attendee);

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveEventAttendee(int id)
        {
            try
            {
                var attendee = context.EventAttendees.FirstOrDefault(a => a.Id == id);
                if (attendee != null)
                {
                    var user = events.GetUserById(attendee.UserId);
                    user.AttendedEvents.Remove(attendee);
                    var ev = eventsservices.GetEventById(attendee.EventId);
                    ev.Attendees.Remove(attendee);
                    context.EventAttendees.Remove(attendee);
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

        public bool UpdateEventAttendee(EventAttendee attendee)
        {
            try
            {
                var existingAttendee = context.EventAttendees.FirstOrDefault(a => a.Id == attendee.Id);
                if (existingAttendee != null)
                {
                    var user = events.GetUserById(attendee.UserId);
                    user.AttendedEvents.Remove(attendee);
                    var ev = eventsservices.GetEventById(attendee.EventId);
                    ev.Attendees.Remove(attendee);
                    existingAttendee.UserId = attendee.UserId;
                    existingAttendee.EventId = attendee.EventId;
                    user.AttendedEvents.Add(attendee);
                    ev.Attendees.Add(attendee);
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

        public EventAttendee GetEventAttendeeById(int id)
        {
            return context.EventAttendees.FirstOrDefault(a => a.Id == id)!;
        }


    }
}
