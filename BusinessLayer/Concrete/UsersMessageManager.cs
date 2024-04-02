using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UsersMessageManager : IUsersMessageService
    {
        IUserMessageDal _userMessageDal;

        public UsersMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        public List<UsersMessage> GetListDeleteMessage()
        {
            return _userMessageDal.GetByFilter(x => x.Status == false);
        }

        public List<UsersMessage> GetListReceiverMessage(string p)
        {
            return _userMessageDal.GetByFilter(x => x.ReceiverMail == p && x.Status == true && x.IsDraft == false);

        }

        public List<UsersMessage> GetListSenderMessage(string p)
        {
            return _userMessageDal.GetByFilter(x => x.SenderMail == p && x.Status == true && x.IsDraft == false);

        }

        public void TDelete(int id)
        {
            _userMessageDal.Delete(id);
        }

        public UsersMessage TGetById(int id)
        {
            return _userMessageDal.GetByID(id);
        }

        public List<UsersMessage> TGetListAll()
        {
            return _userMessageDal.GetList();
        }

        public void TInsert(UsersMessage t)
        {
            _userMessageDal.Insert(t);
        }

        public void TUpdate(UsersMessage t)
        {
            _userMessageDal.Update(t);
        }
    }
}
