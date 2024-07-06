
public class Node {
    public int Data { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }

    public Node(int data) {
        this.Data = data;
    }

    public static implicit operator Node(int v)
    {
        throw new NotImplementedException();
    }
}