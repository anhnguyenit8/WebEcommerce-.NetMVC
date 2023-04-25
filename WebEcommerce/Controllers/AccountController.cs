﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data;
using WebEcommerce.Data.Static;
using WebEcommerce.Models;
using WebEcommerce.ViewModels;

namespace WebEcommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Users()
        {
            var Resposne = await _context.Users.ToListAsync();
            return View(Resposne);
        }
        public IActionResult Login()
        {
            var Result = new LoginVM();
            return View(Result);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                //Check Password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if (passwordCheck)
                {
                    var Result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (Result.Succeeded)
                    {
                        return RedirectToAction("Index", "Products");
                    }
                }
                TempData["Error"] = "Incorrect password! Please, try again!";
                
                
                return View(model);
            }
            TempData["Error"] = "Can't find account! Please, try again!";
            return View(model);
        }

        public IActionResult Register()
        {
            var Result = new RegisterVM();
            return View(Result);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use!";
                return View(model);
            }
            var newUser = new ApplicationUser() { Email = model.EmailAddress, FullName = model.FullName, UserName = model.EmailAddress.Split('@')[0] };
            var Result = await _userManager.CreateAsync(newUser, model.Password);
            if (Result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return View("CompleteRegister");
            }
            else
            {
                TempData["Error"] = "Password must be 8-16 characters long, and contain one uppercase and one lowercase character !";
                return View(model);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Products");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {            
            return View();
        }

        // Không thể xóa tài khoản vì gây xung đột FK dữ liệu của bảng Order
        /*[HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                TempData["Error"] = "User not found!";
                return RedirectToAction("Users");
            }

            if (await _userManager.IsInRoleAsync(user, UserRoles.Admin))
            {
                TempData["Error"] = "Can't delete admin account!";
                return RedirectToAction("Users");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = "User deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to delete user!";
            }

            return RedirectToAction("Users");
        }*/


    }
}
