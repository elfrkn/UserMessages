using Microsoft.AspNetCore.Mvc;

namespace UsersMessages.ViewComponents
{
    public class _FooterComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
