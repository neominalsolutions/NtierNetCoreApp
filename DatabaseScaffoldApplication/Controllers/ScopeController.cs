using DatabaseScaffoldApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Controllers
{
    public class ScopeController : Controller
    {
        private ITransientService _transientService;
        private IScopeService _scopeService;
        private ISingletonService _singletonService;
        private IScopeService _scopeService1;
        private ITransientService _transientService1;

        public ScopeController(ITransientService transientService, IScopeService scopeService,ISingletonService singletonService, IScopeService scopeService1, ITransientService transientService1)
        {
            _scopeService = scopeService;
            _transientService = transientService;
            _singletonService = singletonService;
            _scopeService1 = scopeService1;
            _transientService1 = transientService1;
        }

        public IActionResult Index()
        {
            ViewBag.Transient = _transientService.Id;
            ViewBag.Transient1 = _transientService1.Id;
            ViewBag.Scope = _scopeService.Id;
            ViewBag.Scope1 = _scopeService1.Id;
            ViewBag.Singleton = _singletonService.Id;

            return View();
        }
    }
}
