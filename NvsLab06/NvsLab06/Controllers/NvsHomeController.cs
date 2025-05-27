using Microsoft.AspNetCore.Mvc;
using NvsLab06.Models;
using System.Diagnostics;

namespace NvsLab06.Controllers
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
        public IActionResult NvsThongTinSinhVien()
        {
            // Giả lập dữ liệu sinh viên (có thể thay bằng từ database)
            var sinhvien = new NvsSinhVien
            {
                MSV = 1,
                HoTen = "Nguyễn Văn Sơn",
                Tuoi = 20,
                Lop = "CNTT2"
            };

            return View(sinhvien); // Truyền model sang view
        }
    }
}
