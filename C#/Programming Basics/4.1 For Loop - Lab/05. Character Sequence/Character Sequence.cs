// Напишете програма, която чете текст (стринг), въведен от потребителя и печата всеки символ от текста на отделен ред.
string text = Console.ReadLine();

for (int i = 0; i < text.Length; i++) // i < text.Length = i <= text.Length - 1
    Console.WriteLine(text[i]);