/*You will receive an unknown number of lines. On each line you will receive an array with 3 elements:
· The first element is a string - the name of the person
· The second element a string - the ID of the person
· The third element is an integer - the age of the person
If you get a person whose ID you have already received before, update the name and age for that ID with that of the new person. When you receive the command "End", print all of the people, ordered
by age.*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age;

class Program
{
    static void Main(string[] args)
    {
        string input;
        List<Person> people = new();

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split();
            string personName = inputArgs[0];
            string personID = inputArgs[1];
            int personAge = int.Parse(inputArgs[2]);

            Person person = new(personName, personID, personAge);

            Person existingID = people.Find(p => p.ID == personID);
            if (existingID == null)
            {
                people.Add(person);
            }
            else
            {
                person.Name = personName;
                person.Age = personAge;
            }
        }

        List<Person> sortedPeople = people.OrderBy(p => p.Age).ToList();
        sortedPeople.ForEach(p => Console.WriteLine(p));
    }
}

class Person
{
    public Person(string name, string id, int age)
    {
        Name = name;
        ID = id;
        Age = age;
    }

    public string Name { get; set; }
    public string ID { get; set; }
    public int Age { get; set; }
    public override string ToString()
    {
        return $"{Name} with ID: {ID} is {Age} years old.";
    }
}
