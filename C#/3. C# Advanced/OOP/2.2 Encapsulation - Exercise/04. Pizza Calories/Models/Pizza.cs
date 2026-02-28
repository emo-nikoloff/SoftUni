namespace PizzaCalories.Models;

public class Pizza
{
    private string name;
    private readonly List<Topping> toppings;

    public Pizza(string name)
    {
        Name = name;
        toppings = new();
    }

    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }
    public Dough Dough { get; set; }
    public double Calories
    {
        get
        {
            return toppings.Sum(t => t.Calories) + Dough.Calories;
        }
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{Name} - {Calories:f2} Calories.";
    }
}
