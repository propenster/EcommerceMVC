using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Facemask.Models;
using Facemask.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Facemask.Controllers
{
    public class AccountsController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountsController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo Rinfo = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(Rinfo.EnglishName)))
                {
                    CountryList.Add(Rinfo.EnglishName);
                }

            }
            CountryList.Sort();
            ViewBag.CountryList = CountryList;
            return View();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Phone = model.Phone,
                    PhoneNumber = model.Phone,
                    BillingAddress = model.BillingAddress,
                    FullName = model.FullName,
                    DefaultShippingAddress = model.DefaultShippingAddress,
                    Country = model.Country
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Shop");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }


            }//end if ModelState.IsValid

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Shop");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt!");
            }

            return View(model);
        }
 
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Shop");
        }
    }
}
