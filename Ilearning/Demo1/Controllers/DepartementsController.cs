﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo1.Models;

namespace Demo1.Controllers
{
    public class DepartementsController : Controller
    {
        private readonly StudentDbContext _context;

        public DepartementsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: Departements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departes.ToListAsync());
        }

        // GET: Departements/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var departement = await _context.Departes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (departement == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(departement);
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departement = await _context.Departes
                .Include(d => d.traniees)
                .Include(d => d.Course)
                .Include(d => d.Instractor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (departement == null)
            {
                return NotFound();
            }

            return View(departement);
        }



        // GET: Departements/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Manager")] Departement departement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departement);
        }

        // GET: Departements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departement = await _context.Departes.FindAsync(id);
            if (departement == null)
            {
                return NotFound();
            }
            return View(departement);
        }

        // POST: Departements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Manager")] Departement departement)
        {
            if (id != departement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartementExists(departement.Id))
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
            return View(departement);
        }

        // GET: Departements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departement = await _context.Departes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departement == null)
            {
                return NotFound();
            }

            return View(departement);
        }

        // POST: Departements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departement = await _context.Departes.FindAsync(id);
            if (departement != null)
            {
                _context.Departes.Remove(departement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartementExists(int id)
        {
            return _context.Departes.Any(e => e.Id == id);
        }
    }
}
