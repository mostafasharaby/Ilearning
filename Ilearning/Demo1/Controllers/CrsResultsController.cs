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
    public class CrsResultsController : Controller
    {
        private readonly StudentDbContext _context;

        public CrsResultsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: CrsResults
        public async Task<IActionResult> Index()
        {
            return View(await _context.CrsResults.ToListAsync());
        }

        // GET: CrsResults/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var crsResult = await _context.CrsResults
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (crsResult == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(crsResult);
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crsResult = await _context.CrsResults
                .Include(c => c.Trainee)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (crsResult == null)
            {
                return NotFound();
            }

            return View(crsResult);
        }


        // GET: CrsResults/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Degree,Traniee_id,crs_id")] CrsResult crsResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crsResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crsResult);
        }

        // GET: CrsResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crsResult = await _context.CrsResults.FindAsync(id);
            if (crsResult == null)
            {
                return NotFound();
            }
            return View(crsResult);
        }

        // POST: CrsResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Degree,Traniee_id,crs_id")] CrsResult crsResult)
        {
            if (id != crsResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crsResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrsResultExists(crsResult.Id))
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
            return View(crsResult);
        }

        // GET: CrsResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crsResult = await _context.CrsResults
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crsResult == null)
            {
                return NotFound();
            }

            return View(crsResult);
        }

        // POST: CrsResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crsResult = await _context.CrsResults.FindAsync(id);
            if (crsResult != null)
            {
                _context.CrsResults.Remove(crsResult);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrsResultExists(int id)
        {
            return _context.CrsResults.Any(e => e.Id == id);
        }
    }
}
