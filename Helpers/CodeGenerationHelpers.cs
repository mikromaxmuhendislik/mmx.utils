using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Helpers
{
    public static class CodeGenerationHelpers
    {
        public static string CreateRandomCode(int Length,
                                              bool includeLowerCaseLetters = false,
                                              bool includeNumbers = false,
                                              bool inclueSpecialCharacters = false)
        {
            var ls = new List<string>();
            for (int i = 65; i <= 90; i++)
            {
                ls.Add(((char)i).ToString());
            }

            if (includeNumbers)
            {
                for (int i = 48; i <= 57; i++)
                {
                    ls.Add(((char)i).ToString());
                }
            }
            if (includeLowerCaseLetters)
            {
                for (int i = 97; i <= 122; i++)
                {
                    ls.Add(((char)i).ToString());
                }
            }
            if (inclueSpecialCharacters)
            {
                ls.Add("#");
                ls.Add("!");
                ls.Add("$");
                ls.Add("%");
                ls.Add("*");
                ls.Add("@");
                ls.Add("^");
                ls.Add("%");

            }
            string sonuc = "";
            for (var i = 1; i <= Length; i++)
            {
                Random rnd = new Random();
                var xr = rnd.Next(0, ls.Count-1);
                sonuc = sonuc + ls[xr];
            }
            return sonuc;
        }
    }
}
