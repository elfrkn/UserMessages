using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UsersMessages.Controllers
{
   
    public class DefaultController : Controller
    {
        UsersMessageManager usersMessageManager = new UsersMessageManager(new EfUsersMessageDal());
        private readonly UserManager<AppUser> _userManager;

        public DefaultController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Inbox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = usersMessageManager.GetListReceiverMessage(p);
            return View(messageList);
        }

        public async Task<IActionResult> SendBox(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = usersMessageManager.GetListSenderMessage(p);
            return View(messageList);
        }

        public IActionResult InboxMessageDetails(int id)
        {
            UsersMessage userMessage = usersMessageManager.TGetById(id);
            return View(userMessage);
        }

        public IActionResult SendBoxMessageDetails(int id)
        {
            UsersMessage userMessage = usersMessageManager.TGetById(id);
            return View(userMessage);
        }



    }
}
