using System.Collections.Generic;

namespace V7.BaseApplication.Utilies.Models.HelperModels
{
    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }
}
