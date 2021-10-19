using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Data.Controllers
{
    public class CarsController: Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)//add commentary to try commit
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }else
            {
                if(string.Equals("electro",category,StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                    currCategory = "Электромобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.category.categoryName.Equals("Классические автомобили")).OrderBy(i => i.id);
                    currCategory = "Бензиновые автомобили";
                }
   
            }
            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                currCategory = currCategory
            };


            ViewBag.Title = "Онлайн магазин автомобилей";
           
            return View(carObj);
        }
    }
}
