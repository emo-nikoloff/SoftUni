// За даден период от време, всеки ден в болницата пристигат пациенти за преглед. Тя разполага първоначално със 7 лекари.
// Всеки лекар може да преглежда само по един пациент на ден, но понякога има недостиг на лекари, затова останалите пациенти се изпращат в други болници.
// Всеки трети ден, болницата прави изчисления и ако броят на непрегледаните пациенти е по-голям от броя на прегледаните, се назначава още един лекар.
// Като назначаването става преди да започне приемът на пациенти за деня.
// Напишете програма, която изчислява за дадения период броя на прегледаните и непрегледаните пациенти.
int days = int.Parse(Console.ReadLine());

int doctors = 7;
int treatedPatients = 0;
int untreatedPatients = 0;
for (int i = 1; i <= days; i++)
{
    if (i % 3 == 0 && treatedPatients < untreatedPatients)
        doctors++;

    int patients = int.Parse(Console.ReadLine());
    if (patients <= doctors)
    {
        treatedPatients += doctors - (doctors - patients);
        untreatedPatients += 0;
    }
    else
    {
        untreatedPatients += patients - doctors;
        treatedPatients += doctors;
    }
}
Console.WriteLine($"Treated patients: {treatedPatients}.");
Console.WriteLine($"Untreated patients: {untreatedPatients}.");