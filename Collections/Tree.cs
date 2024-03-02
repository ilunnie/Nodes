using System.Collections.Generic;

namespace ilunnie.Collections;

public class Tree<T>
{
    public TreeNode<T> Root { get; set; }
    public IEnumerable<TreeNode<T>> Children => Root.Children;

    public Tree(TreeNode<T> root)
         => this.Root = root;
    public Tree(T value)
        => this.Root = new TreeNode<T>(value);

    public void AddBranch(Tree<T> branch)
        => Root.AddChild(branch.Root);

    public void AddBranch(TreeNode<T> branch)
        => Root.AddChild(branch);

    public void RemoveBranch(Tree<T> branch)
        => Root.RemoveChild(branch.Root);

    public void RemoveBranch(TreeNode<T> branch)
        => Root.RemoveChild(branch);

    public override string ToString()
        => Root.ToString();
}