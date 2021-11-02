using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FridgeRaider.Models;

namespace FridgeRaider.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      //viewbag.meals = user.meals (latest 3)
      //viewbag.fridge = user.fridge (latest 3)
      var randomMeals = Meal.GetRandomMeals(EnvironmentVariables.ApiKey);
      return View(randomMeals);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
