using AutoMapper;
using SWshop.Domain.Entities;
using SWshop.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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