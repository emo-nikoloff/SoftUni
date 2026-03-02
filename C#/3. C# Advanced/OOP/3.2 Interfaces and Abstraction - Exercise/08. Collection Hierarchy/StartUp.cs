using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;


namespace CollectionHierarchy;

public class StartUp
{
    static void Main(string[] args)
    {
        AddCollection addCollection = new();
        AddRemoveCollection addRemoveCollection = new();
        MyList myList = new();

        string[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        AddAll(values, addCollection);
        AddAll(values, addRemoveCollection);
        AddAll(values, myList);

        int count = int.Parse(Console.ReadLine());

        RemoveExactly(count, addRemoveCollection);
        RemoveExactly(count, myList);
    }

    private static void AddAll(string[] values, IAddable collection)
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (i > 0)
            {
                Console.Write(' ');
            }
            int addIndex = collection.Add(values[i]);
            Console.Write(addIndex);
        }
        Console.WriteLine();
    }

    private static void RemoveExactly(int count, IRemovable collection)
    {
        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                Console.Write(' ');
            }
            string removedItem = collection.Remove();
            Console.Write(removedItem);
        }
        Console.WriteLine();
    }
}
