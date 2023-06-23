using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Models
{
    public class LookUpViewModel
    {
        public int Value { get; set; }
        public string ValueText { get; set; }
        public string Description { get; set; }
    }
    /// <summary>
    /// LookUpViewModel'in içinde enum verisi de bulunan versiyonu.
    /// </summary>
    /// <typeparam name="TEnum">Enum type</typeparam>
    public class LookUpViewModel<TEnum>:LookUpViewModel
    {
        public TEnum TValue { get; set; }= default(TEnum);
    }
}
