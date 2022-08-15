using FastFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Data.Interfaces
{
    public interface IFoodRepository
    {
        IEnumerable<Food> Foods { get; }
        IEnumerable<Food> PreferredFoods { get; }
        Food GetFoodById(int foodId);
    }
}
