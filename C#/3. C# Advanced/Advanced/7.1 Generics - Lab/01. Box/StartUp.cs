/*Create a class Box<> that can store anything. It should have two public methods:
· void Add(element) – adds an element on the top of the list.
· element Remove() – removes the topmost element.
· int Count { get; }*/
namespace BoxOfT;

public class StartUp
{
    static void Main(string[] args)
    {
        Box<int> box = new();

        box.Add(1);
        box.Add(2);
        box.Add(3);

        Console.WriteLine(box.Remove());

        box.Add(4);
        box.Add(5);

        Console.WriteLine(box.Remove());
    }
}
