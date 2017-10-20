using AutoMapper;
using SWshop.Domain.Entities;
using SWshop.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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