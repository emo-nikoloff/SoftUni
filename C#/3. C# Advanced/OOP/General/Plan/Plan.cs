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
        people.Add(employee); // позволява да се добави обекта от съответния клас, защото е наследник на Person

        Manager manager = new("Рожда", "Джебел", "Технополис", "компютри");
        people.Add(manager);

        Student student = new("Росица", "Силистра", "ПМГ");
        people.Add(student);

        foreach (Person human in people)
        {
            Console.WriteLine(human.Info());
        }
        Console.WriteLine("<--------Енкапсулация-------->"); // дава възможност да заобиколим цялостната имплементация, логика и данни в един малък елемент или клас, който ни дава всичко нужно,
                                                             // за да го ползваме <=> дава възможност да скрием всякакъв вид логика, която не смятаме, че външния свят има нужда да гледа; дава
                                                             // възможност да сме гъвкави и кода да бъде по изчистен - намаля сложността на кода(става по-четим); можем да променяме вътрешността
                                                             // на класа без да променяме останалия код; дава възможност да валидираме данните, което дава гаранция, че класът винаги ще бъде в
                                                             // правилно състояние
        List<Animal> animals = new();

        Cat cat = null;
        try
        {
            cat = new("Yamal", "Black");
            animals.Add(cat);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }

        cat.BornKid("Hasan");

        Console.WriteLine($"Децата на {cat.Name}:");
        foreach (string kid in cat.Kids)
        {
            Console.WriteLine(kid);
        }

        Console.WriteLine("<--------Интерфейси и абстракция-------->"); // абстракция - да вземем от даден обект тези свойства, качества и функции, които са релевантни за проекта, който
                                                                        // разработваме, и да игнорираме останалите, които не са релевантни; позволява ни да се фокусираме върху това какво обектът
                                                                        // прави, а не как го прави - какви неща има дадения обект, които са релевантни за нашия проект, но не се интересува от
                                                                        // конкретната дефиниция;
                                                                        // Пример: Имаме стол. Ако го продаваме в магазин за мебели, ще имаме качества на стола, които ни вълнуват за мебел -
                                                                        // цвят, материал, цена, снимка(ако е онлайн магазин), промоция, описание, производител. Ако имаме стол в завод за мебели,
                                                                        // ще имаме отделните части, схема на сглобяване, пакетиране, дали е в кашон, какъв материал е, цена на производство, цена
                                                                        // за труд. Ако имаме стол в ресторант, ще имаме локация, на коя маса е, чист ли е, свободен ли е
                                                                        // интерфейс - дефинирам какво съдържа класът, но не казвам как се имплементира
        List<IVehicle> vehicles = new() { new Car("BMW", 480), new Bicycle("VITUS", 120) };

        foreach (IVehicle vehicle in vehicles)
        {
            vehicle.Move();
            vehicle.Stop();
        }

        Console.WriteLine("----------------");

        List<Shape> shapes = new() { new Rectangle("Правоъгълник", 5, 4), new Circle("Кръг", 3) };

        foreach (Shape shape in shapes)
        {
            shape.ShowName();
            Console.WriteLine($"Лице = {shape.GetArea()}");
        }
    }
}

// Наследяване:
internal class Person // superclass - родител - предава всичките си членове на наследника; ключовата дума internal означава, че класът работи само в съответния проект(namespace); може да се
                      // използва и при обозначаване на методи - класовете по подразбиране са internal
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

class Employee : Person // subclass - дете - наследява всички членове от родителския клас; може да достъпи само public и protected членовете; може да наследява само един клас
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

// Енкапсулация:

class Animal
{
    private string name; // поле - винаги private

    public Animal(string name)
    {
        Name = name;
    }

    public string Name // пропърти - винаги public - служат за достъпване на полетата
    {
        get
        {
            return name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid name!");
            }
            name = value;
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name} - {Name}";
    }
}

class Cat : Animal
{
    private string[] validColors = { "Black", "White", "Gray", "Mixed" };
    private string color;
    private List<string> kids;

    public Cat(string name, string color) : base(name)
    {
        Color = color;
        kids = new();
    }

    public string Color
    {
        get
        {
            return color;
        }
        private set
        {
            if (!validColors.Contains(value))
            {
                throw new ArgumentException($"Грешен цвят за котка! Валидните цветове са: {string.Join(", ", validColors)}");
            }

            color = value;
        }
    }

    public IReadOnlyCollection<string> Kids // понеже колекцията е mutable тя не е енкапсулирана напълно - не мога да променям Kids, но мога да достъпвам обектите в
                                            // колекцията;
                                            // mutable = changeable - използват същата памет (Примери: StringBuilder, List);
                                            // immutable = unchangeable (read-only) - създават нова памет всеки път, когато бъдат модифицирани (Примери: string, Tuples)
                                            // => в такъв случай се използва IReadOnlyCollection
    {
        get
        {
            return kids;
        }
    }

    public void BornKid(string name)
    {
        kids.Add(name);
    }

    public override string ToString()
    {
        return $"{base.ToString()} is {Color}";
    }
}

// Интерфейси и абстракция:
interface IVehicle // прието е имената на интерфейсите да започват с I; дефинира какво искаме да имаме; описва какво може да прави един клас - няма логика; клас може да имплементира по няколко
                   // интерфейса; интерфейс може да наследява по няколко интерфейса
{
    string Name { get; }
    int Speed { get; }

    void Move();
    void Stop();
}

class Car : IVehicle
{
    public Car(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public string Name { get; }
    public int Speed { get; }

    public void Move()
    {
        Console.WriteLine($"{Name} кара със скорост {Speed}km/h.");
    }

    public void Stop()
    {
        Console.WriteLine($"{Name} спря.");
    }
}

class Bicycle : IVehicle
{
    public Bicycle(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public string Name { get; }
    public int Speed { get; }

    public void Move()
    {
        Console.WriteLine($"{Name} кара със скорост {Speed}km/h.");
    }

    public void Stop()
    {
        Console.WriteLine($"{Name} спря.");
    }
}

abstract class Shape // може да има конкретики; описва какво представлява един клас
{
    protected Shape(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public abstract double GetArea(); // абстрактен метод

    public void ShowName() // обикновен метод
    {
        Console.WriteLine($"Фигура: {Name}");
    }
}

class Rectangle : Shape
{
    public Rectangle(string name, double width, double height)
        : base(name)
    {
        Width = width;
        Height = height;
    }

    public double Width { get; }
    public double Height { get; }

    public override double GetArea()
    {
        return Width * Height;
    }
}

class Circle : Shape
{
    public Circle(string name, double radius)
        : base(name)
    {
        Radius = radius;
    }

    public double Radius { get; }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}