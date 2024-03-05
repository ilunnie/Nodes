using System.Collections.Generic;
using System.Linq;

namespace ilunnie.Collections;

public class GraphNode<T> : INode<T>
{
    public T Value { get; set; }
    public IEnumerable<GraphNode<T>> Neighbors { get; set; }
    public int Connections => Neighbors.Count();

    public GraphNode(
        T value = default,
        IEnumerable<GraphNode<T>> neighbors = null!
    )
    {
        this.Value = value;
        this.Neighbors = neighbors is null
                            ? Enumerable.Empty<GraphNode<T>>()
                            : neighbors.Select(neighbor =>
                                { 
                                    if (!neighbor.Neighbors.Contains(this))
                                        neighbor.Neighbors = neighbor.Neighbors.Append(this);
                                    return neighbor;
                                });
    }

    public GraphNode<T> AddNode(GraphNode<T> node)
    {
        if (!this.Neighbors.Contains(node))
            this.Neighbors = this.Neighbors.Append(node);
        if (!node.Neighbors.Contains(this))
            node.Neighbors = node.Neighbors.Append(this);

        return this;
    }

    public GraphNode<T> RemoveNode(GraphNode<T> node)
    {
        this.Neighbors = this.Neighbors.Where(x => x != node);
        node.Neighbors = node.Neighbors.Where(x => x != this);

        return this;
    }
}