using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NvsLesson07.Models;

namespace NvsLesson07.Controllers
{
    public class NvsEmployeeController : Controller
    {
        // Mock Data:
        private static List<NvsEmployee> tvcListEmployee = new List<NvsEmployee>()
        {
            new NvsEmployee
            {
                NvsId = 231090009,
                NvsName = "Nguyễn Văn Sơn",
                NvsBirthDay = new DateTime(2005, 11, 23),
                NvsEmail = "nvson2311@gmail.com",
                NvsPhone = "0974326194",
                NvsSalary = 12000000m,
                NvsStatus = true
            },
            new NvsEmployee
            {
                NvsId = 2,
                NvsName = "Trần Thị B",
                NvsBirthDay = new DateTime(1992, 8, 15),
                NvsEmail = "tranthib@example.com",
                NvsPhone = "0912345678",
                NvsSalary = 13500000m,
                NvsStatus = true
            },
            new NvsEmployee
            {
                NvsId = 3,
                NvsName = "Lê Văn C",
                NvsBirthDay = new DateTime(1988, 3, 22),
                NvsEmail = "levanc@example.com",
                NvsPhone = "0934567890",
                NvsSalary = 10000000m,
                NvsStatus = false
            },
            new NvsEmployee
            {
                NvsId = 4,
                NvsName = "Phạm Thị D",
                NvsBirthDay = new DateTime(1995, 11, 5),
                NvsEmail = "phamthid@example.com",
                NvsPhone = "0976543210",
                NvsSalary = 15000000m,
                NvsStatus = true
            },
            new NvsEmployee
            {
                NvsId = 5,
                NvsName = "Đỗ Văn E",
                NvsBirthDay = new DateTime(1991, 7, 18),
                NvsEmail = "dovane@example.com",
                NvsPhone = "0981122334",
                NvsSalary = 11000000m,
                NvsStatus = false
            }
        };
        // GET: NvsEmployeeController
        public ActionResult NvsIndex()
        {
            return View(tvcListEmployee);
        }

        // GET: NvsEmployeeController/NvsDetails/5
        public ActionResult NvsDetails(int id)
        {
            var tvcEmployee = tvcListEmployee.FirstOrDefault(x => x.NvsId == id);
            return View(tvcEmployee);
        }

        // GET: NvsEmployeeController/NvsCreate
        public ActionResult NvsCreate()
        {
            var tvcEmployee = new NvsEmployee();
            return View(tvcEmployee);
        }

        // POST: NvsEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvsCreate(NvsEmployee tvcModel)
        {
            try
            {
                // Thêm mới nhân viên vào list
                tvcModel.NvsId = tvcListEmployee.Max(x => x.NvsId) + 1;
                tvcListEmployee.Add(tvcModel);
                return RedirectToAction(nameof(NvsIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvsEmployeeController/NvsEdit/5
        public ActionResult NvsEdit(int id)
        {
            var tvcEmployee = tvcListEmployee.FirstOrDefault(x => x.NvsId == id);
            return View(tvcEmployee);
        }

        // POST: NvsEmployeeController/NvsEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NvsEdit(int id, NvsEmployee tvcModel)
        {
            try
            {
                for (int i = 0; i < tvcListEmployee.Count(); i++)
                {
                    if (tvcListEmployee[i].NvsId == id)
                    {
                        tvcListEmployee[i] = tvcModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(NvsIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvsEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NvsEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
