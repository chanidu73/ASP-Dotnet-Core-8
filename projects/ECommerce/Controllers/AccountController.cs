using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Data;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;


namespace ECommerce.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController (UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email , model.Password , model.RememberMe , lockoutOnFailure:false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index" , "Home");
                }
                ModelState.AddModelError(string.Empty , "Invalid Login Attempt");

            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser {UserName = model.Email , Email = model.Email};
                var result = await _userManager.CreateAsync(user , model.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user , isPersistent: false);
                    return RedirectToAction("Index" , "Home");

                }
                
                foreach(var er in result.Errors)
                {
                    ModelState.AddModelError(string.Empty , er.Description);
                }

            }
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index" , "Home");
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        



    }
}