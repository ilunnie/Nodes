using System.Collections.Generic;
using ilunnie.Collections;

namespace ilunnie.Search;

public static partial class Search
{
    public static bool DFSearch<T>(this TreeNode<T> node, T goal)
    {        
        if (EqualityComparer<T>.Default.Equals(node.Value, goal))
            return true;

        foreach (var currNode in node.Children)
            if (DFSearch(currNode, goal))
                return true;
                
        return false;
    }
    public static bool DFSearch<T>(this Tree<T> tree, T goal)
        => DFSearch(tree.Root, goal);
}