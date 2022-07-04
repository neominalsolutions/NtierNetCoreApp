using AutoMapper;
using DatabaseScaffoldApplication.Identity;
using DatabaseScaffoldApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserInputModel, ApplicationUser>();
        }
    }
}
