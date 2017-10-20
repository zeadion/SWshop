using AutoMapper;
using SWshop.Application.Interface;
using SWshop.Domain.Entities;
using SWshop.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SWshop.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductAppService _productApp;

        public ProductsController(IProductAppService productApp)
        {
            _productApp = productApp;
        }

        // GET: Products
        public ActionResult Index()
        {
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_productApp.GetAll());
            return View(productViewModel);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = _productApp.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            return View(productViewModel);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDomain = Mapper.Map<ProductViewModel, Product>(product);
                _productApp.Add(productDomain);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productApp.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            return View(productViewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDomain = Mapper.Map<ProductViewModel, Product>(product);
                _productApp.Update(productDomain);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productApp.GetById(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            return View(productViewModel);

        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productApp.GetById(id);
            _productApp.Remove(product);

            return RedirectToAction("Index");
        }
    }
}
