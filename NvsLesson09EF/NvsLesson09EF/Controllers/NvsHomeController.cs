using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NvsLesson09EF.Models;

namespace NvsLesson09EF.Controllers
{
    public class NvsHomeController : Controller
    {
        private readonly ILogger<NvsHomeController> _logger;

        public NvsHomeController(ILogger<NvsHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NvsIndex()
        {
            return View();
        }

        public IActionResult NvsAbout()
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
