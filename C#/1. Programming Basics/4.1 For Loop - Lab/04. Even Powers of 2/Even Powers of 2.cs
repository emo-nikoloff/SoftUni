// Да се напише програма, която чете число n, въведено от потребителя, и печата четните степени на 2 ≤ 2n: 20, 22, 24, 26, …, 2n. 
int n = int.Parse(Console.ReadLine());

for (int i = 0; i <= n; i += 2)
    Console.WriteLine(Math.Pow(2, i));

/*for (int i = 0, power = 1; i <= n; i += 2, power *= 4)
    Console.WriteLine(power);*/