/*Define a class called Student, which will hold the following information about some students:
· first name
· last name
· age
· home town
Read information about some students, until you receive the "end" command. After that, you will receive a city name.
Print the students who are from the given city in the following format: "{firstName} {lastName} is {age} years old."*/
using System;
using System.Collections.Generic;

namespace _04._Students;

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

            students.Add(student);
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
