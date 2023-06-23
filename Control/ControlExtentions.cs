using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Control
{
    public static class ControlExtentions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }
        public static bool IsNullOrEmpty(this Guid? value)
        {
            if (value is null)
                return true;
            return value.Value.IsEmpty();
        }
        public static bool IsIn<T>(this T value, params T[] array)
        {
            return array.Contains(value);
        }

    }
}
