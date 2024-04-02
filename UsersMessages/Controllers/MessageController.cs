using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UsersMessages.Controllers
{
    public class MessageController : Controller
    {
        UsersMessageManager messageManager = new UsersMessageManager(new EfUsersMessageDal());
        private readonly UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = messageManager.GetListReceiverMessage(p);
            return View(messageList);
        }

        public IActionResult InboxMessageDetails(int id)
        {
            UsersMessage userMessage = messageManager.TGetById(id);
            return View(userMessage);
        }

        public async Task<IActionResult> Sendbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = messageManager.GetListSenderMessage(p);
            return View(messageList);
        }

        public IActionResult SendboxMessageDetails(int id)
        {
            UsersMessage userMessage = messageManager.TGetById(id);
            return View(userMessage);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(UsersMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = DateTime.Now;
            p.SenderMail = mail;
            p.SenderName = name;
            p.Status = true;
            p.IsDraft = false;
            p.IsRead = false;
            UserMessageContext c = new UserMessageContext();
            var usernamesurname = c.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            messageManager.TInsert(p);
            return RedirectToAction("Inbox");

        }

        public IActionResult TrashMessageList()
        {
            var values = messageManager.GetListDeleteMessage();
            return View(values);
        }
        public IActionResult TrashMessages(int id)
        {
            UserMessageContext _context = new UserMessageContext();
            var value = _context.UsersMessages.Where(x => x.UserMessageID == id).FirstOrDefault();
            value.Status = false;
            _context.SaveChanges();
            return RedirectToAction("TrashMessageList");
        }
        public IActionResult TrashOutMessages(int id)
        {
            UserMessageContext _context = new UserMessageContext();
            var value = _context.UsersMessages.Where(x => x.UserMessageID == id).FirstOrDefault();
            value.Status = true;
            _context.SaveChanges();
            return RedirectToAction("TrashMessageList");
        }

    }
}
