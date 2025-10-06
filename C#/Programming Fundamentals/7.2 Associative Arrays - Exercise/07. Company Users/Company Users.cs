/*Create a program that keeps information about companies and their employees.
You will be receiving a company name and an employee's id, until you receive the "End" command. Add each employee to the given company. Keep in mind that a company cannot have two employees with the
same id.
When you finish reading the data, print the company's name and each employee's id in the following format:
{companyName}
-- {id1}
-- {id2}
-- {idN}
· Until you receive the "End" command, you will be receiving input in the format: "{companyName} -> {employeeId}".
· The input always will be valid.*/
using System;
using System.Collections.Generic;

namespace _07._Company_Users;

class Program
{
    static void Main(string[] args)
    {
        string input;
        Dictionary<string, Company> companiesEmployeess = new();

        while ((input = Console.ReadLine()) != "End")
        {
            string[] info = input.Split(" -> ");

            string companyName = info[0];
            string employeeId = info[1];

            if (!companiesEmployeess.ContainsKey(companyName))
            {
                companiesEmployeess.Add(companyName, new(companyName));
            }

            if (!companiesEmployeess[companyName].Employees.Contains(employeeId))
            {
                companiesEmployeess[companyName].Employees.Add(employeeId);
            }
        }

        foreach ((string name, Company company) in companiesEmployeess)
        {
            Console.WriteLine($"{name}");
            foreach (string employee in company.Employees)
            {
                Console.WriteLine($"-- {employee}");
            }
        }
    }
}

class Company
{
    public Company(string name)
    {
        Name = name;
        Employees = new();
    }

    public string Name { get; set; }
    public List<string> Employees { get; set; }
}
