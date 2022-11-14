namespace GraphsAlgorithms
{
    class Program
    {
        private static void Main()
        {
            var nodes = new int[] { 0, 1,
                                    0, 2,
                                    1, 2,
                                    1, 3,
                                    1, 4,
            2, 4,
            4, 3,
            3, 5,
            4, 5};

            var edgesWeight = new int[] { 1, 3, 4, 7, 5, 6, 9, 2, 8 };

            DijkstraTestGraph(nodes, edgesWeight);
        }

        private static void DijkstraTestGraph(int[] nodes, int[] edgesWeight)
        {
            var graph = Graph.MakeGraph(nodes, edgesWeight);

            Console.WriteLine("Graph:");
            foreach (var edge in graph.Edges)
                Console.WriteLine(edge);

            var shortestPath = Dijkstra.FindSP(graph, graph[0], graph[5]);

            Console.WriteLine("\nStortest path: " + shortestPath.Item1);
            foreach (var node in shortestPath.Item2)
                Console.Write(node + " ");
            Console.WriteLine();
            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 30)));
        }

        private static void KraskalTest()
        {
            //var nodes = new int[] { 0, 1,
            //                        0, 2,
            //                        1, 2,
            //                        1, 3,
            //                        2, 3 };

            //var edgesWeight = new int[] { 1, 2, 4, 3, 5 };

            //var nodes = new int[] { 0, 1,
            //                        0, 2,
            //                        1, 2,
            //                        1, 3,
            //                        1, 4,
            //2, 4,
            //3, 4,
            //3, 5,
            //4, 5};

            //var edgesWeight = new int[] { 1, 3, 4, 7, 5, 6, 9, 2, 8 };

            var nodes = new int[] { 0, 1,
                                    0, 5,
                                    0, 6,
                                    1, 6,
                                    1, 2,
            2, 6,
            2, 3,
            3, 6,
            3, 4,
            4, 6,
            4, 5,
            5, 6};

            var edgesWeight = new int[] { 20, 23, 1, 4, 5, 9, 3, 16, 17, 25, 28, 36 };

            KraskalTestGraph(nodes, edgesWeight);
            Console.WriteLine(Kraskal.OperationsAmount);
        }

        private static void KraskalTestGraph(int[] nodes, int[] edgesWeight)
        {
            var graph = Graph.MakeGraph(nodes, edgesWeight);

            Console.WriteLine("Graph:");
            foreach (var edge in graph.Edges)
                Console.WriteLine(edge);

            var minSpanningTree = Kraskal.FindMinSpanningTree(graph);

            Console.WriteLine("\nMinimal spanning tree:");
            foreach (var edge in minSpanningTree)
                Console.WriteLine(edge);
            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 30)));
        }
    }
}