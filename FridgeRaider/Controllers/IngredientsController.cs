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
  public class IngredientsController : Controller
  {
    public ActionResult Index()
    {
      var allIngredients = Ingredient.GetIngredients(EnvironmentVariables.ApiKey).ToList();
      var sortedIngredients = allIngredients.OrderBy(x => x.StrIngredient).ToList();
      ViewBag.FirstLetters = sortedIngredients.Select(s => s.StrIngredient[0]).Distinct().ToList();
      return View(sortedIngredients);
    }

    public ActionResult Details(string letter)
    {
      var ingredients = Ingredient.GetIngredients(EnvironmentVariables.ApiKey)
        .ToList()
        .Where(x => x.StrIngredient[0].ToString() == letter);
      return View(ingredients);
    }
  }
}