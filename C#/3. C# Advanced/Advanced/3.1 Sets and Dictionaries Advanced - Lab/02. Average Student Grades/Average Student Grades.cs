namespace _02._Average_Student_Grades;

class Program
{
    static void Main(string[] args)
    {
        int students = int.Parse(Console.ReadLine());
        Dictionary<string, List<decimal>> studentsGrades = new();

        for (int i = 1; i <= students; i++)
        {
            string[] studentGrade = Console.ReadLine().Split();
            string student = studentGrade[0];
            decimal grade = decimal.Parse(studentGrade[1]);

            if (!studentsGrades.ContainsKey(student))
            {
                studentsGrades.Add(student, new());
            }
            studentsGrades[student].Add(grade);
        }

        foreach ((string student, List<decimal> grades) in studentsGrades)
        {
            Console.WriteLine($"{student} -> {string.Join(" ", grades.Select(g => g.ToString("f2")))} (avg: {grades.Average():f2})");
        }
    }
}
