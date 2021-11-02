using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgeRaider.Models;

namespace FridgeRaider.Controllers
{
  public class MealsController : Controller
  {
    //Categories Index
    public IActionResult Index()
    {
      var allCategories = Category.GetCategories(EnvironmentVariables.ApiKey);
      return View(allCategories);
    }

    //Categories Details
    public IActionResult CategoryDetails(string category)
    {
      var mealsInCategory = Meal.GetMealsInCategory(EnvironmentVariables.ApiKey, category);
      return View(mealsInCategory);
    }

    public IActionResult MealDetails(string id)
    {
      var mealDetails = Meal.GetMeal(EnvironmentVariables.ApiKey, id);
      return View(mealDetails);
    }
  }
}