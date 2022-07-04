using AutoMapper;
using DatabaseScaffoldApplication.Domain.Repositories;
using DatabaseScaffoldApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.ViewComponents
{
    public class MenuViewComponent: ViewComponent
    {
        private IMenuRepository _menu;
        private IMapper _map;

        public MenuViewComponent(IMenuRepository menu, IMapper mapper)
        {
            _menu = menu;
            _map = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menus = await _menu.SelectManayAsync();
            var model = _map.Map<List<MenuViewModel>>(menus);

            return View(model);
        }
    }
}
