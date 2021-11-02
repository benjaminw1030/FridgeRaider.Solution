using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FridgeRaider.Models
{
  public class FridgeRaiderContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<UserIngredient> UserIngredients { get; set; }
    public DbSet<UserMeal> UserMeals { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public FridgeRaiderContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}