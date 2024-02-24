using Newtonsoft.Json;

namespace DrinksInfo.Models;

public class DrinkDetailsObject
{
    [JsonProperty("drinks")]
    public List<DrinkDetails> list { get; set; }

    public DrinkDetailsObject(List<DrinkDetails> list)
    {
        this.list = list;
    }
}