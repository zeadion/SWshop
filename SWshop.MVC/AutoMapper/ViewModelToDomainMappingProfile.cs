using AutoMapper;
using SWshop.Domain.Entities;
using SWshop.MVC.ViewModels;

namespace SWshop.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base("ViewModelToDomainMappings")
        {
            CreateMap<Product, ProductViewModel>();
        }
        

    }
}