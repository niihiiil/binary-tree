public class BinaryTree
{
    private BinaryTreeNode root;

    public void Add(int value, object item)
    {
        var node = new BinaryTreeNode(value, item);
        if (root == null)
        {
            root = node;
            return;
        }

        var result = Traverse(value);
        if (result.Found == null)
        {
            if (result.Side == "right")
            {
                result.Parent.Right = node;
            }
            else
            {
                result.Parent.Left = node;
            }
        }
        else
        {
            throw new Exception("two items of the same value added");
        }
    }

    public object Search(int value)
    {
        var result = Traverse(value);
        return result.Found != null ? result.Found.Item : null;
    }

    public bool Contains(int value)
    {
        return Search(value) != null;
    }

    public BinaryTreeNode Root()
    {
        return root;
    }

    private (BinaryTreeNode Found, BinaryTreeNode Parent, string Side) Traverse(int value)
    {
        var found = root;
        BinaryTreeNode parent = null;
        string side = null;
        while (found != null && found.Value != value)
        {
            parent = found;
            if (value > found.Value)
            {
                side = "right";
                found = found.Right;
            }
            else
            {
                side = "left";
                found = found.Left;
            }
        }

        return (found, parent, side);
    }

    public class BinaryTreeNode
    {
        public int Value { get; set; }
        public object Item { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int value, object item)
        {
            Value = value;
            Item = item;
        }
    }
}