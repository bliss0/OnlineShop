using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {          
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                        new Car
                        {
                            name = "Tesla",
                            shortDesc = "Авто Илона",
                            longDesc = "Супербыстрый экономичный спорткар с одно из самых современных систем логистики",
                            img = "/img/scale_1200.jpg",
                            price = 45000,
                            isFavourite = true,
                            available = true,
                            category = Categories["Электромобили"]
                        },
                      new Car
                      {
                          name = "Aston Martin",
                          shortDesc = "Резвый итальянец",
                          longDesc = "Автомобиль с бешеным гоночным потенциалом довезет вас от одного конца города до другого, ведь разгон до 100 всего за 8 секунд",
                          img = "/img/aston_martin_rapide_s.jpg",
                          price = 45000,
                          isFavourite = true,
                          available = true,
                          category = Categories["Классические автомобили"]

                      },
                      new Car
                      {
                          name = "BMW",
                          shortDesc = "Наибыстрейший немец",
                          longDesc = "К - качество",
                          img = "/img/BMW.jpg",
                          price = 50000,
                          isFavourite = false,
                          available = false,
                          category = Categories["Классические автомобили"]

                      },
                      new Car
                      {
                          name = "LADA",
                          shortDesc = "Русский автопром",
                          longDesc = "Никогда не ломается, а емдли сломается починим",
                          img = "/img/LADA.jpg",
                          price = 10000,
                          isFavourite = false,
                          available=true,
                          category = Categories["Классические автомобили"]

                      }
                      ) ;
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                    new Category { categoryName = "Электромобили", desc="Современный вид транспорта" },
                    new Category { categoryName ="Классические автомобили",desc="Машины с двигателем внутреннего сгорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                    
                }
                return category;
            }
        }
    }
}
