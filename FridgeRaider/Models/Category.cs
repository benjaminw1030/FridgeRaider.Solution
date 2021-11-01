using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FridgeRaider.Models
{
  public class Category
  {
    public string IdCategory { get; set; }
    public string StrCategory { get; set; }
    public string StrCategoryThumb { get; set; }
    public string StrCategoryDescription { get; set; }

    public static List<Category> GetCategories(string apiKey)
    {
      var apiCallTask = ApiHelper.GetCategories(apiKey);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Category> categoryList = JsonConvert.DeserializeObject<List<Category>>(jsonResponse["categories"].ToString());
      return categoryList;
    }
  }
}


// using System.Collections.Generic;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;

// namespace MvcApiCall.Models
// {
//   public class Article
//   {
//     public string Section { get; set; }
//     public string Title { get; set; }
//     public string Abstract { get; set; }
//     public string Url { get; set; }
//     public string Byline { get; set; }

//     public static List<Article> GetArticles(string apiKey)
//     {
//       var apiCallTask = ApiHelper.ApiCall(apiKey);
//       var result = apiCallTask.Result;
//       JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
//       List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());

//       return articleList;
//     }
//   }
// }