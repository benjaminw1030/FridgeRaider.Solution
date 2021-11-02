using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;

namespace FridgeRaider.Models
{
  public class ApplicationUser : IdentityUser
  {
    public virtual ICollection<UserMeal> UserMeals { get; set; }
    public virtual ICollection<UserIngredient> UserIngredients { get; set; }
  }
}