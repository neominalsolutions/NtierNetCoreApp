using AutoMapper;
using DatabaseScaffoldApplication.Application.Commands;
using DatabaseScaffoldApplication.Domain.Models;
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
    public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, ProductCreateResponseModel>
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductCreateHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task<ProductCreateResponseModel> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {

            var product = _mapper.Map<Product>(request);

              _productRepository.Create(product);
              int result =   _productRepository.Save();

            var response = new ProductCreateResponseModel()
            {
                Id = product.ProductId
            };

            return await Task.FromResult(response);
        }
    }
}
