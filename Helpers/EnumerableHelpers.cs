using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Helpers
{
    public static class EnumerableHelpers
    {
        public static string GetSelectedValuesAsString<T>(this IEnumerable<T> source, Func<T,string> selector, string seperator= @"\r\n")
        {
            
            var items = source.Select(selector).ToArray();
            var seperatorInternal = seperator==@"\r\n"?Environment.NewLine:seperator;
            return string.Join(seperatorInternal, items);

        }
    }
}
