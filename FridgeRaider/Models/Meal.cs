using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeRaider.Models
{
  [NotMapped]
  public class Meal
  {
    public string IdMeal { get; set; }
    public string StrMeal { get; set; }
    public string StrCategory { get; set; }
    public string StrArea { get; set; }
    public string StrInstructions { get; set; }
    public string StrMealThumb { get; set; }
    public string StrMealTags { get; set; }
    public string StrYoutube { get; set; }
    public string StrIngredient1 { get; set; }
    public string StrIngredient2 { get; set; }
    public string StrIngredient3 { get; set; }
    public string StrIngredient4 { get; set; }
    public string StrIngredient5 { get; set; }
    public string StrIngredient6 { get; set; }
    public string StrIngredient7 { get; set; }
    public string StrIngredient8 { get; set; }
    public string StrIngredient9 { get; set; }
    public string StrIngredient10 { get; set; }
    public string StrIngredient11 { get; set; }
    public string StrIngredient12 { get; set; }
    public string StrIngredient13 { get; set; }
    public string StrIngredient14 { get; set; }
    public string StrIngredient15 { get; set; }
    public string StrIngredient16 { get; set; }
    public string StrIngredient17 { get; set; }
    public string StrIngredient18 { get; set; }
    public string StrIngredient19 { get; set; }
    public string StrIngredient20 { get; set; }
    public string StrMeasure1 { get; set; }
    public string StrMeasure2 { get; set; }
    public string StrMeasure3 { get; set; }
    public string StrMeasure4 { get; set; }
    public string StrMeasure5 { get; set; }
    public string StrMeasure6 { get; set; }
    public string StrMeasure7 { get; set; }
    public string StrMeasure8 { get; set; }
    public string StrMeasure9 { get; set; }
    public string StrMeasure10 { get; set; }
    public string StrMeasure11 { get; set; }
    public string StrMeasure12 { get; set; }
    public string StrMeasure13 { get; set; }
    public string StrMeasure14 { get; set; }
    public string StrMeasure15 { get; set; }
    public string StrMeasure16 { get; set; }
    public string StrMeasure17 { get; set; }
    public string StrMeasure18 { get; set; }
    public string StrMeasure19 { get; set; }
    public string StrMeasure20 { get; set; }
    public string StrSource { get; set; }
    
    public static List<Meal> GetMealsInCategory(string apiKey, string category)
    {
      var apiCallTask = ApiHelper.GetMealsInCategory(apiKey, category);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Meal> mealList = JsonConvert.DeserializeObject<List<Meal>>(jsonResponse["meals"].ToString());
      return mealList;
    }

    public static List<Meal> GetMeal(string apiKey, string idMeal)
    {
      var apiCallTask = ApiHelper.GetMeal(apiKey, idMeal);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Meal> mealList = JsonConvert.DeserializeObject<List<Meal>>(jsonResponse["meals"].ToString());
      return mealList;
    }

    public static List<Meal> GetMealByName(string apiKey, string search)
    {
      var apiCallTask = ApiHelper.GetMealByName(apiKey, search);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Meal> mealList = JsonConvert.DeserializeObject<List<Meal>>(jsonResponse["meals"].ToString());
      return mealList;
    }

    public static List<Meal> GetMealsByFirstLetter(string apiKey, string letter)
    {
      var apiCallTask = ApiHelper.GetMealsByFirstLetter(apiKey, letter);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Meal> mealList = JsonConvert.DeserializeObject<List<Meal>>(jsonResponse["meals"].ToString());
      return mealList;
    }

    public static List<Meal> GetRandomMeals(string apiKey)
    {
      var apiCallTask = ApiHelper.GetRandomMeals(apiKey);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Meal> mealList = JsonConvert.DeserializeObject<List<Meal>>(jsonResponse["meals"].ToString());
      return mealList;
    }
  }
}