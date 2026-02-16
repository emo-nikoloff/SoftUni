/*Create a class EqualityScale<T> that holds two elements – left and right. The scale should receive the elements through its single constructor:
· EqualityScale(T left, T right)
The scale should have a single method:
· bool AreEqual()
The greater of the two elements is the heavier. The method should return true, if the elements are equal.*/
namespace _03._Generic_Scale;

class Program
{
    static void Main(string[] args)
    {
        EqualityScale<int> scale = new(5, 6);

        Console.WriteLine(scale.AreEqual());
    }
}
