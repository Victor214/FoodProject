using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Core;
using FoodProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodProject.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [TempData] // Automatically modelbinds directly from temp data, if it finds "SavedRestaurant" inside TempData.
        public Boolean SavedRestaurant { get; set; }
        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}
