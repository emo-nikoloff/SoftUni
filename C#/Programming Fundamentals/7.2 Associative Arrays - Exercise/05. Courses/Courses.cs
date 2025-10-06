/*Create a program that keeps the information about courses. Each course has a name and registered students.
You will be receiving a course name and a student name, until you receive the command "end". Check if such a course already exists, and if not, add the course. Register the user into the course
When you receive the command "end", print the courses with their names and total registered users. For each contest print the registered users.
· Until the "end" command is received, you will be receiving input in the format: "{courseName} : {studentName}".
· The product data is always delimited by " : ".
· Print the information about each course in the following the format: "{courseName}: {registeredStudents}"
· Print the information about each student in the following the format: "-- {studentName}"*/
using System;
using System.Collections.Generic;

namespace _05._Courses;

class Program
{
    static void Main(string[] args)
    {
        string input;
        Dictionary<string, Course> coursesParticipants = new();

        while ((input = Console.ReadLine()) != "end")
        {
            string[] courseInfo = input.Split(" : ");

            string courseName = courseInfo[0];
            string studentName = courseInfo[1];

            if (!coursesParticipants.ContainsKey(courseName))
            {
                coursesParticipants.Add(courseName, new(courseName));
            }

            coursesParticipants[courseName].Students.Add(studentName);
        }

        foreach ((string name, Course course) in coursesParticipants)
        {
            Console.WriteLine($"{name}: {course.Students.Count}");
            foreach (string student in course.Students)
            {
                Console.WriteLine($"-- {student}");
            }
        }
    }
}

class Course
{
    public Course(string name)
    {
        CourseName = name;
        Students = new();
    }

    public string CourseName { get; set; }
    public List<string> Students { get; set; }
}