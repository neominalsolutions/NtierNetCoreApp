using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public string WebSite { get; set; }

    }
}
