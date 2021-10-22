using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public class OrdersRepository : IAllOrders,IEmailSender
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent,ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order currOrder)
        {
            currOrder.orderTime = DateTime.Now;
            appDBContent.Order.Add(currOrder);
            appDBContent.SaveChanges();

            var items = shopCart.listShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    carID = el.car.id,
                    orderID = currOrder.id,
                    price = el.car.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
                appDBContent.SaveChanges();
         
            }
            IEmailSender.SendEmailAsync(currOrder.email, items).GetAwaiter();


        }


    }
}
