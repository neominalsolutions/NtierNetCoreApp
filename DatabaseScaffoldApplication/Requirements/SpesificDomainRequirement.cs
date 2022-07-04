using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Requirements
{
    public class SpesificDomainRequirement:IAuthorizationRequirement
    {
        public string _requiredDomain;

        public SpesificDomainRequirement(string requiredDomain)
        {
            _requiredDomain = requiredDomain;
        }
    }
}
