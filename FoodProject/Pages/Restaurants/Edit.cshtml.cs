using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodProject.Core;
using FoodProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodProject.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        // Services
        private readonly IRestaurantData restaurantData;
        public IHtmlHelper htmlHelper;

        // Properties
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        // Adding a parameter onto the OnGet parameter list loads that into the model. (Input)
        // Creating a property (for example Cuisines) and adding data to it inside the OnGet method sends it to the view / page. (Output)
        // Adding the "BindProperty" directive does both.

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>(); // Considering enums cannot be instantiated, all you need to provide is the generic <CuisineType> on the GetEnumSelectList method, and it will retrieve a list of that given enum items.
            
            if (restaurantId.HasValue) // Considering restaurantId is optional because of adding a restaurant, we only want to search if there is a value.
                Restaurant = restaurantData.GetById(restaurantId.Value);
            else {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
        
        public IActionResult OnPost()
        {
            // Information given was not valid.
            if (!ModelState.IsValid) // Validates the ModelState, which is updated whenever a Model Binding occurs (such as the int restaurantId of onGet, or when the Restaurant property is bound).
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            // Update and redirect to another page.
            if (Restaurant.Id > 0)
                restaurantData.Update(Restaurant);
            else
                restaurantData.Add(Restaurant);
            restaurantData.Commit();
            TempData["SavedRestaurant"] = true; // This is useful to avoid sending it in the header, and the user bookmarking the page with that information inside the header, which would therefore show it everytime the user lands on that page thru the bookmark.
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id }); // We are redirecting to a detail page, therefore we need to provide a restaurantId. We do so by creating an anonymous-type object.

        }
    }
}
