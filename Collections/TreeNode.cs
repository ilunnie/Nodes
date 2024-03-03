using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ilunnie.Collections;

public class TreeNode<T> : INode<T>
{
    public T Value { get; set; }
    /// <summary> If null then is root </summary>
    public TreeNode<T> Parent { get; set; }
    public IEnumerable<TreeNode<T>> Children { get; set; }

    public TreeNode(
        T value,
        TreeNode<T> parent = null,
        IEnumerable<TreeNode<T>> children = null
    )
    {
        this.Value = value;
        this.Parent = parent;

        this.Children = children is null
                            ? Enumerable.Empty<TreeNode<T>>()
                            : children.Select(child => { child.Parent = this; return child; });
    }

    public TreeNode<T> AddChild(TreeNode<T> child)
    {
        child.Parent = this;
        this.Children = this.Children.Append(child);

        return this;
    }

    public TreeNode<T> RemoveChild(TreeNode<T> child)
    {
        child.Parent = null;
        this.Children = this.Children.Where(x => x != child);

        return this;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        ToString(builder, isRoot: true);
        return builder.ToString();
    }

    /// <summary>
    /// Add current node in builder
    /// </summary>
    /// <param name="builder">StringBuilder with nodes</param>
    /// <param name="indent">Characters preceding the current node</param>
    /// <param name="isRoot">If it is the root, there will be no indentation</param>
    /// <returns></returns>
    protected StringBuilder ToString(StringBuilder builder, string indent = "", bool isRoot = false)
    {
        builder.Append(indent);

        bool isLast = Parent is null || Parent?.Children.LastOrDefault() == this;
        if (!isRoot)
            if (isLast)
            {
                builder.Append("\u2514\u2500\u2500\u2500"); // is "└───"
                indent += "    ";
            }
            else
            {
                builder.Append("\u251c\u2500\u2500\u2500"); // is "├───"
                indent += "\u2502   "; // is "│   "
            }

        builder.AppendLine(Value?.ToString());
        for (int i = 0; i < this.Children.Count(); i++)
            this.Children.ElementAt(i).ToString(builder, indent);

        return builder;
    }
}