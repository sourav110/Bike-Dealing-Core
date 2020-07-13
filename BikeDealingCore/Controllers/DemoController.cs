﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeDealingCore.Models;

namespace BikeDealingCore.Controllers
{
    public class DemoController : Controller
    {
        private readonly BikeDbContext _context;

        public DemoController(BikeDbContext context)
        {
            _context = context;
        }

        // GET: Demo
        public async Task<IActionResult> Index()
        {
            var bikeDbContext = _context.Demo.Include(d => d.Brand);
            return View(await bikeDbContext.ToListAsync());
        }

        // GET: Demo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demo = await _context.Demo
                .Include(d => d.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demo == null)
            {
                return NotFound();
            }

            return View(demo);
        }

        // GET: Demo/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            return View();
        }

        // POST: Demo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BrandId")] Demo demo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", demo.BrandId);
            return View(demo);
        }

        // GET: Demo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demo = await _context.Demo.FindAsync(id);
            if (demo == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", demo.BrandId);
            return View(demo);
        }

        // POST: Demo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BrandId")] Demo demo)
        {
            if (id != demo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemoExists(demo.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", demo.BrandId);
            return View(demo);
        }

        // GET: Demo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demo = await _context.Demo
                .Include(d => d.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demo == null)
            {
                return NotFound();
            }

            return View(demo);
        }

        // POST: Demo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demo = await _context.Demo.FindAsync(id);
            _context.Demo.Remove(demo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemoExists(int id)
        {
            return _context.Demo.Any(e => e.Id == id);
        }
    }
}
