namespace EventManager.ViewModels.Events;

public class EventIndexViewModel
{
    /* Няма нужда от Model Validation за ViewModels
     * Потокът на данни е от TRUSTED Server (DB) към UNTRUSTED Client */

    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public int CurrentParticipants { get; set; }

    public int MaxParticipants { get; set; }
}
