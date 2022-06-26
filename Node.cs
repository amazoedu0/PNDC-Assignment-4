class Node
{
    public int ID { get; set; }
    public String Name { get; set; }

    public bool isCore = false;

    public List<Edge> Neighbor = new();
    public Node() { }
    public Node(String Name, int ID) { this.Name = Name; this.ID = ID; }
    public Tuple<int, int> MinIndexAndCost()
    {
        Tuple<int, int> min = Tuple.Create(this.ID, 1000);

        if (this.Neighbor.Count > 0)
        {
            foreach (Edge e in this.Neighbor)
            {
                if (e.Used) { continue; }
                if (min.Item2 >= e.Cost)
                    min = Tuple.Create(e.Dst.ID, e.Cost);
            }
        }
        return min;
    }
}