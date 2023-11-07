using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VanillaMVC.Models;

namespace VanillaMVC.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            _logger.LogInformation("Someone Viewed the Index");

            if (Request.Query.ContainsKey("error")) {
                throw new Exception("Someone found the error inducer.");
            }

            return View();
        }

        public IActionResult Privacy() {
            _logger.LogWarning("Someone is interested in the Privacy Policy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}