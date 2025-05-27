using Microsoft.AspNetCore.Mvc;
using NvsLab06.Models;

namespace NvsLab06.Controllers
{
    public class NvsEmployeeController : Controller
    {
        private static List<NvsEmployee> NvsListEmployee = new List<NvsEmployee>
        {
            new NvsEmployee { NvsId = 1, NvsName = "Nguyễn Văn Sơn", NvsBirthDay = new DateTime(2005, 11, 23), NvsEmail = "nvson2311@gmail.com", NvsPhone = "0974326194", NvsSalary = 1000, NvsStatus = true },
            new NvsEmployee { NvsId = 2, NvsName = "Trần Thị B", NvsBirthDay = new DateTime(1992, 5, 10), NvsEmail = "b@example.com", NvsPhone = "0987654321", NvsSalary = 1200, NvsStatus = true },
            new NvsEmployee { NvsId = 3, NvsName = "Lê Văn C", NvsBirthDay = new DateTime(1988, 3, 15), NvsEmail = "c@example.com", NvsPhone = "0912345678", NvsSalary = 1300, NvsStatus = false },
            new NvsEmployee { NvsId = 4, NvsName = "Phạm Thị D", NvsBirthDay = new DateTime(1995, 7, 22), NvsEmail = "d@example.com", NvsPhone = "0909123456", NvsSalary = 1100, NvsStatus = true },
            new NvsEmployee { NvsId = 5, NvsName = "Hoàng Văn E", NvsBirthDay = new DateTime(1993, 11, 5), NvsEmail = "e@example.com", NvsPhone = "0932123456", NvsSalary = 1050, NvsStatus = false }
        };
        public IActionResult NvsIndex()
        {
            return View(NvsListEmployee);
        }
        public IActionResult NvsCreate()
        {
            return View(); // Trả về view form thêm mới nhân viên
        }
        [HttpPost]
        public IActionResult NvsCreate(NvsEmployee employee)
        {
            employee.NvsId = NvsListEmployee.Max(e => e.NvsId) + 1;
            NvsListEmployee.Add(employee);

            // Sau khi thêm xong, quay lại danh sách
            return RedirectToAction("NvsIndex");
        }
        // GET: NvsEmployee/NvsEdit/5
        public IActionResult NvsEdit(int id)
        {
            // Tìm nhân viên có ID tương ứng
            var employee = NvsListEmployee.FirstOrDefault(e => e.NvsId == id);

            if (employee == null)
            {
                return NotFound();
            }

            // Trả về view hiển thị form chỉnh sửa
            return View(employee);
        }
        [HttpPost]
        public IActionResult NvsEdit(NvsEmployee employee)
        {
            var existing = NvsListEmployee.FirstOrDefault(e => e.NvsId == employee.NvsId);
            if (existing == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin
            existing.NvsName = employee.NvsName;
            existing.NvsBirthDay = employee.NvsBirthDay;
            existing.NvsEmail = employee.NvsEmail;
            existing.NvsPhone = employee.NvsPhone;
            existing.NvsSalary = employee.NvsSalary;
            existing.NvsStatus = employee.NvsStatus;

            return RedirectToAction("NvsIndex");
        }
        // GET: NvsEmployee/NvsDelete/5
        public IActionResult NvsDelete(int id)
        {
            var employee = NvsListEmployee.FirstOrDefault(e => e.NvsId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee); // Trả về view xác nhận xóa
        }
        [HttpPost, ActionName("NvsDelete")]
        public IActionResult NvsDeleteConfirmed(int NvsId)
        {
            var employee = NvsListEmployee.FirstOrDefault(e => e.NvsId == NvsId);
            if (employee != null)
            {
                NvsListEmployee.Remove(employee);
            }

            return RedirectToAction("NvsIndex");
        }




    }
}
