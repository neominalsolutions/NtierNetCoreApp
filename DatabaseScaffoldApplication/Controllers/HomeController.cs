using DatabaseScaffoldApplication.Domain.Models;
using DatabaseScaffoldApplication.Infrastructure.EfCore;
using DatabaseScaffoldApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NORTHWNDContext _db;

        public HomeController(ILogger<HomeController> logger, NORTHWNDContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        //[Authorize(Roles ="Student")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //only authentication
        [Authorize]
        public async Task<IActionResult> AuthenticatedUserView()
        {
            //await CreateRole();

            return View();
        }


        //role base authorization
        [Authorize(Roles = "Manager")]
        public IActionResult AdminView()
        {
            return View();
        }

        //policy base authorization
        [Authorize(Policy = "UserPolicy")]
        public IActionResult PolicyView()
        {
            return View();
        }

        //claim based authorization
        [Authorize(Policy = "DateOfBirthClaim")]
        public IActionResult ClaimView()
        {
            return View();
        }

        //requirement based authorization
        [Authorize(Policy = "SpecificUserPolicy")]
        public IActionResult SpesificView()
        {
            return View();
        }
    }
}
