/*Use the class from the previous problem. If you receive a student, which already exists (first name and last name should be unique) overwrite the information.*/
using System;
using System.Collections.Generic;

namespace _05._Students_2._0;

class Program
{
    static void Main(string[] args)
    {
        string studentsInfo;
        List<Student> students = new();

        while ((studentsInfo = Console.ReadLine()) != "end")
        {
            string[] info = studentsInfo.Split();

            string firstName = info[0];
            string lastName = info[1];
            int age = int.Parse(info[2]);
            string homeTown = info[3];

            Student student = new();

            student.FirstName = firstName;
            student.LastName = lastName;
            student.Age = age;
            student.HomeTown = homeTown;

            if (IsStudentExisting(students, firstName, lastName))
            {
                student = GetStudent(students, firstName, lastName);
                student.Age = age;
                student.HomeTown = homeTown;
            }
            else
            {
                students.Add(student);
            }
        }

        string town = Console.ReadLine();

        foreach (Student student in students)
        {
            if (student.HomeTown == town)
            {
                student.Info();
            }
        }
    }

    static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
    {
        foreach (Student student in students)
        {
            if (student.FirstName == firstName && student.LastName == lastName)
            {
                return true;
            }
        }
        return false;
    }

    static Student GetStudent(List<Student> students, string firstName, string lastName)
    {
        foreach (Student student in students)
        {
            if (student.FirstName == firstName && student.LastName == lastName)
            {
                return student;
            }
        }
        return null;
    }
}

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string HomeTown { get; set; }
    public void Info()
    {
        Console.WriteLine($"{FirstName} {LastName} is {Age} years old.");
    }
}
