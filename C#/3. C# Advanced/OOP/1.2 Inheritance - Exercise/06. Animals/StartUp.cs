using Animals.Models;
using Animals.Models.Animals;
using Animals.Models.Animals.Cats;

namespace Animals;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Animal> animals = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Beast!")
        {
            string animalType = input;
            string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = animalInfo[0];
            int age = int.Parse(animalInfo[1]);
            string gender = animalInfo[2];

            try
            {
                Animal animal = null;

                switch (animalType)
                {
                    case "Dog":
                        animal = new Dog(name, age, gender);
                        break;
                    case "Frog":
                        animal = new Frog(name, age, gender);
                        break;
                    case "Cat":
                        animal = new Cat(name, age, gender);
                        break;
                    case "Kitten":
                        animal = new Kitten(name, age);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(name, age);
                        break;
                }

                animals.Add(animal);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        animals.ForEach(Console.WriteLine);
    }
}
