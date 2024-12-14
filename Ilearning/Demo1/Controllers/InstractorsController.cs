using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo1.Models;

namespace Demo1.Controllers
{
    public class InstractorsController : Controller
    {
        private readonly StudentDbContext _context;

        public InstractorsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: Instractors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instractors.ToListAsync());
        }

        // GET: Instractors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instractor = await _context.Instractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instractor == null)
            {
                return NotFound();
            }

            return View(instractor);
        }

        // GET: Instractors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instractors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Salary,Dep_id,crs_id")] Instractor instractor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instractor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instractor);
        }

        // GET: Instractors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instractor = await _context.Instractors.FindAsync(id);
            if (instractor == null)
            {
                return NotFound();
            }
            return View(instractor);
        }

        // POST: Instractors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Salary,Dep_id,crs_id")] Instractor instractor)
        {
            if (id != instractor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instractor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstractorExists(instractor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(instractor);
        }

        // GET: Instractors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instractor = await _context.Instractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instractor == null)
            {
                return NotFound();
            }

            return View(instractor);
        }

        // POST: Instractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instractor = await _context.Instractors.FindAsync(id);
            if (instractor != null)
            {
                _context.Instractors.Remove(instractor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstractorExists(int id)
        {
            return _context.Instractors.Any(e => e.Id == id);
        }
    }
}
