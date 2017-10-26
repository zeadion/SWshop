using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using SWshop.Application.Interface;
using SWshop.Domain.Entities;
using SWshop.MVC.Models;
using SWshop.MVC.ViewModels;

namespace SWshop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductAppService _productApp;

        public HomeController(IProductAppService productApp)
        {
            _productApp = productApp;
        }

        public ActionResult Index()
        {
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_productApp.GetAll());
            return View(productViewModel);
        }


    }
}