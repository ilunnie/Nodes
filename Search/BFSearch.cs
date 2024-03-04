using System.Collections.Generic;
using System.Linq;
using ilunnie.Collections;

namespace ilunnie.Search;

public static partial class Search
{
    public static bool BFSearch<T>(this TreeNode<T> node, T goal)
    {
        if (EqualityComparer<T>.Default.Equals(node.Value, goal))
            return true;

        Queue<TreeNode<T>> queue = new();
        queue.Append(node);
        while (queue.Count > 0)
        {
            var treeNode = queue.Dequeue();
            if (EqualityComparer<T>.Default.Equals(treeNode.Value, goal))
                    return true;

            foreach (var child in treeNode.Children)
                queue.Append(child);
        }

        return false;
    }

    public static bool BFSearch<T>(this Tree<T> tree, T goal)
        => DFSearch(tree.Root, goal);
}