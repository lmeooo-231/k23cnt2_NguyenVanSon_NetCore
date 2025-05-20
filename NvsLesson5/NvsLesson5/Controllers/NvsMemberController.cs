using Microsoft.AspNetCore.Mvc;
using NvsLesson05Model.Models.DataModels;

namespace NvsLesson05Model.Controllers
{
    public class NvsMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NvsGetMember()
        {
            var NvsMember = new NvsMember();
            NvsMember.NvsMemberId = Guid.NewGuid().ToString();
            NvsMember.NvsUserName = "Sonw";
            NvsMember.NvsFullName = "Nguyễn Văn Sơn";
            NvsMember.NvsPassword = "123456";
            NvsMember.NvsEmail = "nvson2311@gmail.com";

            ViewBag.NvsMember = NvsMember;
            return View();
        }
    }
}