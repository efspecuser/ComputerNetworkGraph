using System.Collections.Generic;

namespace Contracts
{
    public interface IVertex
    {
        List<IEdge> Edges { get; set; }
    }
}