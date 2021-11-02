namespace FridgeRaider.Models
{
  public class UserIngredient
  {
    public int UserIngredientId { get; set; }
    public string IdIngredient { get; set; }
    public string Id { get; set; }
    public virtual Ingredient Ingredient { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}