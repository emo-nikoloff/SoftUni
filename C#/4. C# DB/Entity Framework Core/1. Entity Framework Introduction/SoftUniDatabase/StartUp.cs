using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni;

public class StartUp
{
    public static void Main(string[] args)
    {
        SoftUniContext dbContext = new(); // нямаме опции, затова използваме стандартния зададен connection string (.OnConfiguring())

        // Задача 3
        string employeesFullInformation = GetEmployeesFullInformation(dbContext);
        Console.WriteLine(employeesFullInformation);

        // Задача 4
        string employeesWithSalaryOver50000 = GetEmployeesWithSalaryOver50000(dbContext);
        Console.WriteLine(employeesWithSalaryOver50000);

        // Задача 5
        string rndEmployees = GetEmployeesFromResearchAndDevelopment(dbContext);
        Console.WriteLine(rndEmployees);

        // Задача 6
        string employeeNewAddress = AddNewAddressToEmployee(dbContext);
        Console.WriteLine(employeeNewAddress);

        // Задача 7
        string employeesInPeriod = GetEmployeesInPeriod(dbContext);
        Console.WriteLine(employeesInPeriod);

        // Задача 8
        string addressesByTown = GetAddressesByTown(dbContext);
        Console.WriteLine(addressesByTown);

        // Задача 9
        string employee147 = GetEmployee147(dbContext);
        Console.WriteLine(employee147);

        // Задача 10
        string departmentsWithMoreThan5Employees = GetDepartmentsWithMoreThan5Employees(dbContext);
        Console.WriteLine(departmentsWithMoreThan5Employees);

        // Задача 11
        string latestProjects = GetLatestProjects(dbContext);
        Console.WriteLine(latestProjects);

        // Задача 12
        string filteredEmployees = IncreaseSalaries(dbContext);
        Console.WriteLine(filteredEmployees);

        // Задача 13
        string employeesFirstNameStartingWithSa = GetEmployeesByFirstNameStartingWithSa(dbContext);
        Console.WriteLine(employeesFirstNameStartingWithSa);

        // Задача 14
        string projectsInfoWithoutProject2 = DeleteProjectById(dbContext);
        Console.WriteLine(projectsInfoWithoutProject2);

        // Задача 15
        string townToDelete = RemoveTown(dbContext);
        Console.WriteLine(townToDelete);
    }

