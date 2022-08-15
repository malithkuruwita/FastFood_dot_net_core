using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFood.Data.Interfaces;
using FastFood.Data.Models;
using FastFood.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace FastFood.Controllers
{
    public class FastFoodController : Controller
    {
        private readonly IFoodRepository _foodrepository;
        public FastFoodController(IFoodRepository foodrepository)
        {
            _foodrepository = foodrepository;
        }

       
        public ViewResult List(string categoryid)
        {
            string _category = categoryid;
            IEnumerable<Food> foods;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(categoryid))
            {
                foods = _foodrepository.Foods.OrderBy(p => p.FoodId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Burger", _category, StringComparison.OrdinalIgnoreCase))
                    foods = _foodrepository.Foods.Where(p => p.Category.CategoryName.Equals("Burger")).OrderBy(p => p.Name);
                else if (string.Equals("Pizza", _category, StringComparison.OrdinalIgnoreCase))
                    foods = _foodrepository.Foods.Where(p => p.Category.CategoryName.Equals("Pizza")).OrderBy(p => p.Name);
                else
                    foods = _foodrepository.Foods.Where(p => p.Category.CategoryName.Equals("Drinks")).OrderBy(p => p.Name);
                currentCategory = _category;
            }

            return View(new FoodListViewModel
            {
                Foods = foods,
                
            });
        }


        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Food> foods;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                foods = _foodrepository.Foods.OrderBy(p => p.FoodId);
            }
            else
            {
                foods = _foodrepository.Foods.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/FastFood/List.cshtml", new FoodListViewModel { Foods = foods, CurrentCategory = "All drinks" });
        }



        public ViewResult Details(int foodId)
        {
            var food = _foodrepository.Foods.FirstOrDefault(d => d.FoodId == foodId);
            if (food == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(food);
        }

    }
}
