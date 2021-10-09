using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car{
                        name = "Tesla",
                        shortDesc="Авто Илона",
                        longDesc="Супербыстрый экономичный спорткар с одно из самых современных систем р=логистики",
                        img="https://www.pnzdrive.ru/uploads/news/2021/001/999888/scale_1200.jpg",
                        price=45000,
                        isFavourite=true,
                        available=true, 
                        category = _categoryCars.AllCategories.First() 
                    },
                    new Car{ 
                        name = "Aston Martin",
                        shortDesc="Резвый итальянец",
                        longDesc="Автомобиль с бешеным гоночным потенциалом довезет вас от одного конца города до другого, ведь разгон до 100 всего за 8 секунд",
                        img="https://avatars.mds.yandex.net/get-zen_doc/1337093/pub_5e1e202632335400ac8d6117_5e1e21155d6c4b00b0d97cd2/scale_1200",
                        price=45000,
                        isFavourite=true,
                        available=true,
                        category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavouriteCars { get ; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
