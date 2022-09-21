using AutoMapper;
using InernshipApplication.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Dto.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, NewCategoryDto>();
            CreateMap<CategoryDto,Category>();
            CreateMap<NewCategoryDto,Category>();
        }
    }
}
