using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using OnlineShop.Data.Repositories;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ShopCartController: Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }
    
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(obj);
        }
        

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if(item != null)
            { 
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    
    
    
    }
}
