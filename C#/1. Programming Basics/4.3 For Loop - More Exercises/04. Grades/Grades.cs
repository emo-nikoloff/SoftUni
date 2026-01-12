// Напишете програма, която да пресмята статистика на оценки от изпит. В началото програмата получава броят на студентите явили се на изпита и за всеки студент неговата оценка.
// На края програмата трябва да изпечата процента на студенти с оценка между 2.00 и 2.99, между 3.00 и 3.99, между 4.00 и 4.99, 5.00 или повече. Също така и средният успех на изпита.
int students = int.Parse(Console.ReadLine());

double topStudents = 0;
double middleStudents = 0;
double lowStudents = 0;
double failStudents = 0;
double average = 0;
for (int i = 0; i < students; i++)
{
    double grades = double.Parse(Console.ReadLine());

    if (grades >= 5.00)
        topStudents++;
    else if (grades >= 4.00)
        middleStudents++;
    else if (grades >= 3.00)
        lowStudents++;
    else
        failStudents++;
    average += grades / students;
}

topStudents = topStudents / students * 100;
middleStudents = middleStudents / students * 100;
lowStudents = lowStudents / students * 100;
failStudents = failStudents / students * 100;
Console.WriteLine($"Top students: {topStudents:f2}%");
Console.WriteLine($"Between 4.00 and 4.99: {middleStudents:f2}%");
Console.WriteLine($"Between 3.00 and 3.99: {lowStudents:f2}%");
Console.WriteLine($"Fail: {failStudents:f2}%");
Console.WriteLine($"Average: {average:f2}");