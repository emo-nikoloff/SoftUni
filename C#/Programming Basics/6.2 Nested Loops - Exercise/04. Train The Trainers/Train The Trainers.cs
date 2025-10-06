// Курсът "Train the trainers" е към края си и финалното оценяване наближава.
// Вашата задача е да помогнете на журито което ще оценява презентациите,
// като напишете програма в която да изчислява средната оценка от представянето на всяка една презентация от даден студент, а накрая средният успех от всички тях.
int jury = int.Parse(Console.ReadLine());
string input;

int allGrades = 0;
double allGradesSum = 0;
while ((input = Console.ReadLine()) != "Finish")
{
    string presentation = input;
    double gradesSum = 0;
    for (int i = 1; i <= jury; i++)
    {
        double grade = double.Parse(Console.ReadLine());
        gradesSum += grade;
        allGrades++;
        allGradesSum += grade;
    }
    Console.WriteLine($"{presentation} - {gradesSum / jury:f2}.");
}
Console.WriteLine($"Student's final assessment is {allGradesSum / allGrades:f2}.");