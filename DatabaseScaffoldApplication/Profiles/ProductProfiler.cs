using AutoMapper;
using DatabaseScaffoldApplication.Application.Commands;
using DatabaseScaffoldApplication.Domain.Models;
using DatabaseScaffoldApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Profiles
{
    public class ProductProfiler: Profile
    {

        public ProductProfiler()
        {
            CreateMap<ProductCreateCommand, Product>()
                .ForMember(dest =>
             dest.ProductName,
            opt => opt.MapFrom(src => src.Name))
        .ForMember(dest =>
            dest.UnitPrice,
            opt => opt.MapFrom(src => src.Price))
        .ForMember(dest =>
            dest.UnitsInStock,
            opt => opt.MapFrom(src => src.Stock));

            CreateMap<Product, ProductViewModel>();
        }
    }
}
