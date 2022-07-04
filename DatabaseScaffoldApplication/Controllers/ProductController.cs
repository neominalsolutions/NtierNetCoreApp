using DatabaseScaffoldApplication.Application.Commands;
using DatabaseScaffoldApplication.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Controllers
{
    public class ProductController : Controller
    {
        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Get(int? ProductId)
        {
            if(ProductId == null)
            {
                // 404 Page
                return NotFound();
            }

           var response = await _mediator.Send(new GetProductQuery() { ProductId = ProductId });

            return View(response);


        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateCommand command)
        {
            var response = _mediator.Send(command);

            return View(response);
        }
    }
}
