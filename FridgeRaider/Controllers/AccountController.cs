using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using FridgeRaider.Models;
using System.Threading.Tasks;
using FridgeRaider.ViewModels;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;

namespace FridgeRaider.Controllers
{
  public class AccountController : Controller
  {
    private readonly FridgeRaiderContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, FridgeRaiderContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    public async Task<ActionResult> RecipeBook()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId); 
      var userMeals = _db.UserMeals.ToList().Where(join => join.UserId == currentUser.Id);
      List<Meal> recipeBook = new List<Meal> {};
      foreach(UserMeal join in userMeals)
      {
        recipeBook.Add(Meal.GetMeal(EnvironmentVariables.ApiKey, join.IdMeal)[0]);
      }
      return View(recipeBook);
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.UserName };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index");
    }
  }
}