    // Задача 3
    public static string GetEmployeesFullInformation(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        // .ToArray()/.ToList() - използват се за материализация на заявката
        // материализация - генерира SQL заявка базирана на LINQ Expression Tree и тази заявка се изпраща към SQL Server и се чака отговор. Всичко след материализацията се случва client-side
        // Съвет: материализацията по принцип е бавна операция! Винаги използвайте .Take(), за да ограничите записите в row set!
        // .Select() се използва да се направи проекция (селектират се определени колони + computed (calculated) колони)
        // LINQ проекцията позволява .Select() да бъде използван с класове и анонимни типове (най-често срещани)
        // Форматиране на числа е по-добре да се случва in-memory, а не в базата
        // Подреждането е по-добре да се извършва в базата, когато е възможно
        // EF Core е умен и ни дава възможност да не спазваме подредбата на командите, както в SQL - той сам ги подрежда
        var employees = dbContext.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new /* селекцията се извършва с анонимен тип, защото данните са временни - създаваме временен обект със съответните колони - ChangeTracker не
                                                  проследява  анонимните обекти */
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        // Съвет: Имайте предвид, че employees се проследяват след извличането на информацията от базата! Промени ще бъдат отразени след извикване .SaveChanges()!
        // Ако искате изрично да кажете да не се проследяват, използвайте .AsNoTracking() - препоръчва се, когато искате нещо да не бъде проследявано
        foreach (var employee in employees)
        {
            result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 4
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        var employees = dbContext.Employees
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .ToArray();

        foreach (var employee in employees)
        {
            result.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 5
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        // Използвайки навигационното пропърти, изпускаме JOINs и/или subqueries
        // Съвет: избягвайте да използвате текстови променливи и литерари директно в .Where() клаузата
        var rndEmployees = dbContext.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name, // EF Core автоматично ще свърже и ще вземе информацията от правилната колона във свързаната таблица
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToArray();

        foreach (var employee in rndEmployees)
        {
            result.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 6
    public static string AddNewAddressToEmployee(SoftUniContext dbContext)
    {
        /* SQL Sequence
            1. Създаване на нов запис за адресите
            2. Задаване на AddressId на работник да е AddressId на новия адрес 
        */

        /* EF Core позволява да се пропусне 1., използвайки cascading (каскадно) добавяне
        Address newAddress = new()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        // При довабянето на новия адрес ChangeTracker го маркира като ново Entity. Все още не е отразено в базата - само in-memory
        dbContext.Addresses.Add(newAddress); 
        */

        // Employee entity се проследява от ChangeTracker
        Employee employeeNakov = dbContext.Employees.
            First(e => e.LastName == "Nakov");

        // Няма нужда да се използва Foreign Key, за да се смени адресът на работника
        employeeNakov.Address = new()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        // Всички промени се запазват в ChangeTracker - in-memory. Накрая тези промени трябва да се запазят в базата!
        dbContext.SaveChanges();

        IEnumerable<string?> employeesAddresses = dbContext.Employees
            .OrderByDescending(e => e.AddressId)
            .Select(e => new
            {
                AddressText = e.Address != null ?
                    e.Address.AddressText : null
            })
            .Select(e => e.AddressText) // EF Core ще се погрижи навигационното пропърти да е инстанцирано
            .Take(10)
            .ToArray();

        return string.Join(Environment.NewLine, employeesAddresses);
    }

    // Задача 7
    public static string GetEmployeesInPeriod(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        // Запомнете, че материализираните заявки (в случая Projects) също трябва да бъдат материализирани!
        var top10EmployeesInPeriod = dbContext.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager != null ?
                    e.Manager.FirstName : null,
                ManagerLastName = e.Manager != null ?
                    e.Manager.LastName : null,
                Projects = e.EmployeesProjects
                    .Select(ep => ep.Project) // Това се пропуска чрез "пропускане на навигационно пропърти"
                    .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        p.Name,
                        p.StartDate,
                        p.EndDate
                    })
                    .ToArray()
            })
            .Take(10)
            .ToArray();

        foreach (var employee in top10EmployeesInPeriod)
        {
            result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

            foreach (var project in employee.Projects)
            {
                string startDateFormatted = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                string endDateFormatted = project.EndDate.HasValue ?
                    project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";
                result.AppendLine($"--{project.Name} - {startDateFormatted} - {endDateFormatted}");
            }
        }

        return result.ToString().TrimEnd();
    }

    // Задача 8
    public static string GetAddressesByTown(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        var addressesByTown = dbContext.Addresses
            .Select(a => new
            {
                a.AddressText,
                TownName = a.Town != null ?
                    a.Town.Name : null,
                a.Employees
            })
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.TownName)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .ToArray();

        foreach (var address in addressesByTown)
        {
            result.AppendLine($"{address.AddressText}, {address.TownName} - {address.Employees.Count} employees");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 9
    public static string GetEmployee147(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        var employee147 = dbContext.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                    .Select(ep => ep.Project)
                    .Select(p => new
                    {
                        p.Name
                    })
                    .OrderBy(p => p.Name)
                    .ToArray()
            })
            .ToArray();

        foreach (var item in employee147)
        {
            result.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle}");

