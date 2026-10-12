namespace Homies.DataTransferObjects.Event;

public class EventAllViewModel
{
    // ViewModel: TRUSTED Server -> UNTRUSTED Client - няма нужда от Model Validation

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Start { get; set; } = null!;

    public string TypeName { get; set; } = null!;

    public string OrganiserUsername { get; set; } = null!;
}
