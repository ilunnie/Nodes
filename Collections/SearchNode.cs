using System.Collections.Generic;

namespace ilunnie.Collections;

public abstract class SearchNode<T, TNode> where TNode : INode<T>
{
    public TNode Node { get; set; }
    public abstract IEnumerable<SearchNode<T, TNode>> Neighbours();
    public bool Visited { get; set; } = false;
    public bool IsSolution { get; set; } = false;

    public SearchNode(TNode node) => this.Node = node;

    public void Reset()
    {
        this.Visited = false;
        this.IsSolution = false;
    }
}