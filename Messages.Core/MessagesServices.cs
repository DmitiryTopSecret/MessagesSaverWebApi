using MessagesSaver.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages.Core
{
    public class MessagesServices : IMessagesServices
    {
        private AppDbContext _context;

        public MessagesServices(AppDbContext context)
        {
            _context = context;
        }

        public Message CreateMessage(Message message)
        {
            _context.Add(message);
            _context.SaveChanges();

            return message;
        }

        public Message GetMessage(int id)
        {
            return _context.Messages.First(m => m.Id == id);
        }

        public List<Message> GetMessages()
        {
            return _context.Messages.ToList();
        }

        public void DeleteMessage(int id)
        {
            var message = _context.Messages.First(m => m.Id == id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
        }

        public void EditMessage(Message message)
        {
            var editMessage = _context.Messages.First(m => m.Id == message.Id);
            editMessage.Value = message.Value;
            _context.SaveChanges();
        }

    }
}
