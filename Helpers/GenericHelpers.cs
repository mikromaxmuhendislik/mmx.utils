using System;
using System.Collections.Generic;
using System.Linq;
using V7.BaseApplication.Utilies.Models.HelperModels;

namespace V7.BaseApplication.Utilies.Helpers
{
    public static class GenericHelpers
    {
        /// <summary>
        /// Generates tree of items from item list
        /// </summary>
        /// 
        /// <typeparam name="T">Type of item in collection</typeparam>
        /// <typeparam name="K">Type of parent_id</typeparam>
        /// 
        /// <param name="collection">Collection of items</param>
        /// <param name="id_selector">Function extracting item's id</param>
        /// <param name="parent_id_selector">Function extracting item's parent_id</param>
        /// <param name="root_id">Root element id</param>
        /// 
        /// <returns>Tree of items</returns>
        public static IEnumerable<TreeItem<T>> GenerateTree<T, K>(
            this IEnumerable<T> collection,
            Func<T, K> id_selector,
            Func<T, K> parent_id_selector,
            K root_id = default(K))
        {
            foreach (var c in collection.Where(c => EqualityComparer<K>.Default.Equals(parent_id_selector(c), root_id)))
            {
                yield return new TreeItem<T>
                {
                    Item = c,
                    Children = collection.GenerateTree(id_selector, parent_id_selector, id_selector(c))
                };
            }
        }
        public static TreeItem<T> FindNode<T, K>(this IEnumerable<TreeItem<T>> collection, Func<T, K> id_selector, K nodeId)
        {
            var searchList = new List<TreeItem<T>>();
            searchList.AddRange(collection);
            while (searchList.Count > 0)
            {
                var node = searchList.First();
                if (EqualityComparer<K>.Default.Equals(id_selector(node.Item), nodeId))
                    return node;
                searchList.Remove(node);
                if (node.Children.Any())
                    searchList.AddRange(node.Children);
            }
            return null;
        }
    }
}
