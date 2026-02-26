namespace Plan;

class Plan
{
    static void Main(string[] args)
    {
        Console.WriteLine("<--------Наследяване-------->");
        List<Person> people = new();

        Person person = new("Гошо", "София");
        people.Add(person);

        Employee employee = new("Страхил", "Сърбогъзи", "SAP");
        people.Add(employee); // позволява ми да добавя обекта от съответния клас, защото е наследник на Person

        Manager manager = new("Рожда", "Джебел", "Технополис", "компютри");
        people.Add(manager);

        Student student = new("Росица", "Силистра", "ПМГ");
        people.Add(student);

        foreach (Person human in people)
        {
            Console.WriteLine(human.Info());
        }
    }
}

// Наследяване:
internal class Person // superclass - родител - предава всичките си членове на наследника; ключовата дума internal означава, че класът работи само в съответния проект; може да се използва и при 
                      // обозначаване на методи
{
    public Person(string name, string address) // когато конструктора е с параметри, задължително се използва
    {
        Name = name;
        Address = address;
    }

    public string Name { get; set; }
    public string Address { get; set; }

    public virtual string Info() // методът може да бъде презаписан
    {
        return $"Казвам се {Name} и живея в {Address}.";
    }
}

class Employee : Person // subclass - дете - наследява всички членове от родителския клас; може да достъпи само public и protected членовете
{
    public Employee(string name, string address, string company)
        : base(name, address) // конструктора вика базовия конструктор и му подава нужните параметри
    {
        Company = company;
    }

    public string Company { get; set; }

    public override string Info() // презаписване на метода от родителския клас
    {
        return $"{base.Info()} Работя в {Company}.";
    }
}

class Manager : Employee // наследява всичко от Employee, който наследява всичко от Person 
{
    public Manager(string name, string address, string company, string department)
        : base(name, address, company)
    {
        Department = department;
    }

    public string Department { get; set; }

    public override sealed string Info() // ключовата дума sealed означава, че методът не може да бъде променян от следващи наследници на съответния клас; може да се използва и при обозначаване
                                         // на клас
    {
        return $"{base.Info()} Отделът е \"{Department}\".";
    }
}

class Student : Person
{
    public Student(string name, string address, string school)
        : base(name, address)
    {
        School = school;
    }

    public string School { get; set; }

    public override string Info()
    {
        return $"{base.Info()} Уча в {School}.";
    }
}
