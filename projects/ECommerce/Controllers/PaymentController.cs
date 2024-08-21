using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using ECommerce.Models;
using ECommerce.Data;
using System.Threading.Tasks;
namespace ECommerce.Controllers
{
    public class PaymentController:Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCheckoutSession()
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>{"card"},
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency ="usd", 
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name ="Total Purchase",
                            },
                            UnitAmount = 2000,
                        }, Quantity =1,
                    },
                },
                Mode = "payment", 
                SuccessUrl = Url.Action("Success" , "Payment", null , Request.Scheme),
                CancelUrl = Url.Action("Cancel" , "Payment" , null ,Request.Scheme),
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return Json(new {id = session.Id});
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Cancel()
        {
            return View();
        }
    }
}