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
      var mealDetails = Meal.GetMeal(EnvironmentVariables.ApiKey, id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      IEnumerable<UserMeal> userMeals = _db.UserMeals.ToList().Where(join => join.UserId == userId);
      IEnumerable<UserIngredient> userIngredients = _db.UserIngredients.ToList().Where(join => join.UserId == userId);

      List<string> mealIngredients = MealIngredients(mealDetails[0]);
      ViewBag.RequiredIngredients = new List<string> { };

      List<string> fridge = new List<string> { };
      IEnumerable<Ingredient> allIngredients = Ingredient.GetIngredients(EnvironmentVariables.ApiKey);
      foreach (Ingredient ingredient in allIngredients)
      {
        foreach (UserIngredient join in userIngredients)
        {
          if (ingredient.IdIngredient == join.IdIngredient)
          {
            fridge.Add(ingredient.StrIngredient);
          }
        }
      }

      foreach (string i in mealIngredients)
      {
        if (!fridge.Contains(i))
        {
          ViewBag.RequiredIngredients.Add(i);
        }
      }

      ViewBag.Saved = userMeals.Any(m => m.IdMeal == id);
      if (ViewBag.Saved)
      {
        ViewBag.JoinId = userMeals.FirstOrDefault(entry => entry.IdMeal == id).UserMealId;
      }
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
    public IActionResult Search(string searchString)
    {
      var result = Meal.SearchMealByName(EnvironmentVariables.ApiKey, searchString);
      return View(result);
    }

    [HttpPost]
    public ActionResult DeleteMeal(int joinId)
    {
      var JoinEntry = _db.UserMeals.FirstOrDefault(entry => entry.UserMealId == joinId);
      _db.UserMeals.Remove(JoinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = JoinEntry.IdMeal });
    }

    public List<string> MealIngredients(Meal meal)
    {
      List<string> mealIngredients = new List<string> { };
      if (!String.IsNullOrEmpty(meal.StrIngredient1))
      {
        mealIngredients.Add(meal.StrIngredient1);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient2))
      {
        mealIngredients.Add(meal.StrIngredient2);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient3))
      {
        mealIngredients.Add(meal.StrIngredient3);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient4))
      {
        mealIngredients.Add(meal.StrIngredient4);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient5))
      {
        mealIngredients.Add(meal.StrIngredient5);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient6))
      {
        mealIngredients.Add(meal.StrIngredient6);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient7))
      {
        mealIngredients.Add(meal.StrIngredient7);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient8))
      {
        mealIngredients.Add(meal.StrIngredient8);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient9))
      {
        mealIngredients.Add(meal.StrIngredient9);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient10))
      {
        mealIngredients.Add(meal.StrIngredient10);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient11))
      {
        mealIngredients.Add(meal.StrIngredient11);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient12))
      {
        mealIngredients.Add(meal.StrIngredient12);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient13))
      {
        mealIngredients.Add(meal.StrIngredient13);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient14))
      {
        mealIngredients.Add(meal.StrIngredient14);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient15))
      {
        mealIngredients.Add(meal.StrIngredient15);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient16))
      {
        mealIngredients.Add(meal.StrIngredient16);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient17))
      {
        mealIngredients.Add(meal.StrIngredient17);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient18))
      {
        mealIngredients.Add(meal.StrIngredient18);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient19))
      {
        mealIngredients.Add(meal.StrIngredient19);
      }
      if (!String.IsNullOrEmpty(meal.StrIngredient20))
      {
        mealIngredients.Add(meal.StrIngredient20);
      }
      return mealIngredients;
    }
  }
}