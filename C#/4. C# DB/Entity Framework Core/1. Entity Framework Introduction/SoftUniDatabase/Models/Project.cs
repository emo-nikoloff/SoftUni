namespace SoftUni.Models;

public class Project
{
    public int ProjectId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    /* понеже Judge изисква mapping таблица EmployeesProjects, тази навигационна колекция е ненужна
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>(); // пропускане на навигационно пропърти - пропуска mapping entity (свързващата таблица EmployeesProjects),
                                                                                            създавайки директна Many-to-Many връзка
    */

    public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; } = new List<EmployeeProject>();
}
