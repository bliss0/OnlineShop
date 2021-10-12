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
                        img="/img/scale_1200.jpg",
                        price=45000,
                        isFavourite=true,
                        available=true,
                        category = _categoryCars.AllCategories.First()
                    },
                    new Car{
                        name = "Aston Martin",
                        shortDesc="Резвый итальянец",
                        longDesc="Автомобиль с бешеным гоночным потенциалом довезет вас от одного конца города до другого, ведь разгон до 100 всего за 8 секунд",
                        img="/img/aston_martin_rapide_s.jpg",
                        price=45000,
                        isFavourite=true,
                        available=true,
                        category = _categoryCars.AllCategories.Last()

                    },
                    new Car
                    {
                        name="BMW",
                        shortDesc="Наибыстрейший немец",
                        longDesc="К - качество",
                        img="",
                        price=50000,
                        isFavourite=false,
                        available=false,
                        category = _categoryCars.AllCategories.First()

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
