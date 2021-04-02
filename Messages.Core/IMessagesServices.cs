using MessagesSaver.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Core
{
    public interface IMessagesServices
    {
        Message CreateMessage(Message message);
        Message GetMessage(int id);

        List<Message> GetMessages();

        void DeleteMessage(int id);

        void EditMessage(Message message);
    }
}
