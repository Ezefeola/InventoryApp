using AutoMapper;
using Inventory_App.Data;
using Inventory_App.DTOs;
using Inventory_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_App.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthController(ApplicationDbContext appDbContext,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMapper mapper)
        {
            this._appDbContext = appDbContext;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;

        }

        public IActionResult RegisterVw()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterVw(RegisterViewDTO registerViewDTO)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<IdentityUser>(registerViewDTO);

                user.UserName = registerViewDTO.Email;
                var result = await _userManager.CreateAsync(user, registerViewDTO.Password);

                if (result.Succeeded)
                {
                    Console.WriteLine("Register Passed");
                    return RedirectToAction("LoginVw", "Auth");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    Console.WriteLine(error.Description);
                }
            }
            Console.WriteLine("Register Not PASSED");
            return View(registerViewDTO);
        }

        public IActionResult LoginVw()
        {
            ViewBag.Layout = "~/Views/Shared/_authLayout.cshtml";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginVw(LoginViewDTO loginViewDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(loginViewDTO.Email, loginViewDTO.Password, isPersistent: false, lockoutOnFailure: false) ;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(loginViewDTO);
        }
    }
}
