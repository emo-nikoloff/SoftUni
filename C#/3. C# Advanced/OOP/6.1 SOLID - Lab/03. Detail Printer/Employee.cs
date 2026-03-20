namespace DetailPrinter;

public class Employee
{
    public Employee(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public virtual string Info()
    {
        return Name;
    }
}

