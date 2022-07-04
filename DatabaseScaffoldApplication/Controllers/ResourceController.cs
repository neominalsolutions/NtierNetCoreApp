using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using DatabaseScaffoldApplication.Infrastructure;
using DatabaseScaffoldApplication.Domain.Repositories;

namespace DatabaseScaffoldApplication.Controllers
{
    [Authorize]
    public class ResourceController : Controller
    {
        private readonly IResourceRepository _resourceRepo;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResourceController(IResourceRepository resourceRepo, IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _resourceRepo = resourceRepo;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {

            //_resourceRepo.WhereList(x => x.Name.c("a"));
            var resources = _resourceRepo.SelectMany();

            return View(resources);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var resource = _resourceRepo.Select(id);


            if (resource != null)
            {
                var result = await _authorizationService.AuthorizeAsync(User, resource, Operations.Edit);

                if (result.Succeeded)
                {
                    return View(resource);
                }
                else
                {
                    return RedirectToAction("Authorize", "Account");
                }
            }

            return NotFound();
        }

    }
}