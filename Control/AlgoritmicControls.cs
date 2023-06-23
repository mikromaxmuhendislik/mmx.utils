using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V7.BaseApplication.Utilies.Convertion;

namespace V7.BaseApplication.Utilies.Control
{
    public static class AlgoritmicControls
    {
        public static bool IsValidTCKN(this string t)
        {
            if (string.IsNullOrEmpty(t))
            {
                return false;
            }
            else
            {
                if (t[0] != '0')
                {
                    if (t.Length != 11)
                    {
                        return false;
                    }
                    var check1 = (((t[0].GetString().GetDeci() + t[2].GetString().GetDeci() + t[4].GetString().GetDeci() + t[6].GetString().GetDeci() + t[8].GetString().GetDeci()) * 7) - (t[1].GetString().GetDeci() + t[3].GetString().GetDeci() + t[5].GetString().GetDeci() + t[7].GetString().GetDeci())) % 10;
                    if (check1 != t[9].GetString().GetDeci())
                    {
                        return false;
                    }
                    else
                    {
                        var check2 = 0M;
                        for (int i = 0; i < 10; i++)
                        {
                            check2 += t[i].GetString().GetDeci();
                        }
                        if (t[10].GetString().GetDeci() != check2 % 10)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool IsValidTaxNumber(this string vkn)
        {
            int tmp;
            int sum = 0;
            if (vkn != null && vkn.Length == 10 && vkn.All(c=> char.IsNumber(c)))
            {
                int lastDigit = vkn[9].GetInt();
                for (int i = 0; i < 9; i++)
                {
                    int digit = vkn[i].GetInt();
                    tmp = (digit + 10 - (i + 1)) % 10;
                    sum = (int)(tmp == 9 ? sum + tmp : sum + ((tmp * (Math.Pow(2, 10 - (i + 1)))) % 9));
                }
                return lastDigit == (10 - (sum % 10)) % 10;
            }
            return false;
        }
        public static bool IsvalidPhoneNumber(this string phoneNumber, string countryCode)
        {
            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            var phoneNumberParsed = phoneNumberUtil.Parse(phoneNumber, countryCode);
            return phoneNumberUtil.IsValidNumber(phoneNumberParsed);
        }
    }
}
