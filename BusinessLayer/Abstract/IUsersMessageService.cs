using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUsersMessageService : IGenericService<UsersMessage>
    {
        List<UsersMessage> GetListSenderMessage(string p);
        List<UsersMessage> GetListReceiverMessage(string p);

        List<UsersMessage> GetListDeleteMessage();

       
    }
}
