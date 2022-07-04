using DatabaseScaffoldApplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Application.Commands
{
    public class ProductCreateCommand: IRequest<ProductCreateResponseModel>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
    }
}
