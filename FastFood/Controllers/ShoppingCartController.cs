using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFood.Data.Interfaces;
using FastFood.Data.Models;
using FastFood.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FastFood.Controllers
{
    public class ShoppingCartController : Controller
    {


        private readonly IFoodRepository _foodRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IFoodRepository foodRepository,ShoppingCart shoppingCart)
        {
            _foodRepository = foodRepository;
            _shoppingCart = shoppingCart;
        }

       
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;


            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            }; 


            return View(sCVM);
        }

        
        public RedirectToActionResult AddToShoppingCart(int foodId)
        {
            var selectedFood = _foodRepository.Foods.FirstOrDefault(p => p.FoodId == foodId);
            if(selectedFood != null)
            {
                _shoppingCart.AddToCart(selectedFood, 1);

            }

            return RedirectToAction("Index");


        }


        public RedirectToActionResult RemoveFromShoppingCart(int foodId)
        {
            var selectedFood = _foodRepository.Foods.FirstOrDefault(p => p.FoodId == foodId);
            if(selectedFood != null)
            {
                _shoppingCart.RemoveFromCart(selectedFood);
            }
            return RedirectToAction("Index");
        } 


    }
}
