using System.Collections.Generic;
using System.Linq;

namespace ilunnie.Collections;

public class SearchGraphNode<T> : SearchNode<T, GraphNode<T>>
{
    public SearchGraphNode(GraphNode<T> node) : base(node) {}

    public override IEnumerable<SearchNode<T, GraphNode<T>>> Neighbours()
    {
        var neighbours = Enumerable.Empty<SearchNode<T, GraphNode<T>>>();
        foreach (var neighbor in Node.Neighbors)
            neighbours = neighbours.Append(new SearchGraphNode<T>(neighbor));
        return neighbours;
    }
}
