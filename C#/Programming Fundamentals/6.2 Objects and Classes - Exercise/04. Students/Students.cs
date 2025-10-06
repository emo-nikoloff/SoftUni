/*Create a program that sorts some students by their grade in descending order. Each student should have:
· First name (string)
· Last name (string)
· Grade (a floating-point number)
· On the first line, you will receive a number n - the count of all students.
· On the next n lines, you will be receiving information about these students in the following format: "{first name} {second name} {grade}".
· Print out the information about each student in the following format: "{first name} {second name}: {grade}".*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students;

class Program
{
    static void Main(string[] args)
    {
        int studentsCount = int.Parse(Console.ReadLine());
        List<Student> students = new();

        for (int i = 1; i <= studentsCount; i++)
        {
            string[] studentInfo = Console.ReadLine().Split();
            string studentFirstName = studentInfo[0];
            string studentLastName = studentInfo[1];
            double studentGrade = double.Parse(studentInfo[2]);

            Student student = new(studentFirstName, studentLastName, studentGrade);

            students.Add(student);
        }

        List<Student> sortedStudents = students.OrderByDescending(student => student.Grade).ToList();

        Console.WriteLine(string.Join("\n", sortedStudents));
    }
}

class Student
{
    public Student(string firstName, string lastName, double grade)
    {
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Grade { get; set; }
    public override string ToString()
    {
        return $"{FirstName} {LastName}: {Grade:f2}";
    }
}
