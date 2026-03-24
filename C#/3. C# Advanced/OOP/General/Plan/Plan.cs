using System.Reflection;

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

        cat.BirthKid("Hasan");

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

        Console.WriteLine("--------------------------------");

        List<Shape> shapes = new() { new Rectangle("Правоъгълник", 5, 4), new Circle("Кръг", 3) };

        foreach (Shape shape in shapes)
        {
            shape.ShowName();
            Console.WriteLine($"Лице = {shape.GetArea()}");
        }

        Console.WriteLine("<--------Полиморфизъм-------->"); // много форми - различно поведение, различен вид действие в зависимост от контекста
        Payment firstPayment = new CreditCardPayment(); // променливата е Payment, но обекта е различен, затова се изпълнява различна версия на Pay() - (Тип данни на променливата) ... =
                                                        // = new(Тип данни, който се използва) - Runtime полиморфизъм - method overriding
        Payment secondPayment = new CashPayment();
        Payment thirdPayment = new PayPalPayment();

        firstPayment.Pay(100);
        secondPayment.Pay(50);
        thirdPayment.Pay(75);

        Console.WriteLine("--------------------------------");

        if (firstPayment is CreditCardPayment cardPayment) // ключовата дума is проверява дали даден обект е инстанция на специфичен клас
        {
            cardPayment.ValidateCard();
        }

        for (int i = 1; i <= 7; i++)
        {
            if (i is 6 or 7) // is играе ролята на ==
            {
                Console.Write($"{i} ");
            }
        }

        Console.WriteLine("\n--------------------------------");

        IEnumerable<int> numbers = Enumerable.Range(10, 40);
        Console.WriteLine($"Колекция: {string.Join(", ", numbers)}");

        IEnumerable<int> filtered = numbers.Where(x => x % 7 is var remainder && remainder >= 2 && remainder <= 4); // присвояваме резултата в променливата remainder и извършваме желаните
                                                                                                                    // операции с нея
        Console.WriteLine($"Числата, които се делят на 7 с остатък [2..4]: {string.Join(", ", filtered)}");

        Console.WriteLine("--------------------------------");

        PayPalPayment paypal = thirdPayment as PayPalPayment; // превърни ми(cast) променливата в PayPalPayment

        if (paypal != null)
        {
            paypal.SendConfirmationEmail();
        }
        else
        {
            Console.WriteLine("Обектът не е PayPalPayment.");
        }

        Console.WriteLine("--------------------------------");

        int firstResult = Multiply(3, 4);
        double secondResult = Multiply(2.5, 3.5);

        Console.WriteLine($"3 * 4 = {firstResult}");
        Console.WriteLine($"2.5 * 3.5 = {secondResult}");

        Console.WriteLine("<--------SOLID принципи-------->");
        Console.WriteLine("------Single Responsibility------");
        // -> Всеки клас, метод, променлива и други да имат една единствена отговорност и една единствена причина да се променят; Strong Cohesion - функционалностите са много навързани един към
        // друг; Coupling - колко е навързан даден клас или метод с друг клас или метод. Колкото по-навързани са нещата, толкова по-голям е проблема да се развържат. => Loose Coupling - стремим
        // се да не сме толкова навързани и отделните класове или методи да са по-разкачени - по-добро четене на кода, по-добър системен дизайн; За да постигнем Strong Cohesion и Loose Coupling -
        // 1. инстанцираме малко на брой класове и променливи в даден клас, 2. всеки метод на даден клас да манипулира най-малка част от тези променливи, 3. два отделни модула с класове си
        // споделят възможно най-малко информация - така са по-разкачени и има по-голяма възможност за промяна, 4. да използваме абстракция, 5. максимално много reusability

        Console.WriteLine("------Open/Closed------");
        // -> Всички парчета от кода - класове, модули, функции трябва да бъдат отворени за разширяване, но затворени за модификация - добавянето на нова функционалност или логика да не изисква
        // промени върху съществуващ код. Ще можем да преизползваме парчета от нашата система, защото ще имаме по-голяма модулярност; За да постигнем всичко това - 1. използваме параметри, за да
        // променяме функционалността, 2. да разчитаме на абстракция, а не на конкретни класове - можем лесно да вмъкнем друг вид имплементация, 3. Strategy Pattern - вършим работа без да
        // променяме текущия код, променяме само какво подаваме на класа - Plug in model - даваме нова имплементация чрез интерфейс, 4. Template Method Pattern - един абстрактен клас, който
        // дефинира стъпките какво да се случва и след това наследниците определят как да се случват нещата; Кога да приложим - на база опита на проекта(колко често се променя) - когато бизнесът
        // или проблемът, който се решава от приложението, има голям шанс да прави промяна -> ако не сме сигурни, че ще се променя често - имплементираме възможно най-елементарния начин
        // (да стане бързо и да работи) и в последствие започнат да се променят нещата често, тогава рефакторираме да се спазва Open/Closed и правим тест дали все още логиката работи както трябва
        // -> TANSTAAFL(There Ain't No Such Thing As A Free Lunch) - добавя неизбежна комплексност към кода и дизайна на системата
        // *Няма как да имаме система затворена на 100% за промени*

        Console.WriteLine("------Liskov Substitution------");
        // -> Наследниците трябва да могат да заместват базовите класове - наследникът не трябва да променя функционалност на базовия клас, а само да добавя

        Console.WriteLine("------Interface Segregation------");
        // -> Да не правим твърде големи интерфейси - да ги намаляме, колкото се може повече - да бъдат малки и с ясна цел; "Дебелите" интерфейси се "раздробяват"

        Console.WriteLine("------Dependency Inversion------");
        // -> Всяко приложение съдържа класове, модули, методи и др., а те съдържат депендънсита(зависимости) - всякакви външни компоненти, които системата използва. Видове Dependency Inversion -
        // Constructor Injection: **най-препоръчително**
        // + класът не може да бъде създаден без да има валидните неща, които да му подадем - има нужда от абстракциите, за да работи
        // + не трябва да се занимава с валидация дали всички депендънсита са дадени
        // - твърде много депендънсита и параметри
        // - част от депендънситата са ненужни
        // Property Injection:
        // + функционалността може да бъде променена по всяко време
        // + прави кода по-гъвкав
        // - пропъртито може да е невалидно
        // - сам се досещаш какво трябва да правиш
        // Parameter Injection:
        // + методът казва от какво има нужда
        // - твърде много параметри
        // - методът вместо да разчита на данни - разчита на депендънсита

        Console.WriteLine("<--------Рефлексия и атрибути-------->"); // Мета програмиране - начин на кода да анализира себе си - програмна техника, с която програмите могат да разглеждат други
        // програми или самите себе си като данни. Програмите могат да бъдат за четене, генериране, анализиране, трансформиране и модифициране на самата програма, докато работи

        Console.WriteLine("------Рефлексия------"); // Рефлексия - възможността на език да разглежда себе си какво дава в самата програма; Кога да използваме - 1. когато искаме да имаме код,
                                                    // който е гъвкав - готова програма и в нея подпъхваме други програми, и програмата може да ги достъпва, 2. да намалим кода, 3. да
                                                    // инициализираме обекти динамично(без да им знаем типа), 4. да вадим информация за компилирания код, 5. да анализираме други програми; Кога да
                                                    // НЕ използваме - когато е възможно да се направи нещо без рефлексия е препоръчително тя да не се използва; Недостатъци на рефлексия - бавна
                                                    // като производителност, проблеми със сигурността, достъп до всеки един компонент на кода независимо дали е private, internal и т.н.,
                                                    // алгоритмите са гъвкави и е възможно нещо да се счупи, защото не работят с конкретика
        Type catType = typeof(Cat); // дава информация за класа по време на компилиране на кода
        Console.WriteLine(catType.FullName);

        catType = Type.GetType("Plan.Cat"); // дава информация за класа по време на изпълнение кода; за да се достъпи типът
        Console.WriteLine(catType.FullName);

        Console.WriteLine(cat.GetType());

        Console.WriteLine(catType.BaseType);

        Console.WriteLine("--------------------------------");

        var newCat = Activator.CreateInstance(catType, "Yordan", "Mixed"); // създаваме инстанция без да използваме конструктора директно - създаваме инстанция "в движение" на типове данни,
                                                                           // като не е задължително да знаем имената им; ако не направим cast се създава обект, но не се знае от какъв тип
        Console.WriteLine(newCat);

        Console.WriteLine("--------------------------------");

        Type newCatType = newCat.GetType();
        FieldInfo[] allFields = newCatType.GetFields(BindingFlags.Static |
                                                    BindingFlags.Instance |
                                                    BindingFlags.Public |
                                                    BindingFlags.NonPublic); // ако методът няма зададени параметри, връща всички публични полета
        Console.WriteLine($"Полетата на обекта {newCatType.Name}:");
        foreach (FieldInfo field in allFields)
        {
            Console.WriteLine(field);

            if (field.Name == "color")
            {
                field.SetValue(newCat, "Black");
            }
        }

        PropertyInfo[] allProperties = newCatType.GetProperties();
        Console.WriteLine($"\nПропъртитата на обекта {newCatType.Name}:");
        foreach (PropertyInfo property in allProperties)
        {
            Console.WriteLine(property);

            MethodInfo getter = property.GetGetMethod();
            MethodInfo setter = property.GetSetMethod(true);

            Console.WriteLine($"-> Protected getter - {getter.IsFamily}");

            if (setter != null)
            {
                Console.WriteLine($"-> Protected setter - {setter.IsFamily}");
            }
            else
            {
                Console.WriteLine("-> Protected setter - No setter found");
            }
        }

        Console.WriteLine("--------------------------------");

        ConstructorInfo[] constructors = newCatType.GetConstructors();

        Console.WriteLine($"Конструкторите на обекта {newCatType.Name}:");
        foreach (ConstructorInfo constructor in constructors)
        {
            ParameterInfo[] parameters = constructor.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                Console.WriteLine($"{parameter.Name} - {parameter.ParameterType}");
            }
        }

        Console.WriteLine();

        ConstructorInfo catConstructor = newCatType.GetConstructor(new Type[] { typeof(string), typeof(string) });
        var catFromConstructor = (Cat)catConstructor.Invoke(new object[] { "Aladin", "Mixed" });
        Console.WriteLine(catFromConstructor.Name);

        Console.WriteLine("--------------------------------");

        MethodInfo[] methods = newCatType.GetMethods();

        Console.WriteLine($"Методите на обекта {newCatType.Name}:");
        foreach (MethodInfo method in methods)
        {
            Console.WriteLine(method.Name);
        }

        Console.WriteLine("------Атрибути------"); // Не променят логиката на кода - изцяло създадени за рефлексия и логика, която работи с рефлексия; Допълнителна информация, която слагаме върху
                                                   // кода без тя да прави нещо специфично - може да се слага на класове, методи, полета и др.; Маркираме даден елемент от класа, за да може друга
                                                   // програма, която прави рефлексия да работи с него; Можем да създаваме собствени атрибути
        Type[] types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (Type type in types)
        {
            AuthorAttribute authorAttribute = type.GetCustomAttribute<AuthorAttribute>();
            if (authorAttribute != null)
            {
                Console.WriteLine($"{type.Name} - написан от {authorAttribute.Name}");
            }
        }
    }

    // Compile-time полиморфизъм - method overloading
    static int Multiply(int a, int b) => a * b;
    static double Multiply(double a, double b) => a * b;
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
[Author(Name = "Emiliyan")] // line 860
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
        protected set
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

