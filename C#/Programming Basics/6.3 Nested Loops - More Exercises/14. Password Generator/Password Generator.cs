// Да се напише програма, която чете две цели числа n и l, въведени от потребителя, и генерира по азбучен ред всички възможни  пароли, които се състоят от следните 5 символа:
// •	Символ 1: цифра от 1 до n.
// •	Символ 2: цифра от 1 до n.
// •	Символ 3: малка буква измежду първите l букви на латинската азбука.
// •	Символ 4: малка буква измежду първите l букви на латинската азбука.
// •	Символ 5: цифра от 1 до n, по-голяма от първите 2 цифри.
int n = int.Parse(Console.ReadLine());
int l = int.Parse(Console.ReadLine());

char firstLetter = 'a';
char secondLetter = 'a';
for (int firstSymbol = 1; firstSymbol < n; firstSymbol++)
{
    for (int secondSymbol = 1; secondSymbol < n; secondSymbol++)
    {
        for (firstLetter = 'a'; firstLetter < 97 + l; firstLetter++)
        {
            for (secondLetter = 'a'; secondLetter < 97 + l; secondLetter++)
            {
                for (int lastSymbol = 2; lastSymbol <= n; lastSymbol++)
                {
                    if (lastSymbol <= firstSymbol || lastSymbol <= secondSymbol) continue;
                    Console.Write($"{firstSymbol}{secondSymbol}{firstLetter}{secondLetter}{lastSymbol} ");
                }
            }
        }
    }
}