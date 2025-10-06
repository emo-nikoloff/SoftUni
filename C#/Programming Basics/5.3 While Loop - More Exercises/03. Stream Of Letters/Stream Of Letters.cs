// Напишете програма, която прочита скрито съобщение в поредица от символи. Те се получават по един на ред до получаване на командата "End".
// Думите се образуват от буквите в реда на четенето им. Символите, които не са латински букви трябва да бъдат игнорирани.
// Думите скрити в потока са разделени от тайна команда от три букви – "c", "o" и "n".
// При първото получаване на една от тези букви, тя се маркира като срещната, но не се запазва в думата. При всяко следващо нейно срещане се записва нормално в думата.
// След като са налични и трите символа от командата, се печата думата и интервал " ". Започва се нова дума, която по същия начин чака тайната команда, за да бъде отпечатана.
string input = Console.ReadLine();
string word = "", newWord = "";
int counterC = 0, counterO = 0, counterN = 0;
bool hasC = false, hasO = false, hasN = false;
while (input != "End")
{
    char letter = char.Parse(input);
    if (char.IsLetter(letter))
    {
        if (letter != 'c' && letter != 'o' && letter != 'n')
        {
            word += letter;
        }

        if (letter == 'c')
        {
            counterC++;
            hasC = true;
            if (counterC > 1)
                word += letter;
        }
        else if (letter == 'o')
        {
            counterO++;
            hasO = true;
            if (counterO > 1)
                word += letter;
        }
        else if (letter == 'n')
        {
            counterN++;
            hasN = true;
            if (counterN > 1)
                word += letter;
        }

        if (hasC && hasO && hasN)
        {
            newWord += word + " ";
            word = "";
            hasC = hasO = hasN = false;
            counterC = counterO = counterN = 0;
        }
    }
    input = Console.ReadLine();
}
Console.WriteLine(newWord);