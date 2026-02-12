using System;

namespace DefiningClasses;

public class CreatingConstructors
{
    static void Main(string[] args)
    {
        Person firstPerson = new();
        Person secondPerson = new(18);
        Person thirdPerson = new("Jose", 43);
    }
}
