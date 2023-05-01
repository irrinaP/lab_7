public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
{
    private BinaryTreeNode<T> root;

    public void Add(T value)
    {
        if (root == null)
        {
            root = new BinaryTreeNode<T>(value);
        }
        else
        {
            root.Add(value);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new BinaryTreeEnumerator<T>(root);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class BinaryTreeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> root;
        private Stack<BinaryTreeNode<T>> stack;

        public BinaryTreeEnumerator(BinaryTreeNode<T> root)
        {
            this.root = root;
            stack = new Stack<BinaryTreeNode<T>>();
        }

        public bool MoveNext()
        {
            if (stack.Count == 0 && root != null)
            {
                BinaryTreeNode<T> current = root;
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
            }
            else if (stack.Count > 0 && stack.Peek().Right != null)
            {
                BinaryTreeNode<T> current = stack.Peek().Right;
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
            }
            else
            {
                stack.Pop();
            }
            return stack.Count > 0;
        }

        public void Reset()
        {
            stack.Clear();
        }

        public T Current
        {
            get { return stack.Peek().Value; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
        }
    }
}

public class BinaryTreeNode<T> where T : IComparable<T>
{
    public T Value { get; private set; }
    public BinaryTreeNode<T> Left { get; private set; }
    public BinaryTreeNode<T> Right { get; private set; }

    public BinaryTreeNode(T value)
    {
        Value = value;
    }

    public void Add(T value)
    {
        if (value.CompareTo(Value) < 0)
        {
            if (Left == null)
            {
                Left = new BinaryTreeNode<T>(value);
            }
            else
            {
                Left.Add(value);
            }
        }
        else
        {
            if (Right == null)
            {
                Right = new BinaryTreeNode<T>(value);
            }
            else
            {
                Right.Add(value);
            }
        }
    }
}
