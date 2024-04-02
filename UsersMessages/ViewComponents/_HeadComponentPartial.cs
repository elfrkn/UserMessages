using Microsoft.AspNetCore.Mvc;

namespace UsersMessages.ViewComponents
{
	public class _HeadComponentPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
