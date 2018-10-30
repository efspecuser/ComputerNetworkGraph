using Contracts;

namespace ComputerNetworkGraph
{
    public class Edge : IEdge
    {
        public IVertex Source { get; }
        public IVertex Target { get; }

        public Edge(IVertex v1, IVertex v2)
        {
            this.Source = v1;
            this.Target = v2;
        }

        public override string ToString()
        {
            return $"{this.Source} - {this.Target}";
        }
    }
}
