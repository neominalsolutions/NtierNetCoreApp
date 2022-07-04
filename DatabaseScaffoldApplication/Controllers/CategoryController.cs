using DatabaseScaffoldApplication.Domain.Models;
using DatabaseScaffoldApplication.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var categories = _repository.FilterByCategoryName("beverages");
            _repository.Create(new Category { CategoryName = "a", Description = "b" });


            return View();
        }
    }
}
