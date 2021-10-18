using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class ShopCartItems
    {
        public int ItemId { get; set; }
        public Car car { get; set; }
        public int price { get; set; }

        public string id { get; set; }

    }
}
