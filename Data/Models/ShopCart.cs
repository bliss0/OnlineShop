﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartID { get; set; }

        public List<ShopCartItems>listShopItems { get; set; }
    
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartID = shopCartId };
        }
        public void AddToCart(Car car)
        {
            appDBContent.ShopCartItems.Add(new ShopCartItems
            {
                itemId = ShopCartID,
                car = car,
                price=car.price
            });
            appDBContent.SaveChanges();

        }
    
        public List<ShopCartItems>getShopItems()
            {
            return appDBContent.ShopCartItems.Where(c => c.itemId == ShopCartID).Include(s => s.car).ToList();
            } 
    }
}
