using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] property = obj.GetType().GetProperties().Where(X => X.GetCustomAttributes(typeof(MyValidationAttribute)).Any())
                .ToArray();
            foreach (var item in property)
            {
                object value = item.GetValue(obj);
                MyValidationAttribute atribute = item.GetCustomAttribute<MyValidationAttribute>();
                bool isValid = atribute.IsValid(value);
                if (!isValid)
                {
                    return false;
                }
            }
            return true;    
        }
    }
}