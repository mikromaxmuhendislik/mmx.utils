using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Models
{
    public class TreeViewEnhancedViewModel:TreeViewModel
    {
        public TreeViewEnhancedViewModel(string fieldName,
                             string fieldType,
                             string parentFieldType,
                             bool isEnumerable,
                             bool isComplex,
                             string enumerableType,
                             object value
                            ): base(fieldName,fieldType,parentFieldType,isEnumerable,isComplex,enumerableType)
        {
            Value = value;
        }

        public object Value { get; }
    }
}
