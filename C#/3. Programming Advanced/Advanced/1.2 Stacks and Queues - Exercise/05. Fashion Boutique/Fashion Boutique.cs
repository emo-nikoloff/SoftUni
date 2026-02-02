namespace _05._Fashion_Boutique;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> clothes = new(Console.ReadLine().Split().Select(int.Parse).ToArray());
        int rackCapacity = int.Parse(Console.ReadLine());

        int sumClothes = 0;
        int racks = 1;
        while (clothes.Count > 0)
        {
            int clothing = clothes.Peek();
            if (sumClothes + clothing <= rackCapacity)
            {
                sumClothes += clothes.Pop();
            }
            else
            {
                sumClothes = 0;
                racks++;
            }
        }
        Console.WriteLine(racks);
    }
}