[Author(Name = "Emiliyan")] // line 860
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

    public void BirthKid(string name)
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

// Полиморфизъм:
abstract class Payment
{
    public abstract void Pay(decimal amount);
}

class CreditCardPayment : Payment
{
    public void ValidateCard()
    {
        Console.WriteLine("Картата е валидирана успешно.");
    }

    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Платени {amount} евро с кредитна карта.");
    }
}

class CashPayment : Payment
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Платени {amount} евро в брой.");
    }
}

class PayPalPayment : Payment
{
    public void SendConfirmationEmail()
    {
        Console.WriteLine("Изпратен е имейл за потвърждение на плащането.");
    }

    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Платени {amount} евро чрез PayPal.");
    }
}

// SOLID принципи:
// -> Single Responsibility
class Engine
{
    // public static void DoEverything()
    // {
    //     var report = GenerateReport();
    //     PrintReport(report);
    //     SendReport(report, "mc@emo.com");
    // }

    // public static object GenerateReport()
    // {
    //     throw new NotImplementedException();
    // }                                                            => не покрива Single Responsibility - класът изпълнява много неща - Spaghetti Code

    // public static void PrintReport(object report)
    // {
    //     throw new NotImplementedException();
    // }

    // public static void SendReport(object report, string email)
    // {
    //     throw new NotImplementedException();
    // }

