using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V7.BaseApplication.Utilies.Models
{
    public class TreeViewModel
    {
        public TreeViewModel(string fieldName,
                             string fieldType,
                             string parentFieldType,
                             bool isEnumerable,
                             bool isComplex, 
                             string enumerableType,
                             string parentFieldId=default)
        {
            FieldName = fieldName;
            FieldType = fieldType;
            ParentFieldType = parentFieldType;
            IsEnumerable = isEnumerable;
            IsComplex = isComplex;
            EnumerableType = enumerableType;
            ParentFieldId = parentFieldId;
        }
        public string FieldName { get;  }
        public string FieldType { get;  }
        public string ParentFieldType { get;  }
        public string ParentFieldId { get; set; }
        public bool IsEnumerable { get;  }
        public bool IsComplex { get;  }
        public string FieldId { get => $"{ParentFieldType}.{FieldName}"; }
        public string EnumerableType { get;  }
        public string Description { get; set; }
        public override string ToString()
        {
            return $"{FieldName}, Enumerable: {IsEnumerable}, IsComplex: {IsComplex} Parent: {ParentFieldType}";
        }
    }
}
