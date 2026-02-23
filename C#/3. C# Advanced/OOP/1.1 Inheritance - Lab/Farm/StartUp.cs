namespace Farm;

public class StartUp
{
    static void Main(string[] args)
    {
        Dog dog = new();
        dog.Eat();
        dog.Bark();

        Puppy puppy = new();
        puppy.Eat();
        puppy.Bark();
        puppy.Weep();

        Cat cat = new();
        cat.Eat();
        cat.Meow();
    }
}
