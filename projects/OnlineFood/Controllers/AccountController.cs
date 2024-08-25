// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using OnlineFood.Data;
// using OnlineFood.Models;
// using OnlineFood.ViewModels;
// using Twilio.TwiML.Voice;

// namespace OnlineFood.Controllers
// {
//     public class AccountController:Controller
//     {
//         private readonly UserManager<ApplicationDbContext> _userManager; 
//         private readonly SignInManager<ApplicationDbContext> _signInManager;
//         public AccountController (UserManager<ApplicationDbContext> userManager , SignInManager<ApplicationDbContext> signInManager)
//         {
//             _userManager = userManager;
//             _signInManager = signInManager;

//         }
//         public IActionResult Register()
//         {
//             return View();
//         }
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Register(RegisterViewModel model)
//         {
//             // if(ModelState.IsValid)
//             // {
//             //     var user = new UserModel { UserName = model.Email, Email = model.Email };
//             //     var result = await _userManager.CreateAsync(user ,model.ConfirmPassword);

//                 // if(result.Succeeded)
            
            
            
//             // }
//             if (ModelState.IsValid)
//             {
//                 var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
//                 var result = await _userManager.CreateAsync(user, model.Password);

//                 if (result.Succeeded)
//                 {
//                     await _signInManager.SignInAsync(user, isPersistent: false);
//                     return RedirectToAction("Index", "Home");
//                 }

//                 foreach (var error in result.Errors)
//                 {
//                     ModelState.AddModelError(string.Empty, error.Description);
//                 }
//             }

//             return View(model); 

            
//         }
//     }
// }