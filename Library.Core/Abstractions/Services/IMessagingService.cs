using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Abstractions.Services
{
    public interface IMessagingService
    {
        bool SendMessage(int memberId, string subject, string message);

        List<Message> GetMessagesForUser(int userid);
    }
}
