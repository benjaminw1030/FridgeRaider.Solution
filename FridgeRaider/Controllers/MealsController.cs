using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgeRaider.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;

namespace FridgeRaider.Controllers
{
  public class MealsController : Controller
  {
    private readonly FridgeRaiderContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public MealsController(UserManager<ApplicationUser> userManager, FridgeRaiderContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    //Categories Index
    public IActionResult Index()
    {
      var allCategories = Category.GetCategories(EnvironmentVariables.ApiKey);
      return View(allCategories);
    }

    //Categories Details
    [HttpGet, ActionName("Category")]
    public IActionResult CategoryDetails(string id)
    {
      var mealsInCategory = Meal.GetMealsInCategory(EnvironmentVariables.ApiKey, id);
      return View(mealsInCategory);
    }

    public IActionResult Details(string id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      IEnumerable<UserMeal> userMeals = _db.UserMeals.ToList().Where(join => join.UserId == userId);
      ViewBag.Saved = userMeals.Any(m => m.IdMeal == id);
      if (ViewBag.Saved)
      {
        ViewBag.JoinId = userMeals.FirstOrDefault(entry => entry.IdMeal == id).UserMealId;
      }
      var mealDetails = Meal.GetMeal(EnvironmentVariables.ApiKey, id);
      return View(mealDetails);
    }

    [HttpPost]
    public async Task<ActionResult> AddMeal(ApplicationUser user, string idMeal)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      if (idMeal != null)
      {
        _db.UserMeals.Add(new UserMeal() { UserId = currentUser.Id, IdMeal = idMeal });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = idMeal });
    }
    [HttpPost]
    public ActionResult DeleteMeal(int joinId)
    {
      var JoinEntry = _db.UserMeals.FirstOrDefault(entry => entry.UserMealId == joinId);
      _db.UserMeals.Remove(JoinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = JoinEntry.IdMeal });
    }
  }
}