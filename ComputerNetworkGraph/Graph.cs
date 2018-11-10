using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace ComputerNetworkGraph
{
    public class Graph
    {
        public List<IVertex> Vertices { get; }

        public Graph()
        {
            this.Vertices = new List<IVertex>();
        }

        public Graph(List<IVertex> allNodes)
        {
            this.Vertices = allNodes;

        }


        public int Size => this.Vertices.Count;



        public void AddEdge(IEdge edge)
        {
            if (!IsEdgeValid(edge))
                throw new ArgumentNullException();

            var source = edge.Source;
            var target = edge.Target;
            if (!this.Vertices.Contains(source)) this.Vertices.Add(source);
            if (!this.Vertices.Contains(target)) this.Vertices.Add(target);

            source.Edges.Add(edge);
            target.Edges.Add(edge);
        }

        

        public void RemoveEdge(IEdge edge)
        {
            if (!IsEdgeValid(edge))
                throw new ArgumentNullException();

            if (!HasEdge(edge.Source, edge.Target)) return;

            edge.Source.Edges.Remove(edge);
            edge.Target.Edges.Remove(edge);
        }

        public bool HasEdge(IVertex v1, IVertex v2)

        {
            return this.Vertices.Any(v => v.Edges.Any(e => e.Source == v1 && e.Target == v2));
        }

        public bool IsConnected
        {
            get
            {
                foreach (var source in this.Vertices)
                {
                    foreach (var target in this.Vertices.Where(v => !v.Equals(source)))
                    {
                        var visited = new List<IVertex>();
                        bool connected = AreVerticesConnected(source, target, visited);
                        if (!connected) return false;
                    }
                }
                return true;
            }
        }

        internal bool AreVerticesConnected(IVertex v1, IVertex v2, List<IVertex> visited)
        {
            if (visited.Contains(v1)) return false;

            if (v1 == v2) return true;

            visited.Add(v1);

            var outgoingEdges = v1.Edges.Where(e => e.Source == v1);
            var incomingEdges = v1.Edges.Where(e => e.Target == v1);

            bool connectedViaOutgoing = false;
            foreach (var edge in outgoingEdges)
            {
                if (AreVerticesConnected(edge.Target, v2, visited))
                {
                    connectedViaOutgoing = true;
                    break;
                }
            }

            if (connectedViaOutgoing) return true;

            bool connectedViaIncoming = false;
            foreach (var edge in incomingEdges)
            {
                if (AreVerticesConnected(edge.Source, v2, visited))
                {
                    connectedViaIncoming = true;
                    break;
                }
            }

            return connectedViaIncoming;
        }

        private static bool IsEdgeValid(IEdge edge)
        {
            return edge?.Source != null && edge.Target != null;
        }
    }
}
