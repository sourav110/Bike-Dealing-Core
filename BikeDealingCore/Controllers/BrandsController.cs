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
    }
}
