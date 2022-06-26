class Graph
{
    public int Size { get; set; }
    public int count = 0;

    public List<Node> Nodes = new();
    public Graph(int Size) { this.Size = Size; Generate(); }
    public void AddEdge(Node src, Node dst, int Cost, bool Used = false)
    {
        if (Cost > 0)
        {
            Edge edge = new(src, dst, Cost, Used);
            Edge edge1 = new(dst, src, Cost, Used);

            foreach (Edge e in Nodes[src.ID].Neighbor) { if (e.Dst.ID == dst.ID) return; }
            foreach (Edge e in Nodes[dst.ID].Neighbor) { if (e.Dst.ID == src.ID) return; }

            Nodes[src.ID].Neighbor.Add(edge);
            //this.Print();
            Nodes[dst.ID].Neighbor.Add(edge1);
        }
    }

    public void AddMinEdge(Node src, Node dst, int Cost, bool Used = false)
    {
        if (Cost > 0)
        {
            Edge edge = new(src, dst, Cost, Used);
            Edge edge1 = new(dst, src, Cost, Used);

            //foreach (Edge e in Nodes[src.ID].Neighbor)
            //{
            //    foreach (Edge e1 in e.Src.Neighbor)
            //        if (e1.Dst.ID == dst.ID)
            //            return;
            //}

            foreach (Edge e in Nodes[src.ID].Neighbor) { if (e.Dst.ID == dst.ID) return; }

            foreach (Edge e in Nodes[dst.ID].Neighbor) { if (e.Dst.ID == src.ID) return; }

            Nodes[src.ID].Neighbor.Add(edge);
            Nodes[dst.ID].Neighbor.Add(edge1);
        }
    }


    public void Safaai()
    {

    }

    public int usedEdges(int count = 0)
    {
        this.count = count;
        foreach (Node n in Nodes)
            foreach (Edge e in n.Neighbor)
            {
                if (!e.Counted)
                {
                    n.Neighbor[n.Neighbor.IndexOf(e)].Counted = true;
                }
                if (e.Counted)
                    count++;

            }
        return count;
    }
    public void RemoveEdgeFrom(Node node, Edge e)
    {
        if (node != null && e != null)
            Nodes[node.ID].Neighbor.Remove(e);
    }

    public void RemoveUsedEdgeFrom(Node node, int Idx)
    {
        foreach (Node n in Nodes)
        {
            if (node.ID == n.ID)
            {
                Nodes[node.ID].Neighbor[Idx].Used = true;
            }
        }
    }

    public void Generate()
    {
        Nodes.Clear();
        for (int i = 0; i < Size; i++) { Node node = new("PC", i); Nodes.Add(node); }
    }
    public void Print()
    {
        foreach (Node node in this.Nodes)
        {
            Console.Write($"\n{node.Name}-{node.ID}-> ");
            foreach (Edge edge in node.Neighbor)
            {
                if (edge.Dst != null)
                    Console.Write($"({edge.Dst.Name}-{edge.Dst.ID} : {edge.Cost}) ");
            }
        }
    }
}