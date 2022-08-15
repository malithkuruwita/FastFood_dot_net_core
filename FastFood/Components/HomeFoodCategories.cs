using FastFood.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Components
{
    public class HomeFoodCategories:ViewComponent
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IFoodRepository _foodrepository;
        public HomeFoodCategories(ICategoryRepository categoryrepository, IFoodRepository foodrepository)
        {
            _categoryRepository = categoryrepository;
            _foodrepository = foodrepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(p => p.CategoryName);
            return View(categories);
        }



    }
}
