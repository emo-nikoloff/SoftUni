namespace GameZone.ViewModels.Game;

public class GameAllViewModel
{
    // ViewModel - TRUSTED Server App -> UNTRUSTED Client App - няма нужда от Data Validation

    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public string Publisher { get; set; } = null!;

    public string ReleasedOn { get; set; } = null!;

    public string GenreName { get; set; } = null!;
}
