using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace ComputerNetworkGraph
{
    public static class ComputerGraphFactory
    {
        public static Graph GetGraph(ICompPairsRepo compPairsRepo)
        {
            var compPairs = compPairsRepo.CompPairs;
            var gr = new Graph();
            foreach (var compPair in compPairs)
            {
                Vertex v1 = null;
                Vertex v2 = null;
                foreach (var grVertex in gr.Vertices)
                {
                    var vertex = (Vertex) grVertex;
                    if (vertex.Value == compPair.Node1Id)
                    {
                        v1 = vertex;
                    }
                    if (vertex.Value == compPair.Node2Id)
                    {
                        v2 = vertex;
                    }
                }

                if (v1 == null) v1 = new Vertex(compPair.Node1Id);
                if (v2 == null) v2 = new Vertex(compPair.Node2Id);

                if (!gr.HasEdge(v1, v2))
                {
                    var edge = new Edge(v1, v2);
                    gr.AddEdge(edge);
                }
            }

            return gr;
        }
    }
}
