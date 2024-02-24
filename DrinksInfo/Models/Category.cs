using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class Category
{
    [JsonProperty("strCategory")]
    public string name { get; set; }

    public Category(string name)
    {
        this.name = name;
    }
}