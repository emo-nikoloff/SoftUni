namespace Plan;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------Стек--------");
        Stack<int> stack = new(); // LIFO => Last in - First out -> елементите се нареждат един върху друг, а не един до друг; последният влязъл елемент е и първият излязъл

        for (int i = 1; i <= 5; i++)
        {
            stack.Push(i); // вкарва елемент на върха на стека
        }

        Console.WriteLine($"Елементът на върха: {stack.Peek()}"); // връща елемента на върха

        Console.WriteLine("Елементите в стека:");
        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop()); // взима елемента на върха
        }

        Console.WriteLine("--------Опашка--------");
        Queue<int> queue = new(); // FIFO => First in - Firs out -> елементите се нареждат един след друг, а не един до друг; последният влязъл елемент е и последният излязъл

        for (int i = 1; i <= 5; i++)
        {
            queue.Enqueue(i); // вкарва елемент в опашката
        }

        Console.WriteLine($"Първият елемент в опашката: {queue.Peek()}"); // връща първия елемент в опашката

        Console.WriteLine("Елементите в опашката:");
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue()); // взима първия елемент
        }

        Console.WriteLine("----------------");

        // въртене на елементите в опашка =>
        Queue<string> names = new(new string[] { "John", "Mariya", "Alex" });
        Console.WriteLine($"Опашка: {string.Join(", ", names)}");
        names.Enqueue(names.Dequeue()); // махаме първия елемент и след това го добавяме отново => отива най-отзад
        Console.WriteLine($"John минава от реда си и отива най-отзад => {string.Join(", ", names)}");

        Console.WriteLine("--------Многомерни масиви--------");
        Console.WriteLine("---> Матрица:"); // първото измерение - редове, а второто - колони
        int[,] matrix = {
            { 5, 7, 2, 4 }, // стойностите на ред 0
            { 1, 3, 8, 6 } // стойностите на ред 1
        };

        for (int row = 0; row < matrix.GetLength(0); row++) // GetLength(0) - взима дължината на измерение 0
        {
            for (int col = 0; col < matrix.GetLength(1); col++) // GetLength(1) - взима дължината на измерение 1
            {
                Console.Write($"{matrix[row, col]} ");
            }
            Console.WriteLine();
        }

        for (int row = 0; row < matrix.GetLength(0); row++) // обхожда редовете => обхождаме колоните по съответния ред
        {
            int sumRows = 0;
            for (int col = 0; col < matrix.GetLength(1); col++) // обхожда колоните
            {
                sumRows += matrix[row, col]; // добавя елемента от ред-row, колона-col
            }
            Console.WriteLine($"Ред {row} - {sumRows}");
        }

        for (int col = 0; col < matrix.GetLength(1); col++) // обхожда колоните => обхождаме редовете по съответната колона
        {
            int sumColumns = 0;
            for (int row = 0; row < matrix.GetLength(0); row++) // обхожда редовете
            {
                sumColumns += matrix[row, col]; // добавя елемента от колона-col, ред-row
            }
            Console.WriteLine($"Колона {col} - {sumColumns}");
        }

        Console.WriteLine("---> Назъбен масив:"); // масив от масиви; всяко измерение може да е с различен размер
        int[][] jagged = new int[3][]; // масив с три реда
        jagged[0] = new int[3] { 1, 2, 3 }; // ред 0 - 3 колони
        jagged[1] = new int[2] { 4, 5 }; // ред 1 - 2 колони
        jagged[2] = new int[4] { 6, 7, 8, 9 }; // ред 2 - 4 колони

        for (int row = 0; row < jagged.Length; row++)
        {
            for (int col = 0; col < jagged[row].Length; col++)
            {
                Console.Write($"{jagged[row][col]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("--------Сетове--------");
        HashSet<string> hashSet = new(); // сета пази уникални елементи; хеш-сета пази елемементите в хеш-таблица
        hashSet.Add("John");
        hashSet.Add("John"); // няма да се добави, защото вече съществува
        hashSet.Add("Michael");
        hashSet.Add("Steven");
        foreach (string name in hashSet)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("--------Файлове--------");
        string inputFilePath = @"C:\Users\Емо Николов\Desktop\Проекти\SoftUni\C#\3. Programming Advanced\Advanced\General\Files\input.txt";
        string outputFilePath = @"C:\Users\Емо Николов\Desktop\Проекти\SoftUni\C#\3. Programming Advanced\Advanced\General\Files\output.txt";

        StreamReader reader = new(inputFilePath); // чете от файл/поток
        using (reader) // затваря потока правилно накрая
        {
            string line = reader.ReadLine();

            StreamWriter writer = new(outputFilePath); // записва във файл/поток
            using (writer)
            {
                while (line != null)
                {
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }

        Console.WriteLine("--------Функции--------");
        Console.WriteLine("---> Делегат:"); // променлива, която пази метод
        MyDelegate firstDelegate = new(PrintHelloEmo);
        firstDelegate(); // извикване на делегата; ако не е от тип void, ще трябва да се присвои към променлива от съответния тип

        MyDelegate secondDelegate = new(PrintHelloRoji);
        secondDelegate();

        Console.WriteLine("----------------");

        MyDelegate myDelegate = new(PrintHelloRoji);
        myDelegate += PrintHelloEmo; // закачане на още функции
        GetDelegate(myDelegate);

        Console.WriteLine("----------------");

        Combine add = (x, y) => x + y; // използване на lambda израз -> (параметър) => {тяло}
        Combine multiply = (x, y) => x * y;
        int sum = add(3, 5);
        int multiplication = multiply(3, 5);
        Console.WriteLine($"Резултатът от събирането и умножението на 3 и 5: {sum}, {multiplication}");

        Console.WriteLine("===> Универсални делегати:"); // модерен начин за записване на делегати
        Console.WriteLine("=> Action:"); // void метод
        Action<string> print = message => Console.WriteLine(message);
        print("Име: Емчо");
        print("Име: Рожка");

        Console.WriteLine("=> Func:"); // return метод
        Func<int, int, int> addition = (x, y) => x + y; // <първа стойност, втора стойност, резултат от операцията(return)>
        int summation = addition(6, 9);
        Console.WriteLine($"Сбор на 6 и 9: {summation}");

        Console.WriteLine("=> Predicate:"); // bool метод; може да бъде заменен от Func<int, bool>
        Predicate<int> isNegative = x => x < 0;

        Console.WriteLine($"5 отрицателно число ли е?: {isNegative(5)}");
        Console.WriteLine($"-5 отрицателно число ли е?: {isNegative(-5)}");

        Console.WriteLine("----------------");

        List<int> numbers = new() { -6, 5, 2, 3, -7, 9 };
        Console.WriteLine($"Списък: {string.Join(", ", numbers)}");

        List<int> negativeNumbers = numbers.FindAll(isNegative);
        Console.WriteLine($"Всички отрицателни числа в списъка: {string.Join(", ", negativeNumbers)}");
    }

    // Функции:
    delegate void MyDelegate(); // делегат

    static void PrintHelloEmo()
    {
        Console.WriteLine("Здравей, Емка!");
    }

    static void PrintHelloRoji()
    {
        Console.WriteLine("Здравей, Рожи!");
    }

    static void GetDelegate(MyDelegate @delegate)
    {
        @delegate();
    }

    delegate int Combine(int x, int y);
}
