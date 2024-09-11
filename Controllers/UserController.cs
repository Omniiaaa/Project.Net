using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Project.Net.Context;
using Project.Net.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.Net.Controllers
{
    public class UserController : Controller

    {
        CompanyContext CompanyContext = new CompanyContext();

        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (CompanyContext.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(user);
            }
            user.Password = HashPassword(user.Password);
            CompanyContext.Users.Add(user);
            return RedirectToAction("Index", "Product");
        }
        private string HashPassword(string password)
        {
            return password + " (hashed)";
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)

            { 
                var user = CompanyContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    return RedirectToAction("Index", "Product");
                }

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Email or password.");
                    return RedirectToAction("Register");
                }
            }

            return View();
        }
    }
}