            foreach (var project in item.Projects)
            {
                result.AppendLine(project.Name);
            }
        }

        return result.ToString().TrimEnd();
    }

    // Задача 10
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        var departmentsWithMoreThan5Employees = dbContext.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees // пропъртитата на анонимните типове, които са entity типове, се следят от ChangeTracker, ако не се превърнат и те в анонимен тип
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToArray()
            })
            .ToArray();

        foreach (var department in departmentsWithMoreThan5Employees)
        {
            result.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");

            foreach (var employee in department.Employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            }
        }

        return result.ToString().TrimEnd();
    }

    // Задача 11
    public static string GetLatestProjects(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        var latestProjects = dbContext.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .OrderBy(p => p.Name)
            .ToArray();

        foreach (var project in latestProjects)
        {
            result.AppendLine(project.Name);
            result.AppendLine(project.Description);

            string startDateFormatted = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");
            result.AppendLine(startDateFormatted);
        }

        return result.ToString().TrimEnd();
    }

    // Задача 12
    public static string IncreaseSalaries(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        string[] departments = { "Engineering", "Tool Design", "Marketing", "Information Services" };

        Employee[] filteredEmployees = dbContext.Employees
            .Where(e => departments.Contains(e.Department.Name))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        foreach (Employee employee in filteredEmployees)
        {
            employee.Salary += employee.Salary * 0.12m;
        }

        dbContext.SaveChanges();

        foreach (Employee employee in filteredEmployees)
        {
            result.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 13
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext dbContext)
    {
        StringBuilder result = new();

        var employeesFirstNameStartingWithSa = dbContext.Employees
            .Where(e => e.FirstName.StartsWith("Sa"))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();

        foreach (var employee in employeesFirstNameStartingWithSa)
        {
            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
        }

        return result.ToString().TrimEnd();
    }

    // Задача 14
    public static string DeleteProjectById(SoftUniContext dbContext)
    {
        /*
          EF Core поддържа каскадно, нулиращо и ограничаващо изтриване:
          - Cascading - всички обвързани обекти ще бъдат изтрити
          - Nullify - на всички обвързани обекти Foreign Key ще бъде зададен на NULL
          - Restrict - всички обвързани обекти няма да бъдат променени, но операцията ще бъде отменена, ако има обвързани обекти
        */
        Project? projectToDelete = dbContext.Projects
            .Find(2);

        if (projectToDelete != null) // Подсигуряваме, че проекта съществува
        {
            // ChangeTracker може да работи и с нематериализирани заявки. Това позволява да се направи оптимизация - обектите не се съхраняват in-memory
            IQueryable<EmployeeProject> employeeProjectsToDelete = dbContext.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);

            // Първо се изтриват всички обвързани обекти
            dbContext.RemoveRange(employeeProjectsToDelete);

            // Премахваме обекта от DbSet, което маркира обекта като премахнат в ChangeTracker in-memory
            // Все още няма реално изтриване от базата
            dbContext.Projects.Remove(projectToDelete);

            // Запазваме промените в базата - реално изтриване от базата
            dbContext.SaveChanges();
        }

        IEnumerable<string> top10Projects = dbContext.Projects
            .Select(p => p.Name)
            .Take(10)
            .ToArray();

        return string.Join(Environment.NewLine, top10Projects);
    }

    // Задача 15
    public static string RemoveTown(SoftUniContext dbContext)
    {
        Town? townToDelete = dbContext.Towns
            .FirstOrDefault(t => t.Name == "Seattle");

        if (townToDelete == null)
        {
            return "0 addresses in Seattle were deleted";
        }

        List<Address> addressesRelatedToTown = dbContext.Addresses
            .Where(a => a.TownId == townToDelete.TownId)
            .ToList();

        List<Employee> employeesToUpdate = dbContext.Employees
            .Where(e => e.Address != null && e.Address.TownId == townToDelete.TownId)
            .ToList();

        foreach (Employee employee in employeesToUpdate)
        {
            employee.AddressId = null;
        }

        int removedAddressesCount = addressesRelatedToTown.Count;

        dbContext.Addresses.RemoveRange(addressesRelatedToTown);

        dbContext.Towns.Remove(townToDelete);

        dbContext.SaveChanges();

        return $"{removedAddressesCount} addresses in Seattle were deleted";
    }
}
