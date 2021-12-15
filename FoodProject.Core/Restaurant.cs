using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodProject.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, StringLength(80)] // These checks are done automatically when Data Binding happens.
        public String Name { get; set; }

        [Required, StringLength(255)]
        public String Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
