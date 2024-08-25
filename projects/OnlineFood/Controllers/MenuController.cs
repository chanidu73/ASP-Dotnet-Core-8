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
    public class MenuController:Controller
    {
        private readonly ApplicationDbContext _context; 

        public MenuController(ApplicationDbContext context)
        {
            _context =context;
        }
        public async Task<IActionResult> Index (int? id )
        {
            if(id == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restaurants
            .Include(r => r.MenuItems)
            .FirstOrDefaultAsync(m => m.RestaurantId ==id);

            if(restaurant == null)
            {
                return NotFound();
            }
            ViewData["RestaurantId"]= id;
            return View(restaurant.MenuItems);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var menuItem = await _context.MenuItems
            .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if(menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }
        public IActionResult Create(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewData["RestaurantId"] = id;
            return View();
        }

        public async Task<IActionResult> Create(int id , [Bind("MenuItemId,RestaurantId,Name,Description,Price")]MenuItemModel menuItem)
        {
            if(ModelState.IsValid)
            {
                menuItem.RestaurantId = id;
                _context.Add(menuItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index) , new{ restaurantId = id});
            }
            ViewData["RestaurantId"] = id;
            return View(menuItem);
        }
        public async Task<IActionResult> Edit (int? id)
        {
            if(id ==null)
            {
                return NotFound();
            }
            var menuItem = await _context.MenuItems.FindAsync(id);
            if(menuItem == null)
            {
                return NotFound();
            }
            ViewData["RestaurantId"] = menuItem.RestaurantId;
            return View(menuItem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id , [Bind("MenuItemId,RestaurantId,Name,Description,Price")]MenuItemModel menuItem)
        {
            if(id != menuItem.MenuItemId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Update(menuItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { restaurantId = menuItem.RestaurantId });
            }
            ViewData["RestaurantId"] = menuItem.RestaurantId;
            return View(menuItem);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var menuItem = await _context.MenuItems
            .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if(menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }
        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { restaurantId = menuItem.RestaurantId});
        }

    }
}