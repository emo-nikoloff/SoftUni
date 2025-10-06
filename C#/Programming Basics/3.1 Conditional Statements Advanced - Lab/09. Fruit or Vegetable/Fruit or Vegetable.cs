// Да се напише програма, която чете име на продукт, въведено от потребителя, и проверява дали е плод или зеленчук.
// •	Плодовете "fruit" имат следните възможни стойности:  banana, apple, kiwi, cherry, lemon и grapes
// •	Зеленчуците "vegetable" имат следните възможни стойности:  tomato, cucumber, pepper и carrot
// •	Всички останали са "unknown"
// Да се изведе "fruit”, "vegetable" или "unknown" според въведения продукт.
string food = Console.ReadLine();

string output = "";
switch (food)
{
    case "banana":
    case "apple":
    case "kiwi":
    case "cherry":
    case "lemon":
    case "grapes":
        output = "fruit";
        break;
    case "tomato":
    case "cucumber":
    case "pepper":
    case "carrot":
        output = "vegetable";
        break;
    default:
        output = "unknown";
        break;
}
Console.WriteLine(output);