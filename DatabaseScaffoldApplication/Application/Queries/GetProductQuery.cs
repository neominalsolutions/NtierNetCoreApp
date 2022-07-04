using DatabaseScaffoldApplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Application.Queries
{
    public class GetProductQuery: IRequest<ProductViewModel>
    {
        public int? ProductId { get; set; }

    }
}
