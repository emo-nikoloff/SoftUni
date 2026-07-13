using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace ProductShop.DTOs.Import;

public class ImportUserDto
{
    [JsonProperty("firstName")] /* препоръчително е да се използва, защото така премахваме имплицитната връзка между имената на пропъртитата в DTO-то и имената на пропъртитата в
                                                JSON-а, и я задаваме експлицитно, което позволява по-голяма гъвкавост и избягване на проблеми при случайна смяна на име на пропърти в DTO */
    public string? FirstName { get; set; }

    [Required]
    [JsonProperty("lastName")]
    public string LastName { get; set; } = null!;

    [JsonProperty("age")]
    public int? Age { get; set; }
}
