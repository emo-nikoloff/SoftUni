using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace ProductShop.DTOs.Import;

public class ImportProductDto
{
    // Required няма да хвърли грешка - ще върне false от IsValid() метода в случай, че Required атрибута не е изпълнен
    [Required]
    [JsonProperty("Name")]
    public string Name { get; set; } = null!;

    // JsonRequired може да хвърли грешка по време на изпълнението на .DeserializeObject<T> метода - кара пропъртито в json-а винаги да има стойност
    [JsonRequired]
    [JsonProperty("Price")]
    public decimal Price { get; set; } /* понеже тези required типове имат стойност по подразбиране 0, ако JsonConverter-а не ги открие или получи null, има възможност програмата да не спре и да
                                          попълни стойността по подразбиране */

    [JsonRequired]
    [JsonProperty("SellerId")]
    public int SellerId { get; set; }

    [JsonProperty("BuyerId")]
    public int? BuyerId { get; set; }
}
