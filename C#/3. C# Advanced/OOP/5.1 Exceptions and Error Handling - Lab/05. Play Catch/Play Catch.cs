namespace PlayCatch;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int counter = 0;
        while (counter < 3)
        {
            string[] input = Console.ReadLine().Split();

            try
            {
                switch (input[0])
                {
                    case "Replace":
                        {
                            int index = int.Parse(input[1]);
                            int element = int.Parse(input[2]);

                            numbers[index] = element;
                            break;
                        }
                    case "Print":
                        {
                            int startIndex = int.Parse(input[1]);
                            int endIndex = int.Parse(input[2]);

                            List<int> result = new();

                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                result.Add(numbers[i]);
                            }

                            Console.WriteLine(string.Join(", ", result));
                            break;
                        }
                    case "Show":
                        {
                            int index = int.Parse(input[1]);

                            Console.WriteLine(numbers[index]);
                            break;
                        }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("The variable is not in the correct format!");
                counter++;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The index does not exist!");
                counter++;
            }
        }

        Console.WriteLine(string.Join(", ", numbers));
    }
}
