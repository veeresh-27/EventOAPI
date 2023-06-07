using EventOAPI.Data;
using EventOAPI.Models;

namespace EventOAPI.Services
{
    public class ChatServices
    {
        private readonly EventContext context;
        private readonly Models.EventService events;
        private readonly EventService eventsservices;

        public ChatServices(EventContext context, Models.EventService events, EventService eventsservices)
        {
            this.context = context;
            this.events = events;
            this.eventsservices = eventsservices;
        }
        public List<Chat> GetAllChats()
        {
            return context.Chats.ToList();
        }

        public bool AddChat(Chat chat)
        {
            try
            {
                context.Chats.Add(chat);
                var user = events.GetUserById(chat.UserId);
                var comm = eventsservices.GetEventById(chat.EventId);
                user.Chats.Add(chat);
                comm.Chats.Add(chat);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveChat(int id)
        {
            try
            {
                var chat = context.Chats.FirstOrDefault(m => m.Id == id);
                if (chat != null)
                {
                    var user = events.GetUserById(chat.UserId);
                    var Event = eventsservices.GetEventById(chat.EventId); user.Chats.Remove(chat);
                    Event.Chats.Remove(chat);
                    context.Chats.Remove(chat);
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



        public Chat GetChatById(int id)
        {
            return context.Chats.FirstOrDefault(m => m.Id == id)!;
        }
    }
}
