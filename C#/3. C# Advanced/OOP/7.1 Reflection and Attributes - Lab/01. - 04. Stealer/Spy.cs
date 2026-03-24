using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        object classInstance = Activator.CreateInstance(classType);

        StringBuilder result = new($"Class under investigation: {className}\n");
        foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
        {
            object fieldValue = field.GetValue(classInstance);

            result.AppendLine($"{field.Name} = {fieldValue}");
        }

        return result.ToString().Trim();
    }

    public string AnalyzeAccessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType.GetFields();
        PropertyInfo[] classProperties = classType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder result = new();
        foreach (FieldInfo field in classFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }
        foreach (PropertyInfo property in classProperties)
        {
            MethodInfo getMethod = property.GetGetMethod(true);
            if (getMethod != null && !getMethod.IsPublic)
            {
                result.AppendLine($"{getMethod.Name} have to be public!");
            }

            MethodInfo setMethod = property.GetSetMethod();
            if (setMethod != null && setMethod.IsPublic)
            {
                result.AppendLine($"{setMethod.Name} have to be private!");
            }
        }

        return result.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder result = new($"All Private Methods of Class: {className}\nBase Class: {classType.BaseType.Name}\n");
        foreach (MethodInfo method in classMethods)
        {
            result.AppendLine($"{method.Name}");
        }

        return result.ToString().Trim();
    }

    public string CollectGetterAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder result = new();
        foreach (MethodInfo method in classMethods)
        {
            if (method.Name.StartsWith("get"))
            {
                result.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            else if (method.Name.StartsWith("set"))
            {
                result.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
        }

        return result.ToString().Trim();
    }
}
