public class BinaryTree<T> where T : IComparable<T>
{
	private BinaryTreeNode<T> root;
	
	public void Add(T value)
	{
		if (root == nill)
		{
		root = new BinaryTreeNode<T>(value);
	}
	else
	{
		root.Add(value);
	}
}

public IEnumerable<T> InOrderTravesal()
{
	return InOrderTravesal(root);
}

private IEnumerable<T> InOrderTravesal(BinaryTreeNode<T> node)
{
	if (node.Left != null)
	{
		foreach (T value in InOrderTravesa(node.Left))
		{
			yield return value;
		}
	}
	yield return node.Value;
	if(node.Right != null)
	{
		foreach (T value in InOrderTravesa(node.Right))
		{
			yield return value;
		}
	}
}
