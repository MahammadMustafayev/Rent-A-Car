using Microsoft.AspNetCore.Mvc;
using RentACar.DAL;
using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BrandController : Controller
    {
        private AppDbContext _context { get; set; }
        
        public BrandController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Brands.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(x => x.Id == id);
            if (brand == null) return NotFound();
            return View(brand);
        }
        public IActionResult Edit(Brand brand)
        {
            Brand exstbrand = _context.Brands.FirstOrDefault(x => x.Id == brand.Id);
            if (exstbrand == null) return NotFound();
            exstbrand.BrandName = brand.BrandName;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Brand brand = _context.Brands.Find(id);
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    } 
}
