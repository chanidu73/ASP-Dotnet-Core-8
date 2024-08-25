using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFood.Data;
using OnlineFood.Models;

namespace OnlineFood.Controllers
{
    [Authorize]
    public class RestaurantController:Controller
    {
        private readonly ApplicationDbContext _context ;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return View(restaurants);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var restaurant = _context.Restaurants.
            Include(m => m.MenuItems)
            .FirstOrDefaultAsync(
                r=> r.RestaurantId == id
            );
            if(restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestaurantId,Name,Location,ContactInfo")] RestaurantModel restaurant)
        {
            if(ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var restaurant =await _context.Restaurants.FindAsync(id);
            if(restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id , [Bind("RestaurantId,Name,Location,ContactInfo")] RestaurantModel restaurant)
        {
            if (id != restaurant.RestaurantId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Update(restaurant);
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurants
            .FirstOrDefaultAsync(m => m.RestaurantId == id);
            if(restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id )
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}