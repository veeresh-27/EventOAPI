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
            var newEvent = context.Events.OrderBy(e => e.Id).Last();

            context.InviteTokens.Add(new InviteToken { CreatedAt = DateTime.Now, EventId = newEvent.Id });

            context.SaveChanges();
            return newEvent;


        }
        public bool RemoveEvent(int id)
        {
            try
            {
                var evnt = context.Events.FirstOrDefault(e => e.Id == id);
                if (evnt != null)
                {
                    context.Events.Remove(evnt);
                    var token = context.InviteTokens.FirstOrDefault(i => i.EventId.Equals(evnt.Id))!;
                    context.InviteTokens.Remove(token);
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

        public Event UpdateEvent(int eventId, EventDto evnt)
        {
            var existingEvent = context.Events.FirstOrDefault(e => e.Id.Equals(eventId));
            if (existingEvent != null)
            {
                existingEvent.Name = evnt.Name;
                existingEvent.SpaceId = evnt.SpaceId;
                existingEvent.Date = evnt.Date;
                existingEvent.Duration = evnt.Duration;
                existingEvent.Rules = evnt.Rules;
                context.SaveChanges();
            }
            return existingEvent!;
        }

        public Event GetEventById(int id)
        {
            return context.Events.Include(e => e.Attendees).FirstOrDefault(e => e.Id == id)!;
        }

        public List<Event> GetAllEvents()
        {
            return context.Events.ToList();
        }
        public List<Event> GetEventsByDate(DateTime date)
        {
            return context.Events.Where(e => e.Date.Day.Equals(date.Day) && e.Date.Month.Equals(date.Month) && e.Date.Year.Equals(date.Year)).ToList();
        }

        internal List<EventAttendee> GetAttendeesOfAnEvent(int eventId)
        {
            return context.Events.Include(e => e.Attendees).FirstOrDefault(e => e.Id.Equals(eventId))!.Attendees.ToList();
        }
        internal bool AddAttendeeToAnEvent(int eventId, int userId)
        {
            var selectedEvent = context.Events.Include(e => e.Attendees).FirstOrDefault(e => e.Id.Equals(eventId));
            if (selectedEvent != null)
            {
                selectedEvent.Attendees.Add(new EventAttendee { EventId = eventId, UserId = userId, JoinedAt = DateTime.Now });
                context.SaveChanges();
                return true;

            }
            return false;

        }
        internal bool DeleteAttendeeFromAnEvent(int eventId, int userId)
        {
            var selectedEvent = context.Events.Include(e => e.Attendees).FirstOrDefault(e => e.Id.Equals(eventId));
            if (selectedEvent != null)
            {
                var attendee = selectedEvent.Attendees.First(a => a.UserId.Equals(userId));
                selectedEvent.Attendees.Remove(attendee);

                context.SaveChanges();
                return true;

            }
            return false;
        }
        internal bool AddLike(int eventId)
        {
            var selectedEvent = context.Events.FirstOrDefault(e => e.Id.Equals(eventId));
            if (selectedEvent != null)
            {
                selectedEvent.Likes += 1;
                context.SaveChanges();
                return true;
            }
            return false;

        }
        internal bool DeleteLike(int eventId)
        {
            var selectedEvent = context.Events.FirstOrDefault(e => e.Id.Equals(eventId));
            if (selectedEvent != null)
            {
                selectedEvent.Likes -= 1;
                context.SaveChanges();
                return true;
            }
            return false;

        }
        internal List<Chat> GetChatsOfAnEvent(int eventId)
        {

            var selectedEvent = context.Events.Include(e => e.Chats).FirstOrDefault(e => e.Id.Equals(eventId))!;
            return selectedEvent.Chats.ToList();
        }
        internal bool AddChat(int eventId, ChatDto dto)
        {
            var selectedEvent = context.Events.Include(e => e.Chats).FirstOrDefault(e => e.Id.Equals(eventId))!;
            if (selectedEvent != null)
            {
                selectedEvent.Chats.Add(new Chat
                {
                    UserId = dto.UserId,
                    EventId = dto.EventId,
                    Message = dto.Message,
                    SentAt = DateTime.Now
                });
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }

}
