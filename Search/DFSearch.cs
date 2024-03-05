using System.Collections.Generic;
using System.Linq;
using ilunnie.Collections;

namespace ilunnie.Search;

public static partial class Search
{
    public static bool DFSearch<T, TNode>(this SearchNode<T, TNode> node, T goal) where TNode : INode<T>
    {
        if (node.Visited)
            return false;
        node.Visited = true;


        if (EqualityComparer<T>.Default.Equals(node.Node.Value, goal))
        {
            node.IsSolution = true;
            return true;
        }

        return node.Neighbours().Any(neighbour => !neighbour.Visited && DFSearch<T, TNode>(neighbour, goal));
    }
}