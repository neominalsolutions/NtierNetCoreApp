using AutoMapper;
using DatabaseScaffoldApplication.Identity;
using DatabaseScaffoldApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private IMapper _mapper;

        public AuthController(UserManager<ApplicationUser> userManager, IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _singInManager = signInManager;
        }


        public IActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> Login(UserInputModel model)
        {

            var user = await _userManager.FindByIdAsync("aafcc76a-bdcc-42a4-baa1-ad93a81af052");

            if(user != null && user.EmailConfirmed)
            {
                await _singInManager.SignInAsync(user, model.RememberMe);
            }

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> Create(UserInputModel model)
        {
           var user =  _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return View();
            }

            return View();

        }
    }
}
