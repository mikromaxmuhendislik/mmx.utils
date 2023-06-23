using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using V7.BaseApplication.Utilies.Models;

namespace V7.BaseApplication.Utilies.Helpers
{
    public static class ReflectionHelpers
    {
        public static Dictionary<string, object> GetConstantsFromType(this Type type)
        {
            return type.GetFields()
                .Where(x => (x.Attributes & System.Reflection.FieldAttributes.Literal) != 0)
                .Select(x => new { x.Name, Value = x.GetValue(null) })
                .ToDictionary(x => x.Name, x => x.Value);
        }
        public static List<TreeViewModel> GetPropertiesWithType(this Type type, IEnumerable<string> excludedFields, string parentFieldId = default)
        {
            var output = new List<TreeViewModel>();
            if (type is null) throw new InvalidOperationException("Geçerisz entity tipi. Entity null olamaz.");
            foreach (var pi in type.GetProperties())
            {
                if (pi.Name.EndsWith("Id"))
                    continue;
                if (excludedFields.Contains(pi.Name))
                    continue;
                bool isEnumerable = (typeof(IEnumerable).IsAssignableFrom(pi.PropertyType) && pi.PropertyType.FullName != "System.String");
                bool isComplex = (!isEnumerable && pi.PropertyType.IsClass && !pi.PropertyType.Namespace.StartsWith("System"));
                string enumerableType = null;
                if (isEnumerable)
                {
                    enumerableType = pi.PropertyType.GetGenericArguments().FirstOrDefault().ToString();
                }
                output.Add(new TreeViewModel(
                    pi.Name,
                    pi.PropertyType.FullName,
                    type.FullName,
                    isEnumerable,
                    isComplex,
                    enumerableType,
                    parentFieldId));

            }
            return output;
        }

    }
}
