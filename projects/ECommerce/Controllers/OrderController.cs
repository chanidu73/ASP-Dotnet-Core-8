using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using ECommerce.Extensions;

namespace ECommerce.Controllers
{
    public class OrderController:Controller
    {
        private readonly ApplicationDbContext _context ;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Checkout()
        {
            var cartItems = GetCartItems();
            if (cartItems.Count == 0)
            {
                return RedirectToAction("Index" , "Cart");
            }
            var Order = new OrderModel
            {
                TotalCost = cartItems.Sum(item => item.Product.Price *item.Quantity)
            };
            return View(Order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(OrderModel order)
        {
            var cartItems = GetCartItems();
            if(cartItems.Count== 0){
                return RedirectToAction("Index" , "Cart");
            }
            if(ModelState.IsValid)
            {
                order.TotalCost = cartItems.Sum(i => i.Product.Price * i.Quantity);
                
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                foreach(var cartItem in cartItems)
                {
                    var orderItem =new OrderItemModel{
                        OrderId =order.OrderId , 
                        ProductId = cartItem.Product.ProductId,
                        Quantity = cartItem.Quantity,
                        Price = cartItem.Product.Price
                    };
                    _context.OrderItems.Add(orderItem);

                }
                await _context.SaveChangesAsync();
                ClearCart();
                return RedirectToAction("OrderConfirmation" , new {id = order.OrderId});
            }
            return View(order);
        }



        public async Task<IActionResult>OrderConfirmation(int id )
        {
            var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.OrderId == id);
            
            if(order ==null)
            {
                return NotFound();
            }

            return View(order);
        }

        public async Task<IActionResult> History()
        {
            var orders = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();

            return View(orders);
        }



        private List<CartItemModel> GetCartItems()
        {
            return HttpContext.Session.GetObjectFromJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
        }
        private void ClearCart()
        {
            HttpContext.Session.Remove("Cart");
        }


    }
}