using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Extensions;

namespace ECommerce.Controllers
{
    public class CartController:Controller
    {
        private readonly ApplicationDbContext _context ;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cart = GetCartItems();
            return View(cart);
        }
        public async Task<IActionResult> AddToCart(int productId , int quantity)
        {
            var product = await _context.CartItems.FindAsync(productId);
            if (product != null)
            {
                var cart = GetCartItems(); 
                var cartitem = cart.FirstOrDefault(c=> c.ProductId == productId);
                if(cartitem != null)
                {
                    cartitem.Quantity += quantity;
                }
                else{
                    cart.Add(new CartItemModel{
                        Product = product.Product,
                        Quantity = quantity
                    });
                }
                SaveCartItems(cart);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCartItems();

            var cartItem = cart.FirstOrDefault(c => c.ProductId == productId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                SaveCartItems(cart);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UpdateCart(int productId , int quantity)
        {
            var cart = GetCartItems();
            var  cartItem = cart.FirstOrDefault(c => c.ProductId == productId);
            if(cartItem != null)
            {
                cartItem.Quantity = quantity;
                SaveCartItems(cart);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CleanCart()
        {
            SaveCartItems(null);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Checkout()
        {
            var cart = GetCartItems();
            if(cart ==null || !cart.Any())
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private List<CartItemModel>GetCartItems()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItemModel>>;
            // return cart ?? new List<CartItemModel>();
            return new List<CartItemModel>();
        }
        private void SaveCartItems(List<CartItemModel> cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart" , cart);
        }


        
    }
}