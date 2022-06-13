using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACar.DAL;
using RentACar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CarController : Controller
    {
        private AppDbContext _context { get; set; }
        private IWebHostEnvironment _env { get; set; }
         public CarController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Cars.Include(x=>x.Brand).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            if (car == null) return NotFound();
            
            //car.Image = await car.Photo(Path.Combine(_env.WebRootPath, "assets", "img"));
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Car car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (car == null) return BadRequest();
            return View(car);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car car)
        {
            Car exstcar = _context.Cars.FirstOrDefault(x => x.Id == car.Id);
            if (exstcar == null) return NotFound();
            exstcar.CarAge = car.CarAge;
            exstcar.CarDoor = car.CarDoor;
            exstcar.CarName = car.CarName;
            exstcar.CarType = car.CarType;
            exstcar.Airconditioning = car.Airconditioning;
            exstcar.Brand = car.Brand;
            exstcar.Image = car.Image;
            exstcar.LuggageBaggage = car.LuggageBaggage;
            exstcar.LuggageSuit = car.LuggageSuit;
            exstcar.Price = car.Price;
            exstcar.Seats = car.Seats;
            exstcar.Transmission = car.Transmission;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Car car = _context.Cars.Find(id);
            if (car == null) return NotFound();
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }
    }
}
