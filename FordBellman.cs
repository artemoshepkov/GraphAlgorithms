using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms
{
    public class FordBellman
    {
        public static Tuple<int, List<Node>> GetMinPath(Graph graph, Node startNode, Node finalNode)
        {
            var maxNodeIndex = graph.Nodes.Count();

            int[] opt = Enumerable.Repeat(int.MaxValue, maxNodeIndex).ToArray();
            opt[startNode.Number] = 0;

            var path = new Dictionary<Node, Node>();
            path[startNode] = null;

            //for (var i = 1; i <= maxNodeIndex; i++)
            //{
            foreach (var edge in graph.Edges)
            {
                if (opt[edge.From.Number] != int.MaxValue)
                {
                    if (opt[edge.To.Number] < opt[edge.From.Number] + edge.Weight)
                    {
                        continue;
                    }

                    opt[edge.To.Number] = opt[edge.From.Number] + edge.Weight;

                    path[edge.To] = edge.From;
                }
            }
            //}    

            return Tuple.Create(opt[finalNode.Number], TranslateDictPathToList(path, finalNode));
        }

        private static List<Node> TranslateDictPathToList(Dictionary<Node, Node> path, Node end)
        {
            var shortestPath = new List<Node>();

            while (end != null)
            {
                shortestPath.Add(end);
                end = path[end];
            }
            shortestPath.Reverse();

            return shortestPath;
        }
    }
}
