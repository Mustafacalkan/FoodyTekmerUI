using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FoodyTekmerWebUI.Controllers
{
	public class CategoryController : Controller
	{
		FoodyContext context = new FoodyContext();
		public IActionResult Index()
		{
			var value = context.Categories.ToList();
			return View(value);
		}
		public IActionResult CreateCategory()
		{
			return View();
		}
		[HttpGet]
		public IActionResult EditCategory()
		{
			return View();
		}
		[HttpPost]
        public IActionResult EditCategory(Category p)
        {
			context.Categories.Add(p);
			context.SaveChanges();
            return RedirectToAction("Index");
        }
		public IActionResult DeleteCategory(int Id)
		{
			var value = context.Categories.Find(Id);
			context.Categories.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateCategory(int Id)
		{
			var value =context.Categories.Find(Id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateCategory(Category p)
		{
			context.Categories.Update(p);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

    }
}
