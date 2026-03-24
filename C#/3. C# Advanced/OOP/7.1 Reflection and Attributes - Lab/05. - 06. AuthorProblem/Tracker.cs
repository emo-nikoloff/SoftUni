using System.Reflection;

namespace AuthorProblem;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type[] allTypes = typeof(Tracker).Assembly.GetTypes();

        foreach (Type type in allTypes)
        {
            MethodInfo[] allMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (MethodInfo method in allMethods)
            {
                List<string> authorAttributes = method.GetCustomAttributes<AuthorAttribute>().Select(attr => attr.Name).ToList();

                if (authorAttributes.Any())
                {
                    Console.WriteLine($"{method.Name} is written by {string.Join(", ", authorAttributes)}");
                }
            }
        }
    }
}
