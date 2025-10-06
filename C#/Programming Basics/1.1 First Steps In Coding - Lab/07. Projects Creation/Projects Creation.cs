// Напишете програма, която изчислява колко часа ще са необходими на един архитект, за да изготви проектите на няколко строителни обекта. Изготвянето на един проект отнема три часа.
string architectName = Console.ReadLine();
int projectsCount = int.Parse(Console.ReadLine());

int hours = projectsCount * 3;
Console.WriteLine($"The architect {architectName} will need {hours} hours to complete {projectsCount} project/s.");