using AutoMapper;
using SWshop.Domain.Entities;
using SWshop.MVC.ViewModels;

namespace SWshop.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile() : base("DomainToViewModelMappings")
        {
            CreateMap<ProductViewModel, Product>();
        }
        

    }
}