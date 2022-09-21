using AutoMapper;
using InernshipApplication.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Dto.Profiles
{
    public class ProductProfile:Profile
    {
       public ProductProfile()
        {
            CreateMap<Product,ProductDto>();
            CreateMap<Product,NewProductDto>();
            CreateMap<NewProductDto, Product>();
            CreateMap<ProductDto, Product>();
        }
    }
}