    static void CompleteReport() // така класът служи като координатор на другите класове - всяко отделно парче си има собствена функционалност
    {
        var generator = new ReportGenerator();
        var printer = new Printer();
        var mailSender = new MailSender();

        var report = generator.GenerateReport();
        printer.PrintReport(report);
        mailSender.SendReport(report, "mc@emo.com");
    }
}

class ReportGenerator
{
    public object GenerateReport()
    {
        throw new NotImplementedException();
    }
}

class Printer
{
    public void PrintReport(object report)
    {
        throw new NotImplementedException();
    }
}

class MailSender
{
    public void SendReport(object report, string email)
    {
        throw new NotImplementedException();
    }
}

// -> Open/Closed
// => Strategy Pattern
interface IPromotion
{
    double GetDiscount();
}

class FreeShippingPromotion : IPromotion
{
    public double GetDiscount()
    {
        return 10.00;
    }
}

class TwentyPercentOffPromotion : IPromotion
{
    private double totalProductPrice;

    public TwentyPercentOffPromotion(double totalProductPrice)
    {
        this.totalProductPrice = totalProductPrice;
    }

    public double GetDiscount()
    {
        return totalProductPrice * 0.2;
    }
}

class PromotionHandler
{
    public void HandlePromotions()
    {
        FreeShippingPromotion freeShippingPromotion = new();
        ShoppingCart shoppingCart = new(freeShippingPromotion);
    }
}

