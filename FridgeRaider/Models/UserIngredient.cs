using System.ComponentModel.DataAnnotations;

namespace FridgeRaider.Models
{
  public class UserIngredient
  {
    [Key]
    public int UserIngredientId { get; set; }
    public string IdIngredient { get; set; }
    public string UserId { get; set; }
    public virtual Ingredient Ingredient { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
  }
}