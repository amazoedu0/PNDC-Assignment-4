string[] text = File.ReadAllLines("D:/VS/Projects/TempPDCA4/input.txt");

Graph graph = new(int.Parse(text[0]));

for (int i = 1; i <= graph.Size; i++)
{
    String[] links = text[i].Split();
    int j = 0;
    foreach (String link in links)
    {
        graph.AddEdge(graph.Nodes[i - 1], graph.Nodes[j], int.Parse(link));
        j++;
    }
}

Graph minST = new(graph.Size);


int count = 0;
int round = 0;
Console.WriteLine($"\n Round : {count}");
graph.Print();

do
{
    round++;
    Console.WriteLine($"\n Round : {round}");
    foreach (Node n in graph.Nodes)
    {
        minST.AddMinEdge(n, minST.Nodes[n.MinIndexAndCost().Item1], n.MinIndexAndCost().Item2, true);

        int indexOfEdge = 0;
        foreach (Edge e in graph.Nodes[n.ID].Neighbor)
        {
            if (e.Dst.ID == n.MinIndexAndCost().Item1)
                indexOfEdge = graph.Nodes[n.ID].Neighbor.IndexOf(e);
        }
        graph.RemoveUsedEdgeFrom(n, indexOfEdge);
    }

    minST.Print();

    //Console.WriteLine($"\n Counted : {minST.usedEdges(count) / 2} " +
    //                  $": Graph Size: {graph.Size} " +
    //                  $": {minST.Nodes[1].Neighbor.Count}");

} while (minST.usedEdges() / 2 <= graph.Size - 1);



//minST.Print();
