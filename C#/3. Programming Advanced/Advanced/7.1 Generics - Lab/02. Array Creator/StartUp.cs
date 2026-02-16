/*Create a class ArrayCreator with a method and a single overload to it
· static T[] Create(int length, T item).
The method should return an array with the given length and every element should be set to the given default item.*/
namespace GenericArrayCreator;

public class Program
{
    static void Main(string[] args)
    {
        string[] strings = ArrayCreator.Create(5, "Pesho");
        int[] integers = ArrayCreator.Create(10, 33);
    }
}
