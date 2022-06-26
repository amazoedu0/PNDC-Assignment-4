class Edge
{
    public int Cost { get; set; }
    public Node Src { get; set; }
    public Node Dst { get; set; }

    public bool Used = false;
    public bool Counted = false;
    public Edge() { }
    public Edge(Node src, Node dst, int Cost,bool Used=false)
    {
        this.Src = src; this.Dst = dst; this.Cost = Cost;this.Used = Used; 
    }
}