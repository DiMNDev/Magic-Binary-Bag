namespace Logic;

interface IItem
{
    int ID { get; init; }
    string Name { get; init; }
    EType Type { get; init; }
    ERarity Rarity { get; init; }
    int Strength { get; init; }
}
interface INode
{
    Item Data { get; set; }
    Node? Left { get; set; }
    Node? Right { get; set; }
}

public class Node : INode
{
    public Item Data { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public Node(Item data)
    {
        Data = data;
    }
}
public class Item : IItem
{
    public int ID { get; init; }
    public string Name { get; init; }
    public EType Type { get; init; }
    public ERarity Rarity { get; init; }
    public int Strength { get; init; }
    public Item(int id, string name, EType type, ERarity rarity, int strength)
    {
        ID = id;
        Name = name;
        Type = type;
        Rarity = rarity;
        Strength = strength;

    }
}
public abstract class BinaryTree
{
    abstract public Node? Root { get; set; }
    public void Insert(Item item)
    {
        Node newNode = new Node(item);
        if (Root != null)
        {
            Insert(Root, newNode);
        }
        else
        {
            Root = newNode;
        }
    }
    public Node Insert(Node currentNode, Node newNode)
    {
        if (currentNode == null)
        {
            return newNode;
        }
        if (newNode.Data.ID < currentNode.Data.ID)
        {
            currentNode.Left = Insert(currentNode.Left!, newNode);
        }
        else if (newNode.Data.ID > currentNode.Data.ID)
        {
            currentNode.Right = Insert(currentNode.Right!, newNode);
        }
        return currentNode;
    }
    public Node Delete(int Id)
    {
        if (Root != null)
        {
            return Delete(Root, Id);
        }
        else
        {
            return Root;
        }
    }
    public Node Delete(Node CurrentNode, int key)
    {
        // Base case: if the tree is empty
        if (CurrentNode == null)
        {
            return CurrentNode;
        }

        // Recursively find the node to be deleted
        if (key < CurrentNode.Data.ID)
        {
            CurrentNode.Left = Delete(CurrentNode.Left, key);
        }
        else if (key > CurrentNode.Data.ID)
        {
            CurrentNode.Right = Delete(CurrentNode.Right, key);
        }
        else
        {
            // Node to be deleted found

            // Case 1: Node with only one child or no child
            if (CurrentNode.Left == null)
            {
                return CurrentNode.Right;
            }
            else if (CurrentNode.Right == null)
            {
                return CurrentNode.Left;
            }

            // Case 2: Node with two children:
            // Get the in-order successor (smallest in the right subtree)
            Node successor = MinValue(CurrentNode.Right);

            // Replace CurrentNode's data with the successor's data (keep structure intact)
            CurrentNode.Data = successor.Data;

            // Delete the in-order successor (since its value is now in CurrentNode)
            CurrentNode.Right = Delete(CurrentNode.Right, successor.Data.ID);
        }

        return CurrentNode;
    }

    // Helper method to find the minimum value node in the right subtree (in-order successor)
    private Node MinValue(Node node)
    {
        Node current = node;

        // Loop down to find the leftmost leaf
        while (current.Left != null)
        {
            current = current.Left;
        }

        return current;
    }

    public Node Traverse(Node currentNode) //NLR In-Order Traversal
    {
        if (currentNode == null)
        {
            return currentNode;
        }
        if (currentNode.Left != null)
        {
            Traverse(currentNode.Left);
        }
        if (currentNode.Left != null)
        {
            Traverse(currentNode.Right);
        }
        Console.WriteLine($"{currentNode.Data.ID}: {currentNode.Data.Name}");
        return currentNode;
    }
    public void Rebalance()
    {
        if (IsBalanced)
        {
            return;
        }
        else
        {
            Rebalance(Root);
        }
    }

    public Node Rebalance(Node currentNode)
    {
        if (currentNode == null)
        {
            return currentNode;
        }
        return currentNode;
    }

    public int GetHeight(Node currentNode)
    {
        if (currentNode == null)
        {
            return -1;
        }
        return Math.Max(GetHeight(currentNode.Left!), GetHeight(currentNode.Right!)) + 1;
    }
    public bool IsBalanced { get; private set; }

    public bool CheckBalance(Node currentNode, int leftCount = 0, int rightCount = 0)
    {
        if (currentNode == null)
        {
            Console.WriteLine($"{leftCount} - {rightCount} = {Math.Abs(leftCount - rightCount)}");
            if (Math.Abs(leftCount - rightCount) <= 1)
            {
                IsBalanced = true;
            }
            else
            {
                IsBalanced = false;
            }
        }
        if (currentNode?.Left != null || currentNode?.Right != null)
        {
            CheckBalance(currentNode.Left!, leftCount += 1, rightCount);
            // Console.WriteLine($"Left: {currentNode.Data.Name}");
            CheckBalance(currentNode.Right!, leftCount, rightCount += 1);
            // Console.WriteLine($"Right: {currentNode.Data.Name}");
        }
        // Console.WriteLine($"Root: {Root.Data.ID}-{Root.Data.Name}");
        return IsBalanced;
    }
    public Item[] SortBy(Sort option) { return new Item[50]; }
    public Node? SearchFor(int Id) { return null; }
    public void Optimize() { }
};

public class Inventory : BinaryTree
{
    public override Node? Root { get; set; }
    public Inventory()
    {
        Root = null;
    }

}

public enum EType
{
    Weapon,
    Potion,
    Armor,
    Accessory
}

public enum ERarity
{
    Common,
    Rare,
    Legendary
}

public enum Sort
{
    Id,
    Rarity
}