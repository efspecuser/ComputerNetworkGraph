using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace ComputerNetworkGraph
{
    public class Vertex : IVertex
    {
        public string Value { get; set; }

        public Vertex(string value)
        {
            this.Value = value;
            this.Edges = new List<IEdge>();
        }


        public override string ToString()
        {
            return this.Value;
        }

        public List<IEdge> Edges { get; set; }
    }
}
