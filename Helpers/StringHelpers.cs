using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using V7.BaseApplication.Utilies.Exceptions;

namespace V7.BaseApplication.Utilies.Helpers
{
    public static class StringHelpers
    {
        public static string ConvertToQueryString(this NameValueCollection values)
        {
            return string.Join("&", values.AllKeys.Select(key => key + "=" + HttpUtility.UrlEncode(values[key])));
        }
        public static string ConvertToSearch(this string value)
        {
            if (value == null)
                return string.Empty;
            return $"%{value.Replace("%", "")}%";
        }
        /// <summary>
        /// Finds a match in value using regular expression.
        /// </summary>
        /// <param name="value">Value to be searched</param>
        /// <param name="pattern">Regex pattern<. Form more <a href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference">information </a></param>
        /// <param name="throwIfNotFound"></param>
        /// <returns></returns>
        /// <exception cref="MatchNotFoundException">throwIfNotFound değeri true ise bulunamadığında bu exception fırlatır..</exception>
        public static string FindMatch(this string value, string pattern, bool throwIfNotFound = false) {
            var match = Regex.Match(value, pattern);
            if (match.Success == false && throwIfNotFound)
                throw new MatchNotFoundException();

            return match.Value;
        }
    }
}
