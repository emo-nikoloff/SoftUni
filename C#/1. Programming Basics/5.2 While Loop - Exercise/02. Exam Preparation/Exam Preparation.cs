// Напишете програма, в която Марин решава задачи от изпити докато не получи съобщение "Enough" от лектора си. При всяка решена задача той получава оценка.
// Програмата трябва да приключи прочитането на данни при команда "Enough" или ако Марин получи определения брой незадоволителни оценки.
// Незадоволителна е всяка оценка, която е по-малка или равна на 4.
int numberOfFails = int.Parse(Console.ReadLine());

int failsCount = 0;
bool failed = true;
int solved = 0;
double sumGrades = 0;
string lastExercise = "";
while (failsCount < numberOfFails)
{
    string exercise = Console.ReadLine();
    if (exercise == "Enough")
    {
        failed = false;
        break;
    }
    int grade = int.Parse(Console.ReadLine());

    if (grade <= 4)
        failsCount++;
    solved++;
    sumGrades += grade;
    lastExercise = exercise;
}

if (failed)
    Console.WriteLine($"You need a break, {failsCount} poor grades.");
else
{
    Console.WriteLine($"Average score: {sumGrades / solved:f2}");
    Console.WriteLine($"Number of problems: {solved}");
    Console.WriteLine($"Last problem: {lastExercise}");
}