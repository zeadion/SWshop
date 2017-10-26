using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SWshop.Application.Interface;
using SWshop.Domain.Entities;
using SWshop.MVC.Models;
using SWshop.MVC.ViewModels;

namespace SWshop.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductAppService _productApp;

        public CartController(IProductAppService productApp)
        {
            _productApp = productApp;
        }

        private List<CartItem> GetSessionCart()
        {
            List<CartItem> cart = Session.GetDataFromSession<List<CartItem>>("cart");
            return ReferenceEquals(cart, null) ? new List<CartItem>() : cart;
        }

        // GET: Cart
        public ActionResult Index()
        {
            CartViewModel cartViewModel = new CartViewModel
            {
                CartItems = GetSessionCart()
            };
            return View(cartViewModel);
        }


        public ActionResult AddToCart(int id)
        {
            List<CartItem> cart = GetSessionCart();
            if (cart.Exists(x => x.Product.Id == id))
            {
                cart.Find(x => x.Product.Id == id).Count++;
            }
            else
            {
                var productViewModel = Mapper.Map<Product, ProductViewModel>(_productApp.GetById(id));
                cart.Add( new CartItem
                {
                    Product = productViewModel,
                    Count = 1
                });
            }

            Session.SetDataToSession<List<CartItem>>("cart", cart);
            var cartCount = cart.Sum(cartItem => cartItem.Count);
            Session.SetDataToSession<int>("cartCount", cartCount);
            return JavaScript(cartCount.ToString());
        }

        public ActionResult UpdateCart(int id, int count, string promotion)
        {
            int pro;
            switch (promotion)
            {
                case "pro1":
                    pro = CartItem.Promotion1;
                    break;
                case "pro2":
                    pro = CartItem.Promotion2;
                    break;
                default:
                    pro = CartItem.NoPromotions;
                    break;
            }

            List<CartItem> cart = GetSessionCart();

            var item = cart.Find(x => x.Product.Id == id);
            item.Count = count;
            item.PromotionApplied = pro;
            
            Session.SetDataToSession<List<CartItem>>("cart", cart);

            var cartCount = cart.Sum(cartItem => cartItem.Count);
            Session.SetDataToSession<int>("cartCount", cartCount);
            var json = "{" +
                "\"cartCount\": \"" + cartCount.ToString()+ "\"," +
                "\"regularItemPrice\": \"" + item.GetRegularPrice() + "\"," +
                "\"promotionItemPrice\": \"" + item.GetPromotionPrice() + "\"," +
                "\"regularTotalPrice\": \"" + cart.Sum(x => x.GetRegularPrice()) + "\"," +
                "\"promotionTotalPrice\": \"" + cart.Sum(x => x.GetPromotionPrice()) + "\"" +
                "}";
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult RemoveFromCart(int id)
        {
            List<CartItem> cart = GetSessionCart();
            var index = cart.FindIndex(x => x.Product.Id == id);
            if(index>=0)
            {
                cart.RemoveAt(index);
                Session.SetDataToSession<List<CartItem>>("cart", cart);
                var cartCount = cart.Sum(cartItem => cartItem.Count);
                Session.SetDataToSession<int>("cartCount", cartCount);
                var json = "{" +
                           "\"cartCount\": \"" + cartCount + "\"," +
                           "\"regularTotalPrice\": \"" + cart.Sum(x => x.GetRegularPrice()) + "\"," +
                           "\"promotionTotalPrice\": \"" + cart.Sum(x => x.GetPromotionPrice()) + "\"" +
                           "}";
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            return new EmptyResult();
        }
        

    }
}