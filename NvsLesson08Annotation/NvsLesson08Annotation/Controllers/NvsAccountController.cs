using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NvsLesson08Annotation.Models;
using NvsLesson08Annotation.Models;

namespace NvsLesson08Annotation.Controllers
{


    public class NvsAccountController : Controller
    {
        private static List<NvsAccount> nvsListAccount = new List<NvsAccount>()
        {
            new NvsAccount
                {
                    NvsId = 230022113,
                    NvsFullName = "Nguyễn Văn Sơn",
                    NvsEmail = "nvson2311@gmail.com",
                    NvsPhone = "0974326194",
                    NvsAddress = "Lớp K23CNT2",
                    NvsAvatar = "nvson.jpg",
                    NvsBirthday = new DateTime(2005, 11, 23),
                    NvsGender = "Nam",
                    NvsPassword = "123456789",
                    NvsFacebook = "https://www.facebook.com/nguyen.van.son.223480?locale=vi_VN"
                },
                new NvsAccount
                {
                    NvsId = 2,
                    NvsFullName = "Trần Thị B",
                    NvsEmail = "tranthib@example.com",
                    NvsPhone = "0987654321",
                    NvsAddress = "456 Đường B, Quận 3, TP.HCM",
                    NvsAvatar = "avatar2.jpg",
                    NvsBirthday = new DateTime(1992, 8, 15),
                    NvsGender = "Nữ",
                    NvsPassword = "password2",
                    NvsFacebook = "https://facebook.com/tranthib"
                },
                new NvsAccount
                {
                    NvsId = 3,
                    NvsFullName = "Lê Văn C",
                    NvsEmail = "levanc@example.com",
                    NvsPhone = "0911222333",
                    NvsAddress = "789 Đường C, Quận 5, TP.HCM",
                    NvsAvatar = "avatar3.jpg",
                    NvsBirthday = new DateTime(1988, 12, 1),
                    NvsGender = "Nam",
                    NvsPassword = "password3",
                    NvsFacebook = "https://facebook.com/levanc"
                },
                new NvsAccount
                {
                    NvsId = 4,
                    NvsFullName = "Phạm Thị D",
                    NvsEmail = "phamthid@example.com",
                    NvsPhone = "0909876543",
                    NvsAddress = "321 Đường D, Quận 7, TP.HCM",
                    NvsAvatar = "avatar4.jpg",
                    NvsBirthday = new DateTime(1995, 3, 10),
                    NvsGender = "Nữ",
                    NvsPassword = "password4",
                    NvsFacebook = "https://facebook.com/phamthid"
                },
                new NvsAccount
                {
                    NvsId = 5,
                    NvsFullName = "Hoàng Văn E",
                    NvsEmail = "hoangvane@example.com",
                    NvsPhone = "0933444555",
                    NvsAddress = "654 Đường E, Quận 10, TP.HCM",
                    NvsAvatar = "avatar5.jpg",
                    NvsBirthday = new DateTime(1991, 7, 22),
                    NvsGender = "Nam",
                    NvsPassword = "password5",
                    NvsFacebook = "https://facebook.com/hoangvane"
                }
        };
        // GET: NvsAccountController
        public ActionResult NvsIndex()
        {
            return View(nvsListAccount);
        }

        // GET: NvsAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NvsAccountController/Create
        public ActionResult NvsCreate()
        {
            var nvsModel = new NvsAccount();
            return View(nvsModel);
        }

        // POST: NvsAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvsCreate(NvsAccount nvsModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Giả sử bạn có DbContext tên _context đã được Inject trong Controller
                    //_context.NvsAccounts.Add(nvsModel);
                    //_context.SaveChanges();
                    nvsListAccount.Add(nvsModel);
                    return RedirectToAction(nameof(NvsIndex));
                }

                // Nếu dữ liệu không hợp lệ, trả về View để người dùng sửa
                return View(nvsModel);
            }
            catch (Exception ex)
            {
                // Bạn có thể log lỗi ở đây nếu cần
                ModelState.AddModelError("", "Có lỗi xảy ra khi thêm mới: " + ex.Message);
                return View(nvsModel);
            }
        }

        // GET: NvsAccountController/Edit/5
        public ActionResult NvsEdit(int id)
        {

            return View();
        }

        // POST: NvsAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvsEdit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(NvsIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvsAccountController/Delete/5
        public ActionResult NvsDelete(int id)
        {
            return View();
        }

        // POST: NvsAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvsDelete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(NvsIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}