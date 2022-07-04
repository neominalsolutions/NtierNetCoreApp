using AutoMapper;
using DatabaseScaffoldApplication.Domain.Models;
using DatabaseScaffoldApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Profiles
{
    public class MenuProfiler: Profile
    {
        public MenuProfiler()
        {
            CreateMap<Menu, MenuViewModel>();
        }
    }
}
