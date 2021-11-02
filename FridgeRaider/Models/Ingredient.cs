using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeRaider.Models
{
  [NotMapped]
  public class Ingredient
  {
    public string IdIngredient { get; set; }
    public string StrIngredient { get; set; }

    public static List<Ingredient> GetIngredients(string apiKey)
    {
      var apiCallTask = ApiHelper.GetIngredients(apiKey);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Ingredient> ingredientList = JsonConvert.DeserializeObject<List<Ingredient>>(jsonResponse["meals"].ToString());
      return ingredientList;
    }
  }
}