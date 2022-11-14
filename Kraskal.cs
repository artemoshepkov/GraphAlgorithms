

using System.Runtime.CompilerServices;

namespace GraphsAlgorithms
{
    public class Kraskal
    {
        public static int OperationsAmount = 0;

        public static IEnumerable<Edge> FindMinSpanningTree(Graph graph)
        {
            var spanningTree = new List<Edge>();

            var connectComponent = new List<List<Node>>();

            foreach (var edge in graph.Edges.OrderBy(e => e.Weight))
            {
                var listNumber1 = -1;
                var listNumber2 = -1;
                for (int i = 0; i < connectComponent.Count; i++)
                {
                    OperationsAmount++;

                    OperationsAmount += connectComponent[i].Count;
                    if (connectComponent[i].Contains(edge.From))
                        listNumber1 = i;

                    if (connectComponent[i].Contains(edge.To))
                        listNumber2 = i;
                }

                if (listNumber1 == -1 && listNumber2 == -1)
                {
                    OperationsAmount += 2;

                    connectComponent.Add(new List<Node> { edge.From, edge.To });
                    spanningTree.Add(edge);
                }
                
                if (listNumber1 == listNumber2)
                    continue;

                if (listNumber1 == -1)
                {
                    OperationsAmount += 2;

                    connectComponent[listNumber2].Add(edge.From);
                    spanningTree.Add(edge);
                    continue;
                }

                if (listNumber2 == -1)
                {
                    OperationsAmount += 2;

                    connectComponent[listNumber1].Add(edge.To);
                    spanningTree.Add(edge);
                    continue;
                }

                connectComponent[listNumber1] = connectComponent[listNumber1].Concat(connectComponent[listNumber2]).ToList();
                connectComponent.RemoveAt(listNumber2);
                spanningTree.Add(edge);
                OperationsAmount += 3;
            }


            return spanningTree;
        }
    }
}

/*
 * 
 *             
 *             
            var connectComponent = new Dictionary<Node, List<Node>>();

            var unionNodes = new HashSet<Node>();

            foreach (var edge in graph.Edges.OrderBy(e => e.Weight))
            {
                if (unionNodes.Contains(edge.From) && unionNodes.Contains(edge.To))
                    continue;

                if (!unionNodes.Contains(edge.From) && !unionNodes.Contains(edge.To))
                {
                    connectComponent[edge.From] = new List<Node>() { edge.From, edge.To };
                    connectComponent[edge.To] = connectComponent[edge.From];
                }
                else
                {
                    if (!connectComponent.ContainsKey(edge.From))
                    {
                        connectComponent[edge.To].Add(edge.From);
                        connectComponent[edge.From] = connectComponent[edge.To];
                    }
                    else
                    {
                        connectComponent[edge.From].Add(edge.To);
                        connectComponent[edge.To] = connectComponent[edge.From];
                    }
                }

                unionNodes.Add(edge.From);
                unionNodes.Add(edge.To);
                spanningTree.Add(edge);
            }

            foreach (var edge in graph.Edges.OrderBy(e => e.Weight))
            {
                if (connectComponent[edge.From].Contains(edge.From) && !connectComponent[edge.From].Contains(edge.To))
                {
                    spanningTree.Add(edge);
                    var temp = connectComponent[edge.From];
                    connectComponent[edge.From] = connectComponent[edge.From].Concat(connectComponent[edge.To]).ToList();
                    connectComponent[edge.To] = connectComponent[edge.To].Concat(temp).ToList();
                }
            }
 *             
 *             
 *             
 *             
 *             ----------------------------------
 *             
 *             
 *             
 *             var spanningTree = new List<Edge>();

            var connectComponents = new Dictionary<int, List<int>>();

            var unionNodes = new List<int>();

            foreach (var edge in graph.Edges.OrderBy(e => e.Weight))
            {
                if (!unionNodes.Contains(edge.From.Number) || !unionNodes.Contains(edge.To.Number))
                {

                    if (!unionNodes.Contains(edge.From.Number) && !unionNodes.Contains(edge.To.Number))
                    {
                        connectComponents[edge.From.Number] = new List<int>() { edge.From.Number, edge.To.Number };
                        connectComponents[edge.To.Number] = connectComponents[edge.From.Number];
                    }
                    else
                    {
                        if (!connectComponents.ContainsKey(edge.From.Number))
                        {
                            connectComponents[edge.To.Number].Add(edge.From.Number);
                            connectComponents[edge.From.Number] = connectComponents[edge.To.Number];
                        }
                        else
                        {
                            connectComponents[edge.From.Number].Add(edge.To.Number);
                            connectComponents[edge.To.Number] = connectComponents[edge.From.Number];
                        }
                    }


                    spanningTree.Add(edge);
                    unionNodes.Add(edge.From.Number);
                    unionNodes.Add(edge.To.Number);
                }
            }

            foreach (var edge in graph.Edges.OrderBy(e => e.Weight))
            {
                if (connectComponents[edge.From.Number].Contains(edge.From.Number) && !connectComponents[edge.From.Number].Contains(edge.To.Number))
                {
                    spanningTree.Add(edge);
                    var temp = connectComponents[edge.From.Number];
                    connectComponents[edge.From.Number] = connectComponents[edge.From.Number].Concat(connectComponents[edge.To.Number]).ToList();
                    connectComponents[edge.To.Number] = connectComponents[edge.To.Number].Concat(temp).ToList();
                }
            }

            return spanningTree;
*/
