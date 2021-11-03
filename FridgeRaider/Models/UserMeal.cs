using System.ComponentModel.DataAnnotations;

namespace FridgeRaider.Models
{
  public class UserMeal
  {
    [Key]
    public int UserMealId { get; set; }
    public string IdMeal { get; set; }
    public string UserId { get; set; }
    public virtual Meal Meal { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
  }
}