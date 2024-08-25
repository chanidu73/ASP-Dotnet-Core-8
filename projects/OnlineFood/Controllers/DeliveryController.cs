using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFood.Data;

namespace OnlineFood.Controllers
{
    [Authorize]
    public class DeliveryController:Controller
    {
        private readonly ApplicationDbContext _context ;
        
        public DeliveryController(ApplicationDbContext context)
        {
            _context = context;
        } 
        public async Task<IActionResult> Index()
        {
            var deliveries = await _context.Deliveries.Include(d => d.Order)
            .ToListAsync();
            return View(deliveries);
        }
        public async Task<IActionResult> Details(int? id )
        {
            if(id ==null)
            {
                return NotFound();
            }
            
        }

        
    }
}