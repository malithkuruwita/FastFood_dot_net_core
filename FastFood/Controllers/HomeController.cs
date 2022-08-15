using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFood.Data.Interfaces;
using FastFood.Data.Models;
using FastFood.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFoodRepository _foodrepository;
        public HomeController(ICategoryRepository categoryrepository, IFoodRepository foodrepository)
        {
            _categoryRepository = categoryrepository;
            _foodrepository = foodrepository;
        }


        public ViewResult Index()
        {
            var FoodListViewModel = new FoodListViewModel
            {
                PreferredFoods = _foodrepository.PreferredFoods
            };


            return View(FoodListViewModel);
        }


       




    }
}
