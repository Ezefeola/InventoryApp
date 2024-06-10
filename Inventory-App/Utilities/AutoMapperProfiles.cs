using AutoMapper;
using Inventory_App.DTOs;
using Inventory_App.Models;
using Microsoft.AspNetCore.Identity;

namespace Inventory_App.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterViewDTO, IdentityUser>().ReverseMap();
            CreateMap<LoginViewDTO, IdentityUser>().ReverseMap();
            CreateMap<ProductModel, ProductDTO>().ReverseMap();
        }
    }
}
