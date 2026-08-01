using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static SocialNetwork.Common.ValidConstants;

namespace SocialNetwork.DataProcessor.ImportDTOs;

public class ImportPostDto
{
    [Required]
    [StringLength(PostContentMaxLength,
        MinimumLength = PostContentMinLength)]
    [JsonProperty("Content")]
    public string Content { get; set; } = null!;

    [Required]
    [JsonProperty("CreatedAt")]
    public string CreatedAt { get; set; } = null!;

    [JsonProperty("CreatorId")]
    public int CreatorId { get; set; }
}
