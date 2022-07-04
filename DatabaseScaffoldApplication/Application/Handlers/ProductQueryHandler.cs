using AutoMapper;
using DatabaseScaffoldApplication.Application.Queries;
using DatabaseScaffoldApplication.Domain.Repositories;
using DatabaseScaffoldApplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Application.Handlers
{
    public class ProductQueryHandler : IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;


        public ProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var product = await _productRepository.SelectAsync((int)request.ProductId);
            var response = _mapper.Map<ProductViewModel>(product);

            return await Task.FromResult(response);
        }
    }
}
