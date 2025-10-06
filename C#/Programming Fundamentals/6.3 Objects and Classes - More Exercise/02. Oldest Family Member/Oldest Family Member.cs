/*Create two classes – Family and Person. The Person class should have Name and Age properties. The Family class should have a list of people, a method for adding members
(void AddMember(Person member)), and a method, which returns the oldest family member (Person GetOldestMember()). Write a program that reads the names and ages of N people and adds them to the family. Then print the name and age of the oldest member.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member;

class Program
{
    static void Main(string[] args)
    {
        int peopleNumber = int.Parse(Console.ReadLine());
        Family family = new();

        for (int i = 1; i <= peopleNumber; i++)
        {
            string[] personInfo = Console.ReadLine().Split();
            string personName = personInfo[0];
            int personAge = int.Parse(personInfo[1]);

            Person person = new(personName, personAge);
            family.AddMember(person);
        }

        string oldestPerson = family.GetOldestMember();
        Console.WriteLine(oldestPerson);
    }
}

class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}

class Family
{
    public Family()
    {
        People = new();
    }

    public List<Person> People { get; set; }

    public void AddMember(Person member)
    {
        People.Add(member);
    }

    public string GetOldestMember()
    {
        return People.OrderByDescending(p => p.Age).First().ToString();
    }
}
