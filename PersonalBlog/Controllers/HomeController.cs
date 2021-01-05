using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalBlog.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using PersonalBlog.Interfaces;

namespace PersonalBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IDataService dataService, ILogger<HomeController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Post> model = _dataService.GetAll().Result;
            return View(model);
        }

        [Route("Post")]
        [HttpGet]
        public async Task<IActionResult> CreatePost(Post model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Validation", "Please provide all values.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post model)
        {
            await _dataService.Create(model);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
