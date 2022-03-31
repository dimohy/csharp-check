var root = new Node(1, "node0")
{
    Children = new List<Node>
    {
        new(11, "node4")
        {
            Children = new List<Node>
            {
                new(111, "node7")
            }
        },
        new(21, "node2")
        {
            Children = new List<Node>
            {
                new(211, "node5")
            }
        },
        new(31, "node3")
        {
            Children = new List<Node>
            {
                new(311, "node6")
            }
        }
    }
};

// 부모 설정
InitParentNode(root);

var count = CountNodes(root);
Console.WriteLine($"Total Nodes: {count}");

ShowNodes(root);


void InitParentNode(Node node)
{
    foreach (var child in node.Children)
    {
        child.Parent = node;
        InitParentNode(child);
    }
}

// 일반 버젼
int CountNodes(Node node)
{
    var count = 0;

    CountChildren(node);

    return count;

    void CountChildren(Node node)
    {
        count++;
        foreach (var child in node.Children)
            CountChildren(child);
    }
}

void ShowNodes(Node node)
{
    var tab = 0;
    
    ShowChildren(node);

    void ShowChildren(Node node)
    {
        Console.WriteLine($"{"".PadLeft(tab)}{node.Name}");
        tab += 3;
        foreach (var child in node.Children)
            ShowChildren(child);
        tab -= 3;
    }
}



public class Node
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; init; } = default!;
    public TreeType TreeType => this switch
    {
        { Parent: null } => TreeType.Root,
        { Parent: not null, Children: var c } when c.Count > 0 => TreeType.Branch,
        { Parent: not null, Children: var c } when c.Count is 0 => TreeType.Leaf,
        _ => TreeType.Root
    };

    public Node Parent { get; set; } = default!;
    public IList<Node> Children { get; init; } = new List<Node>();

    public Node(int id, string name) => (Id, Name) = (id, name);
}

public enum TreeType
{
    Root,
    Branch,
    Leaf
}
