using System;

namespace DefiningClasses;

public class Family
{
    private List<Person> members;

    public Family()
    {
        members = new();
    }

    public List<Person> Members
    {
        get => members;
    }

    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public Person GetOldestMember()
    {
        int oldestAge = int.MinValue;
        Person oldestPerson = null;
        foreach (Person member in members)
        {
            if (member.Age > oldestAge)
            {
                oldestAge = member.Age;
                oldestPerson = member;
            }
        }
        return oldestPerson;
    }
}
