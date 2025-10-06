/*Help planning the next Programming Fundamentals course by keeping track of the lessons that will be included in the course, as well as all the exercises for the lessons. On the first input line, you
will receive the initial schedule of lessons and exercises that are going to be part of the next course, separated by a comma and a space ", ". Before the course starts, there are some changes to be
made. Until you receive the "course start" command, you will be given some commands to modify the course schedule.
The possible commands are:
· Add:{lessonTitle} – add the lesson to the end of the schedule, if it does not exist.
· Insert:{lessonTitle}:{index} – insert the lesson to the given index, if it does not exist.
· Remove:{lessonTitle} – remove the lesson, if it exists.
· Swap:{lessonTitle}:{lessonTitle} – swap the position of the two lessons, if they exist.
Exercise:{lessonTitle} – add Exercise in the schedule right after the lesson index, if the lesson exists and there is no exercise already, in the following format "{lessonTitle}-Exercise". If the
lesson doesn`t exist, add the lesson at the end of the course schedule, followed by the Exercise.
Note: Each time you Swap or Remove a lesson, you should do the same with the Exercises, if there are any following the lessons.
· First line – the initial schedule lessons – strings, separated by comma and space ", ".
· Until "course start" you will receive commands in the format described above.
· Print the whole course schedule, each lesson on a new line with its number (index) in the schedule: "{lesson index}.{lessonTitle}".
· Allowed working time / memory: 100ms / 16MB.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning;

class Program
{
    static void Main()
    {
        List<string> schedule = Console.ReadLine().Split(", ").ToList();

        string commands;
        while ((commands = Console.ReadLine()) != "course start")
        {
            string[] arguments = commands.Split(":");
            switch (arguments[0])
            {
                case "Add":
                    schedule = AddTitle(schedule, arguments[1]);
                    break;
                case "Insert":
                    schedule = InsertTitle(schedule, arguments[1], int.Parse(arguments[2]));
                    break;
                case "Remove":
                    schedule = RemoveTitle(schedule, arguments[1]);
                    break;
                case "Swap":
                    schedule = SwapTitles(schedule, arguments[1], arguments[2]);
                    break;
                case "Exercise":
                    schedule = InsertExercises(schedule, arguments[1]);
                    break;
            }
        }

        PrintSchedule(schedule);
    }

    static List<string> AddTitle(List<string> schedule, string title)
    {
        if (!schedule.Contains(title))
        {
            schedule.Add(title);
        }

        return schedule;
    }

    static List<string> RemoveTitle(List<string> schedule, string title)
    {
        schedule.Remove(title);

        string exerciseTitle = $"{title}-Exercise";
        int index = schedule.FindIndex(x => x == exerciseTitle);
        if (index >= 0)
        {
            RemoveTitle(schedule, exerciseTitle);
        }

        return schedule;
    }

    static List<string> SwapTitles(List<string> schedule, string firstTitle, string secondTitle)
    {
        if (schedule.Contains(firstTitle) && schedule.Contains(secondTitle))
        {
            int firstIndex = schedule.FindIndex(x => x == firstTitle);
            int secondIndex = schedule.FindIndex(x => x == secondTitle);

            string temp = schedule[firstIndex];
            schedule[firstIndex] = schedule[secondIndex];
            schedule[secondIndex] = temp;

            schedule = SwapExercises(schedule, firstTitle, secondIndex);
            schedule = SwapExercises(schedule, secondTitle, firstIndex);
        }

        return schedule;
    }

    static List<string> InsertTitle(List<string> schedule, string title, int index)
    {
        if (!schedule.Contains(title))
        {
            schedule.Insert(index, title);
        }

        return schedule;
    }

    static List<string> SwapExercises(List<string> schedule, string title, int titleIndex)
    {
        string exerciseTitle = $"{title}-Exercise";
        int index = schedule.FindIndex(x => x == exerciseTitle);
        if (index >= 0)
        {
            RemoveTitle(schedule, exerciseTitle);
            InsertTitle(schedule, exerciseTitle, titleIndex + 1);
        }

        return schedule;
    }

    static List<string> InsertExercises(List<string> schedule, string title)
    {
        string exerciseTitle = $"{title}-Exercise";
        if (!schedule.Contains(title))
        {
            AddTitle(schedule, title);
        }

        if (schedule.Contains(title) && !schedule.Contains(exerciseTitle))
        {
            int index = schedule.FindIndex(x => x == title);
            InsertTitle(schedule, exerciseTitle, index + 1);
        }

        return schedule;
    }

    static void PrintSchedule(List<string> schedule)
    {
        for (int i = 0; i < schedule.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{schedule[i]}");
        }
    }
}
