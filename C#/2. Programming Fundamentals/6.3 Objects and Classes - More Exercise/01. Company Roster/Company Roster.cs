/*Define a class Employee that holds the following information: a name, a salary and a department.
Your task is to write a program, which takes N lines of employees from the console, calculates the department with the highest average salary, and prints for each employee in that department their
name and salary – sorted by salary in descending order. The salary should be rounded to two digits after the decimal separator.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());
        List<Employee> employees = new();

        for (int i = 1; i <= magicNumber; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            double salary = double.Parse(input[1]);
            string department = input[2];

            Employee employee = new(name, salary, department);
            employees.Add(employee);
        }

        List<Employee> departmentWithHighestAverageSalary = employees.GroupBy(e => e.Department).OrderByDescending(s => s.Average(e => e.Salary)).First().ToList();
        string departmentName = departmentWithHighestAverageSalary.First().Department;

        Console.WriteLine($"Highest Average Salary: {departmentName}");

        foreach (Employee emp in departmentWithHighestAverageSalary.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:F2}");
        }
    }
}

class Employee
{
    public Employee(string name, double salary, string department)
    {
        Name = name;
        Salary = salary;
        Department = department;
    }

    public string Name { get; set; }
    public double Salary { get; set; }
    public string Department { get; set; }
}
