using FoodProject.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


/*
 * Add the following to FoodProject.csproj file:
 *  <ItemGroup>
		<ProjectReference Include="..\FoodProject.Data\FoodProject.Data.csproj" />
	</ItemGroup>
 * Add dbcontext file
 * Add code block for MySql on Startup.cs
 * dotnet ef dbcontext info -s ..\FoodProject\FoodProject.csproj (Gather dbcontext information)
 * dotnet ef migrations add initialcreate -s ..\FoodProject\FoodProject.csproj (Create the first migration based on the restaurant class)
 * dotnet ef database update -s ..\FoodProject\FoodProject.csproj
 */

namespace FoodProject.Data
{
    public class FoodProjectDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public FoodProjectDbContext(DbContextOptions<FoodProjectDbContext> options) : base(options)
        {

        }
    }
}
