using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IAnimal> animals = new();

        string animalInput;

        while ((animalInput = Console.ReadLine()) != "End")
        {
            IAnimal animal = CreateAnimal(animalInput);

            string foodInput = Console.ReadLine();
            IFood food = CreateFood(foodInput);

            Console.WriteLine(animal.AskForFood());

            try
            {
                animal.Eat(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            animals.Add(animal);
        }

        animals.ForEach(Console.WriteLine);
    }

    private static IAnimal CreateAnimal(string input)
    {
        string[] inputInfo = input.Split();

        switch (inputInfo[0])
        {
            case nameof(Owl):
                return new Owl(inputInfo[1], double.Parse(inputInfo[2]), double.Parse(inputInfo[3]));
            case nameof(Hen):
                return new Hen(inputInfo[1], double.Parse(inputInfo[2]), double.Parse(inputInfo[3]));
            case nameof(Mouse):
                return new Mouse(inputInfo[1], double.Parse(inputInfo[2]), inputInfo[3]);
            case nameof(Dog):
                return new Dog(inputInfo[1], double.Parse(inputInfo[2]), inputInfo[3]);
            case nameof(Cat):
                return new Cat(inputInfo[1], double.Parse(inputInfo[2]), inputInfo[3], inputInfo[4]);
            case nameof(Tiger):
                return new Tiger(inputInfo[1], double.Parse(inputInfo[2]), inputInfo[3], inputInfo[4]);
            default:
                return null;
        }
    }

    private static IFood CreateFood(string input)
    {
        string[] inputInfo = input.Split();

        switch (inputInfo[0])
        {
            case nameof(Vegetable):
                return new Vegetable(int.Parse(inputInfo[1]));
            case nameof(Fruit):
                return new Fruit(int.Parse(inputInfo[1]));
            case nameof(Meat):
                return new Meat(int.Parse(inputInfo[1]));
            case nameof(Seeds):
                return new Seeds(int.Parse(inputInfo[1]));
            default:
                return null;
        }
    }
}
