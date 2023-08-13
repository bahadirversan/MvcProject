using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessageListInbox(string p);
        List<Message> GetMessageListSendbox(string p);
        void AddMessage(Message message);
        Message GetById(int id);
        void DeleteMessage(Message message);
        void UpdateMessage(Message message);
    }
}
