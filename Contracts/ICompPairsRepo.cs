using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICompPairsRepo
    {
        List<ICompPair> CompPairs { get; }
    }
}