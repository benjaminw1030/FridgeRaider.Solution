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
      var allIngredients = Ingredient.GetIngredients(EnvironmentVariables.ApiKey);
      return View(allIngredients);
    }
  }
}