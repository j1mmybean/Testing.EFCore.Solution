using ISpan.Inseparable.BLL;
using ISpan.Inseparable.SqlDataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Testing.EFCore.MVC.Controllers
{
	public class ArticleController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		private ArticleRepository articleRepository;
		private ArticleService articleService;

		public ArticleController()
		{
			articleRepository = new ArticleRepository();
			articleService = new ArticleService(articleRepository);
		}

		public IActionResult List()
		{
			IEnumerable<ArticleSearchDto> arcticles = articleService.Search(null, null, null, null);
			return View(arcticles);
		}
	}
}
