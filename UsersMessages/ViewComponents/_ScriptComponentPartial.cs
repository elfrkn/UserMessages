using Microsoft.AspNetCore.Mvc;

namespace UsersMessages.ViewComponents
{
    public class _ScriptComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
