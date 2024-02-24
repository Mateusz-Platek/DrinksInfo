using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category>? list { get; set; }

    public Categories(List<Category>? list)
    {
        this.list = list;
    }
}