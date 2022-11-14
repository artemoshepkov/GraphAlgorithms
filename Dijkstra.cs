using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAlgorithms
{
    public class Dijkstra
    {
        private class DijkstraData
        {
            public Node Previous;
            public int Cost;
        }

        public static Tuple<int, List<Node>> FindSP(Graph graph, Node start, Node end)
        {
            var track = new Dictionary<Node, DijkstraData>();

            var notVisited = graph.Nodes.ToList();

            track[start] = new DijkstraData { Cost = 0, Previous = null };
            
            while (true)
            {
                var minCost = int.MaxValue;
                Node toNode = null;

                foreach (var node in notVisited)
                {
                    if (track.ContainsKey(node) && track[node].Cost < minCost)
                    {
                        toNode = node;
                        minCost = track[node].Cost;
                    }
                }

                if (toNode == null)
                    return null;
                if (toNode == end)
                    break;

                foreach (var edge in toNode.IncidentEdges.Where(e => e.From == toNode))
                {
                    var minPrice = edge.Weight + track[toNode].Cost;
                    var nextNode = edge.To;

                    if (!track.ContainsKey(nextNode) || track[nextNode].Cost > minPrice)
                        track[nextNode] = new DijkstraData { Cost = minPrice, Previous = toNode };
                }

                notVisited.Remove(toNode);
            }

            return Tuple.Create(track[end].Cost, TranslateDictPathToList(track, end));
        }

        private static List<Node> TranslateDictPathToList(Dictionary<Node, DijkstraData> path, Node end)
        {
            var shortestPath = new List<Node>();

            while (end != null)
            {
                shortestPath.Add(end);
                end = path[end].Previous;
            }
            shortestPath.Reverse();

            return shortestPath;
        }
    }
}
