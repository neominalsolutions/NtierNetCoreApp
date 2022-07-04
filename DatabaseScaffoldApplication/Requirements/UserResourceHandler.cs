using DatabaseScaffoldApplication.Domain.Models;
using DatabaseScaffoldApplication.Identity;
using DatabaseScaffoldApplication.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Requirements
{
    public class UserResourceHandler : AuthorizationHandler<OperationAuthorizationRequirement, UserResource>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserResourceHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, UserResource resource)
        {

            if (context.User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(context.User.Identity.Name);

                if(
                    resource.ApplicationUserId == user.Id 
                    &&
                    (Operations.Edit.Name == requirement.Name)
                    || 
                    (Operations.Delete.Name == requirement.Name)
                    )
                {
                    context.Succeed(requirement);
                    await Task.CompletedTask;
                }
            }

            await Task.CompletedTask;
        }
    }
}
