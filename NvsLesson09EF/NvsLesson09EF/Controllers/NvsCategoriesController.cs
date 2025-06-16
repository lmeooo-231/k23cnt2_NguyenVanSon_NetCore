using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NvsLesson09EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NvsLesson09EF.Controllers
{
    public class NvsCategoriesController : Controller
    {
        private readonly NvsBookStoreContext _context;

        public NvsCategoriesController(NvsBookStoreContext context)
        {
            _context = context;
        }

        // GET: NvsCategories
        public async Task<IActionResult> NvsIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NvsCategories/Details/5
        public async Task<IActionResult> Details(int? nvsid)
        {
            if (nvsid == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == nvsid);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NvsCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NvsCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NvsIndex));
            }
            return View(category);
        }

        // GET: NvsCategories/Edit/5
        public async Task<IActionResult> Edit(int? nvsid)
        {
            if (nvsid == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(nvsid);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: NvsCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int nvsid, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (nvsid != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: NvsCategories/Delete/5
        public async Task<IActionResult> Delete(int? nvsid)
        {
            if (nvsid == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == nvsid);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NvsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int nvsid)
        {
            var category = await _context.Categories.FindAsync(nvsid);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NvsIndex));
        }

        private bool CategoryExists(int nvsid)
        {
            return _context.Categories.Any(e => e.CategoryId == nvsid);
        }
    }
}
