using System.Net;
using DrinksInfo.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DrinksInfo;

public static class DrinkService
{
    public static async Task<List<Category>?> GetCategories()
    {
        RestClient restClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        RestRequest restRequest = new RestRequest("list.php?c=list");
        RestResponse response = await restClient.ExecuteAsync(restRequest);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        if (response.Content == null)
        {
            return null;
        }
        
        Categories? categories = JsonConvert.DeserializeObject<Categories>(response.Content);
        if (categories == null)
        {
            return null;
        }
        
        return categories.list;
    }

    public static async Task<List<Drink>?> GetDrinksByCategory(Category category)
    {
        RestClient restClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        RestRequest restRequest = new RestRequest($"filter.php?c={category.name}");
        RestResponse response = await restClient.ExecuteAsync(restRequest);
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }

        if (response.Content == null)
        {
            return null;
        }

        Drinks? drinks = JsonConvert.DeserializeObject<Drinks>(response.Content);
        if (drinks == null)
        {
            return null;
        }

        return drinks.list;
    }

    public static async Task<List<DrinkDetails>?> GetDrinkDetails(Drink drink)
    {
        RestClient restClient = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
        RestRequest restRequest = new RestRequest($"lookup.php?i={drink.id}");
        RestResponse response = await restClient.ExecuteAsync(restRequest);
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
        
        if (response.Content == null)
        {
            return null;
        }

        DrinkDetailsObject? drinkDetailsObject = JsonConvert.DeserializeObject<DrinkDetailsObject>(response.Content);
        if (drinkDetailsObject == null)
        {
            return null;
        }
        
        return drinkDetailsObject.list;
    }
}