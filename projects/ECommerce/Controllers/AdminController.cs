using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController:Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>CreateProduct (ProductModel productModel)
        {
            if(ModelState.IsValid)
            {
                _context.Add(productModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Products));
            }
            return View(productModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id , ProductModel product)
        {
            if(id != product.ProductId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Products));
            }
            return View(product);
        }
        [HttpPost , ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductComfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product ==null)
            {
            return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Products));
        }

        public IActionResult Order()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(m=>m.OrderId == id);

            if(order == null)
            {
                return NotFound();
            }
            return View(order);


        } 
    }
}