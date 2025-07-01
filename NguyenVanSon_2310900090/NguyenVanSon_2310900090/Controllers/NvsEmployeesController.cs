using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenVanSon_2310900090.Models;

namespace NguyenVanSon_2310900090.Controllers
{
    public class NvsEmployeesController : Controller
    {
        private readonly NguyenVanSon2310900090Context _context;

        public NvsEmployeesController(NguyenVanSon2310900090Context context)
        {
            _context = context;
        }

        // GET: NvsEmployees
        public async Task<IActionResult> NvsIndex()
        {
            return View(await _context.NvsEmployees.ToListAsync());
        }

        // GET: NvsEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvsEmployee = await _context.NvsEmployees
                .FirstOrDefaultAsync(m => m.NvsEmpId == id);
            if (nvsEmployee == null)
            {
                return NotFound();
            }

            return View(nvsEmployee);
        }

        // GET: NvsEmployees/Create
        public IActionResult NvsCreate()
        {
            return View();
        }

        // POST: NvsEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NvsEmpId,NvsEmpName,NvsEmpLevel,NvsEmpStartDate,NvsEmpStatus")] NvsEmployee nvsEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nvsEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NvsIndex));
            }
            return View(nvsEmployee);
        }

        // GET: NvsEmployees/Edit/5
        public async Task<IActionResult> NvsEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvsEmployee = await _context.NvsEmployees.FindAsync(id);
            if (nvsEmployee == null)
            {
                return NotFound();
            }
            return View(nvsEmployee);
        }

        // POST: NvsEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvsEdit(int id, [Bind("NvsEmpId,NvsEmpName,NvsEmpLevel,NvsEmpStartDate,NvsEmpStatus")] NvsEmployee nvsEmployee)
        {
            if (id != nvsEmployee.NvsEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nvsEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NvsEmployeeExists(nvsEmployee.NvsEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NvsIndex));
            }
            return View(nvsEmployee);
        }

        // GET: NvsEmployees/Delete/5
        public async Task<IActionResult> NvsDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvsEmployee = await _context.NvsEmployees
                .FirstOrDefaultAsync(m => m.NvsEmpId == id);
            if (nvsEmployee == null)
            {
                return NotFound();
            }

            return View(nvsEmployee);
        }

        // POST: NvsEmployees/Delete/5
        [HttpPost, ActionName("NvsDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nvsEmployee = await _context.NvsEmployees.FindAsync(id);
            if (nvsEmployee != null)
            {
                _context.NvsEmployees.Remove(nvsEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NvsIndex));
        }

        private bool NvsEmployeeExists(int id)
        {
            return _context.NvsEmployees.Any(e => e.NvsEmpId == id);
        }
    }
}
