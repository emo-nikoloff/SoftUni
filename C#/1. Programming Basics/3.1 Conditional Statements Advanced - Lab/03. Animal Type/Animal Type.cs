// Напишете програма, която отпечатва класа на животното според неговото име, въведено от потребителя.
// 1. dog->mammal
// 2. crocodile, tortoise, snake -> reptile
// 3. others -> unknown
string animal = Console.ReadLine();

string output = "";
switch (animal)
{
    case "dog":
        output = "mammal";
        break;
    case "crocodile":
    case "tortoise":
    case "snake":
        output = "reptile";
        break;
    default:
        output = "unknown";
        break;
}
Console.WriteLine(output);