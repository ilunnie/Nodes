using System.Collections.Generic;
using System.Linq;

namespace ilunnie.Collections;

public class Graph<T>
{
    public IEnumerable<GraphNode<T>> Nodes { get; set; }

    public Graph(IEnumerable<GraphNode<T>> nodes = null!)
    {
        Nodes = nodes ?? Enumerable.Empty<GraphNode<T>>();
    }
}