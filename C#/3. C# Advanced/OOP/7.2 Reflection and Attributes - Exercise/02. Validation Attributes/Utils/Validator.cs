using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utils;

public static class Validator
{
    public static bool IsValid(object obj)
    {
        Type type = obj.GetType();

        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            IEnumerable<MyValidationAttribute> customAttributes = property.GetCustomAttributes<MyValidationAttribute>();

            foreach (MyValidationAttribute attribute in customAttributes)
            {
                object value = property.GetValue(obj);
                if (!attribute.IsValid(value))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
