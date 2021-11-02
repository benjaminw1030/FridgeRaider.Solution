namespace FridgeRaider.Models
{
  public class UserMeal
  {
    public int UserMealId { get; set; }
    public string IdMeal { get; set; }
    public string Id { get; set; }
    public virtual Meal Meal { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}