class ShoppingCart
{
    private IPromotion promotion;

    public ShoppingCart(IPromotion promotion) // Strategy Pattern - дава стратегии с различни класове
    {
        this.promotion = promotion;
    }

    public double CalculateFinalPrice()
    {
        // Sum of all products
        double totalSumOfProducts = 125.67;

        // Add shipping
        double shipping = 10.00;

        // Calculate promotions

        // string promoCode = "20OFF";

        // if (totalSumOfProducts > 100)
        // {
        //     shipping = 0;
        // }
        // else if (promoCode == "20OFF")       => не покрива Open/Closed - отворен е за разширение, но е отворен и за модификация(при всяко едно разширение модифицираме)
        // {
        //     totalSumOfProducts *= 0.8;
        // }
        // else if (promoCode == "50OFF")
        // {
        //     totalSumOfProducts *= 0.5;
        // }

        double discount = promotion.GetDiscount();

        return totalSumOfProducts + shipping - discount;
    }
}

// => Template Method Pattern
public abstract class CoffeeBrewer
{
    protected int CupSize { get; set; }
    protected int CoffeeShots { get; set; }
    protected int Sugar { get; set; }
    protected int Milk { get; set; }

    public void Brew()
    {
        PrepareMachine();
        GetCup();
        BrewCoffee();
        AddAdditionalProducts();
    }

    protected abstract void PrepareMachine();
    protected abstract void GetCup();
    protected abstract void BrewCoffee();
    protected abstract void AddAdditionalProducts();
}

class EspressoBrewer : CoffeeBrewer
{
    protected override void PrepareMachine()
    { }

    protected override void GetCup()
    {
        CupSize = 50;
    }

    protected override void BrewCoffee()
    {
        CoffeeShots = 1;
    }

    protected override void AddAdditionalProducts()
    {
        Sugar = 0;
    }
}

class CapuccinoBrewer : CoffeeBrewer
{
    protected override void PrepareMachine()
    { }

    protected override void GetCup()
    {
        CupSize = 100;
    }

    protected override void BrewCoffee()
    {
        CoffeeShots = 1;
    }

    protected override void AddAdditionalProducts()
    {
        Milk = 100;
    }
}

// -> Dependency Inversion
interface ICurrentTime
{
    DateTime Now { get; }
}

class CurrentTime : ICurrentTime
{
    public DateTime Now
    {
        get
        {
            return DateTime.Now;
        }
    }
}

class FakeCurrentTime : ICurrentTime
{
    public DateTime Now
    {
        get
        {
            return new DateTime(2025, 12, 15, 13, 15, 50);
        }
    }
}

class Greeter
{
    private ICurrentTime currentTime;

    public Greeter(ICurrentTime currentTime) // Constuctor Injection
    {
        this.currentTime = currentTime;
    }

    public ICurrentTime CurrentTime // Property Injection
    {
        set
        {
            currentTime = value;
        }
    }

    public void Greet() // ако в самия метод сложим ICurrentTime currentTime ще имаме Parameter Injection
    {
        DateTime timeNow = currentTime.Now;

        if (timeNow.Hour < 12)
        {
            Console.WriteLine("Good morning!");
        }
        else if (timeNow.Hour >= 19)
        {
            Console.WriteLine("Good evening!");
        }
        else
        {
            Console.WriteLine("Good afternoon!");
        }
    }
}

// Рефлексия и атрибути
// -> атрибути
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)] // атрибута може да бъде използван само върху класове и методи и атрибутите НЕ могат да бъдат много на
                                                                                          // брой
class AuthorAttribute : Attribute
{
    public string Name { get; set; }
}