using EventOAPI.Dto;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public interface IEventService
    {
        bool AddAttendeeToAnEvent(int eventId, int userId);
        bool AddChat(int eventId, ChatDto dto);
        Event AddEvent(EventDto dto);
        bool AddLike(int eventId);
        bool DeleteAttendeeFromAnEvent(int eventId, int userId);
        bool DeleteLike(int eventId);
        List<Event> GetAllEvents();
        List<DetailsDto> GetAttendeesOfAnEvent(int eventId);
        List<Chat> GetChatsOfAnEvent(int eventId);
        Event GetEventById(int id);
        List<Event> GetEventsByDate(DateTime date);
        bool RemoveEvent(int id);
        Event UpdateEvent(int eventId, EventDto evnt);
    }
}