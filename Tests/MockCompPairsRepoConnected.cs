﻿using System.Collections.Generic;
using ComputerNetworkGraph;
using Contracts;

namespace Tests
{
    public class MockCompPairsRepoConnected : ICompPairsRepo
    {
        public List<ICompPair> CompPairs => new List<ICompPair>
        {
            new CompPair{Node1Id = "comp1", Node2Id = "comp2"},
            new CompPair{Node1Id = "comp2", Node2Id = "comp3"},
            new CompPair{Node1Id = "comp1", Node2Id = "comp3"},
            new CompPair{Node1Id = "comp4", Node2Id = "comp5"},
            new CompPair{Node1Id = "comp1", Node2Id = "comp4"}
        };
    }
}
