using DatabaseScaffoldApplication.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Requirements
{
    public class DomainRequirementHandler : AuthorizationHandler<SpesificDomainRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DomainRequirementHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, SpesificDomainRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(context.User.Identity.Name);

                if (user.Email.Contains(requirement._requiredDomain))
                {
                    context.Succeed(requirement);
                    await Task.CompletedTask;
                }

                await Task.CompletedTask;
            }


        }
    }
}
