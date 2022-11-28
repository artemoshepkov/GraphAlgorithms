namespace GraphsAlgorithms
{
    class Program
    {
        private static void Main()
        {
            //var nodes = new int[] { 0, 1,
            //                        0, 2,
            //                        1, 2,
            //                        1, 3,
            //                        1, 4,
            //2, 4,
            //4, 3,
            //3, 5,
            //4, 5};



            //var edgesWeight = new int[] { 1, 3, 4, 7, 5, 6, 9, 2, 8 };

            //var nodes = new int[] { 0, 1,

            //    0, 2,
            //    0, 3,
            //    0, 4,
            //    0, 5,
            //    1, 0,
            //    1, 2,
            //    1, 3,
            //    1, 4,
            //    1, 5,
            //    2, 0,
            //    2, 1,
            //    2, 3,
            //    2, 4,
            //    2, 5,
            //    3, 0,
            //    3, 1,
            //    3, 2,
            //    3, 4,
            //    3, 5,
            //    4, 1,
            //    4, 2,
            //    4, 3,
            //    4, 5,
            //    5, 0,
            //    5, 1,
            //    5, 2,
            //    5, 3,
            //    5, 4
            //};


            //var edgesWeight = new int[] { 2, 7, -4, 6, 3, 3, 4, 5, 6, -1, 2, -4, -8, 7, int.MaxValue - 1000, 4, int.MaxValue - 1000, 8, 5, 7, int.MaxValue - 1000, 7, 8, 4, -3, -2, 4, int.MaxValue - 1000, 7, 8 };
            var nodes = new int[] { 0, 1,
                0,2,
                0,3,
                1,0,
                1,2,
                2,0,
                2,1,
                2,3,
                3,0,
                3,2,

            };

            var edgesWeight = new int[] { -4, -2, -3, -4, -1, -2, -1, 2, -3, 2 };

            FordBellmanTest(nodes, edgesWeight);
        }

        private static void FordBellmanTest(int[] nodes, int[] edgesWeight)
        {
            var graph = Graph.MakeGraph(nodes, edgesWeight);

            Console.WriteLine("Graph:");
            foreach (var edge in graph.Edges)
                Console.WriteLine(edge);
            Console.WriteLine();

            for (int i = 0; i < graph.Nodes.Count(); i++)
            {
                FordBellmanTestGraph(graph, 1, i);
            }

        }


        private static void FordBellmanTestGraph(Graph graph, int startNode, int endNode)
        {
            var shortestPath = FordBellman.GetMinPath(graph, graph[startNode], graph[endNode]);

            if (shortestPath == null)
            {
                Console.WriteLine("No path to " + endNode);
                Console.WriteLine(String.Concat(Enumerable.Repeat("-", 30)));
                return;
            }

            Console.WriteLine("Min path: {0} ", shortestPath.Item1);
            foreach (var node in shortestPath.Item2)
                Console.Write(node + " ");
            Console.WriteLine();
            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 30)));
        }

        private static void DijkstraTest()
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

    public class BackTrackData
    {
        public Node Previous;
        public int Cost;
    }
}