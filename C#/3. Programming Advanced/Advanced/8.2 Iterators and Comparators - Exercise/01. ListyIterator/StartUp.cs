/*Task 1: Create a generic class ListyIterator. The collection, which it will iterate through, should be received by the constructor. You should store the elements in a List. The class should have three
main functions:
· Move - should move an internal index position to the next index in the list. The method should return true, if it had successfully moved the index and false, if there is no next index.
· HasNext - should return true, if there is a next index and false, if the index is already at the last element of the list.
· Print - should print the element at the current internal index. Calling Print on a collection without elements should throw an appropriate exception with the message "Invalid Operation!".
By default, the internal index should be pointing to the 0th index of the List. Your program should catch any exceptions thrown because of the described validations - calling Print on an empty
collection - and print their messages instead.
Task 2: Using the ListyIterator from the last problem, extend it by implementing the IEnumerable<T> interface, implement all methods desired by the interface manually. Use yield return for the
GetEnumerator() method. Add a new command PrintAll that should foreach the collection and print all of the elements on a single line separated by a space. Your program should catch any exceptions
thrown because of validations and print their messages instead.*/
namespace ListyIterator;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] create = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<string> elements = create[1..].ToList();
        ListyIterator<string> iterator = new(elements);

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "END")
        {
            switch (command)
            {
                case "Move":
                    Console.WriteLine(iterator.MoveNext());
                    break;
                case "HasNext":
                    Console.WriteLine(iterator.HasNext());
                    break;
                case "Print":
                    try
                    {
                        Console.WriteLine(iterator.Current);
                    }
                    catch (InvalidOperationException error)
                    {
                        Console.WriteLine(error.Message);
                    }
                    break;
            }
        }
    }
}
