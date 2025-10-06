/*Create a program that keeps the information about students and their grades.
You will receive n pair of rows. First, you will receive the student's name, after that, you will receive their grade. Check if the student already exists and if not, add him. Keep track of all
grades for each student.
When you finish reading the data, keep the students with an average grade higher than or equal to 4.50.
Print the students and their average grade in the following format:
"{name} –> {averageGrade}"
Format the average grade to the 2nd decimal place.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber = int.Parse(Console.ReadLine());
        Dictionary<string, Student> studentsGrades = new();

        for (int i = 1; i <= magicNumber; i++)
        {
            string studentName = Console.ReadLine();
            double studentGrade = double.Parse(Console.ReadLine());

            if (!studentsGrades.ContainsKey(studentName))
            {
                studentsGrades.Add(studentName, new(studentName));
            }

            studentsGrades[studentName].Grades.Add(studentGrade);
        }

        studentsGrades = studentsGrades.Where(grade => grade.Value.Grades.Average() >= 4.50).ToDictionary(student => student.Key, grade => grade.Value);
        foreach ((string name, Student student) in studentsGrades)
        {
            Console.WriteLine($"{name} -> {student.Grades.Average():f2}");
        }
    }
}

class Student
{
    public Student(string name)
    {
        Name = name;
        Grades = new();
    }

    public string Name { get; set; }
    public List<double> Grades { get; set; }
}
