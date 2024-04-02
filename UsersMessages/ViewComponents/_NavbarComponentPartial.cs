using Microsoft.AspNetCore.Mvc;

namespace UsersMessages.ViewComponents
{
    public class _NavbarComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
