namespace SoftUni.Models;

public class Address
{
    public int AddressId { get; set; }

    public string AddressText { get; set; } = null!; // = null! - задължително (required) <=> NOT NULL

    public int? TownId { get; set; }

    // Съвет: навигационните пропъртита и колекции трябва да са виртуални
    // Съвет: nullability-то на Foreign Key (в този случай TownId) трябва да съответства на nullability-то на навигационното пропърти
    // Съвет: всяко навигационно пропърти да стои под неговия Foreign Key
    public virtual Town? Town { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>(); /* препоръчва се да се използва inline инициализация за виртуални навигационни колекции,
                                                                                            вместо чрез конструктор, за да се избегнат проблеми в бъдеще
                                                                                         */
}
