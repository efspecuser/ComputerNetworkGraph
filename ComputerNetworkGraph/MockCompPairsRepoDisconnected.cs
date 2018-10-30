using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace ComputerNetworkGraph
{
    public class MockCompPairsRepoDisconnected : ICompPairsRepo
    {
        public List<ICompPair> CompPairs => new List<ICompPair>
        {
            new CompPair{Node1Id = "comp1", Node2Id = "comp2"},
            new CompPair{Node1Id = "comp2", Node2Id = "comp3"},
            new CompPair{Node1Id = "comp1", Node2Id = "comp3"},
            new CompPair{Node1Id = "comp4", Node2Id = "comp5"}
        };
    }
}
