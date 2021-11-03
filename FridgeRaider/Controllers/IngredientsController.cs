using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using FridgeRaider.Models;

namespace FridgeRaider.Controllers
{
  public class IngredientsController : Controller
  {
    private readonly FridgeRaiderContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public IngredientsController(UserManager<ApplicationUser> userManager, FridgeRaiderContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    
    public ActionResult Index(string letter)
    {
      var allIngredients = Ingredient.GetIngredients(EnvironmentVariables.ApiKey).ToList();
      var sortedIngredients = allIngredients.OrderBy(x => x.StrIngredient).ToList();
      ViewBag.FirstLetters = sortedIngredients.Select(s => s.StrIngredient[0]).Distinct().ToList();
      
      var ingredients = Ingredient.GetIngredients(EnvironmentVariables.ApiKey)
        .ToList()
        .Where(x => x.StrIngredient[0].ToString() == letter);
      return View(ingredients);
    }

    public IActionResult Details(string id)
    {
      var ingredientDetails = Ingredient.GetIngredients(EnvironmentVariables.ApiKey).ToList()
      .Where(x => x.IdIngredient == id).ToList();
      return View(ingredientDetails);
    }

    [HttpPost]
    public async Task<ActionResult> AddIngredient(ApplicationUser user, string idIngredient)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      if (idIngredient != null)
      {
        _db.UserIngredients.Add(new UserIngredient() { UserId = currentUser.Id, IdIngredient = idIngredient });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}