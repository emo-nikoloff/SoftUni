namespace SoftUni.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string JobTitle { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public int? ManagerId { get; set; }

    public virtual Employee? Manager { get; set; }

    /* Понеже Judge изисква mapping таблица EmployeesProjects, тази навигационна колекция е ненужна
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>(); // пропускане на навигационно пропърти (Skip Navigation Property) - пропуска mapping entity
                                                                                         (свързващата таблица EmployeesProjects), създавайки директна Many-to-Many връзка
    */

    public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; } = new List<EmployeeProject>();
}
