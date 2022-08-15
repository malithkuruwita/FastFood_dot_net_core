using FastFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.ViewModels
{
    public class FoodListViewModel
    {
         public IEnumerable<Food> Foods { get; set; }
        IEnumerable<Category> Categories { get; }
        public IEnumerable<Food> PreferredFoods { get; set; }

        public string CurrentCategory { get; set; }
    }
}
