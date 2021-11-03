using System.Threading.Tasks;
using RestSharp;

namespace FridgeRaider.Models
{
  class ApiHelper
  {
    public static async Task<string> GetCategories(string apiKey)
    {
      RestClient client = new RestClient("http://www.themealdb.com/api");
      RestRequest request = new RestRequest($"json/v2/{apiKey}/categories.php", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetMealsInCategory(string apiKey, string category)
    {
      RestClient client = new RestClient("http://www.themealdb.com/api");
      RestRequest request = new RestRequest($"json/v2/{apiKey}/filter.php?c={category}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetMeal(string apiKey, string idMeal)
    {
      RestClient client = new RestClient("http://www.themealdb.com/api");
      RestRequest request = new RestRequest($"json/v2/{apiKey}/lookup.php?i={idMeal}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetMealByName(string apiKey, string search)
    {
      RestClient client = new RestClient("http://www.themealdb.com/api");
      RestRequest request = new RestRequest($"json/v2/{apiKey}/search.php?s={search}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetMealsByFirstLetter(string apiKey, string letter)
    {
      RestClient client = new RestClient("http://www.themealdb.com/api");
      RestRequest request = new RestRequest($"json/v2/{apiKey}/search.php?f={letter}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetIngredients(string apiKey)
    {
      RestClient client = new RestClient("http://www.themealdb.com/api");
      RestRequest request = new RestRequest($"json/v2/{apiKey}/list.php?i=list", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetRandomMeals(string apiKey)
    {
      RestClient client = new RestClient("http://www.themealdb.com/api");
      RestRequest request = new RestRequest($"json/v2/{apiKey}/randomselection.php", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}

// www.themealdb.com/api/json/v2/1/filter.php?i=chicken_breast

// www.themealdb.com/api/json/v2/1/categories.php

// call the entire meal list
// filter out results with where to get ingredients by first letter of alphabet