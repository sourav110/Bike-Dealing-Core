using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeDealingCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeDealingCore.Controllers
{
    public class BrandsController : Controller
    {
        private readonly BikeDbContext _context;
        public BrandsController(BikeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var brands = _context.Brands.ToList();

            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brand);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(brand);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var brand = _context.Brands.Find(id);

            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Update(brand);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(brand);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var brand = _context.Brands.Find(id);

            if (brand != null)
            {
                _context.Remove(brand);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return NotFound();        
        }
    }
}
