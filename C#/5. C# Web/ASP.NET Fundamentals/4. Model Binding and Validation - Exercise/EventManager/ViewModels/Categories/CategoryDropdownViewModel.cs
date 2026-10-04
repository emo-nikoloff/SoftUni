namespace EventManager.ViewModels.Categories;

public class CategoryDropdownViewModel
{
    /* Няма нужда от Model Validation за ViewModels
     * Потокът на данни е от TRUSTED Server (DB) към UNTRUSTED Client */

    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
