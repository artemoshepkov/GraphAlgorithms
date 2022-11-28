
namespace GraphsAlgorithms
{
    public class Edge
    {
        public readonly Node From;
        public readonly Node To;
        public readonly int Weight;

        public Edge(Node from, Node to, int weight = 0)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public bool IsIncident(Node node) => From == node || To == node;

        public Node OtherNode(Node node)
        {
            if (!IsIncident(node))
                throw new ArgumentException();

            return From == node ? To : From;
        }

        public override string ToString()
        {
            return $"{From} - {To} ({Weight})";
        }
    }

    public class Node
    {
        private readonly List<Edge> _incidentEdges = new List<Edge>();
        public readonly int Number;

        public Node(int nodeNumber)
        {
            Number = nodeNumber;
        }

        public IEnumerable<Node> IncidentNodes => _incidentEdges.Select(e => e.OtherNode(this));

        public IEnumerable<Edge> IncidentEdges
        {
            get
            {
                foreach (var edge in _incidentEdges)
                    yield return edge;
            }
        }

        public static Edge ConnectNodes(Node node1, Node node2, Graph graph, int weight = 0)
        {
            if (!graph.Nodes.Contains(node1) || !graph.Nodes.Contains(node2))
                throw new ArgumentException();

            var newEdge = new Edge(node1, node2, weight);

            node1._incidentEdges.Add(newEdge);
            node2._incidentEdges.Add(newEdge);

            return newEdge;
        }

        public static void DeleteEdge(Edge edge)
        {
            edge.From._incidentEdges.Remove(edge);
            edge.To._incidentEdges.Remove(edge);
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Node;
            return this.Number == other.Number;
        }

        public override int GetHashCode()
        {
            return Number;
        }
    }

    public class Graph
    {
        private Node[] _nodes;

        public Node this[int index] => _nodes[index];

        public IEnumerable<Edge> Edges => _nodes.SelectMany(n => n.IncidentEdges).Distinct();

        public IEnumerable<Node> Nodes
        {
            get
            {
                foreach (var node in _nodes)
                    yield return node;
            }
        }

        public Graph(int nodesCount)
        {
            _nodes = Enumerable.Range(0, nodesCount).Select(n => new Node(n)).ToArray();
        }

        public void ConnectNodes(int index1, int index2, int weight = 0)
        {
            Node.ConnectNodes(this[index1], this[index2], this, weight);
        }

        public void DeleteEdge(Edge edge)
        {
            Node.DeleteEdge(edge);
        }

        public static Graph MakeGraph(params int[] incidentNodes)
        {
            Graph graph = new Graph(incidentNodes.Max() + 1);

            for (int i = 0; i < incidentNodes.Length; i += 2)
                graph.ConnectNodes(incidentNodes[i], incidentNodes[i + 1]);

            return graph;
        }

        public static Graph MakeGraph(int[] incidentNodes, int[] weightEdges)
        {
            Graph graph = new Graph(incidentNodes.Max() + 1);

            for (int i = 0; i < incidentNodes.Length; i += 2)
                graph.ConnectNodes(incidentNodes[i], incidentNodes[i + 1], weightEdges[i / 2]);

            return graph;
        }
    }
}
