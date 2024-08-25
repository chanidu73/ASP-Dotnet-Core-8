using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFood.Data;using Microsoft.AspNetCore.Mvc.Rendering;


namespace OnlineFood.Controllers
{
    public class OrderController: Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
            .Include(o => o.Restaurant)
            // .Include(o => o.MenuItems)
            .ToListAsync();
            return View(orders);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var order = await _context.Orders
            .Include(o => o.Restaurant)
            // .Include(o=> o.MenuItems)
            .FirstOrDefaultAsync(m => m.OrderId == id);

            if(order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        public IActionResult Create()
        {

            ViewData["RestaurantId"] = new SelectList(_context.Restaurants ,"RestaurantId", "Name" );
            // ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "Name", orderModel.MenuItems.Select(mi => mi.MenuItemId));
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserId,RestaurantId,OrderDate,TotalAmount,DeliveryAddress,PhoneNumber,MenuItems")] OrderModel orderModel)
        {
            if(ModelState.IsValid)
            {
                _context.Add(orderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "Name", orderModel.RestaurantId);
            // ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "MenuItemId", "Name", orderModel.MenuItems.Select(mi => mi.MenuItemId));
            return View(orderModel);
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , [Bind("OrderId,UserId,RestaurantId,OrderDate,TotalAmount,DeliveryAddress,PhoneNumber,MenuItems")] OrderModel orderModel)
        {
            if(id  == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)

        }
        
    }
}