using System.Collections.Generic;
using System.Linq;

namespace ilunnie.Collections;

public class SearchTreeNode<T> : SearchNode<T, TreeNode<T>>
{
    public SearchTreeNode(TreeNode<T> node) : base(node) {}

    public override IEnumerable<SearchNode<T, TreeNode<T>>> Neighbours()
    {
        var neighbours = Enumerable.Empty<SearchNode<T, TreeNode<T>>>();
        foreach (var neighbor in Node.Children)
            neighbours = neighbours.Append(new SearchTreeNode<T>(neighbor));
        return neighbours;
    }
}
