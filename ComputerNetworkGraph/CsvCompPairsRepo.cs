using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace ComputerNetworkGraph
{
    public class CsvCompPairsRepo : ICompPairsRepo
    {
        private readonly string _csvFileLocation;

        public CsvCompPairsRepo()
        {
            this._csvFileLocation = ConfigurationManager.AppSettings["CsvFileLocation"];
            PopulateCompPairs();
        }

        public CsvCompPairsRepo(string csvFileLocation)
        {
            this._csvFileLocation = csvFileLocation;
            PopulateCompPairs();
        }

        private void PopulateCompPairs()
        {
            var tempPairs = CsvHelper.ReadInCsv(this._csvFileLocation);
            this.CompPairs = new List<ICompPair>();
            foreach (var tempPair in tempPairs)
            {
                var pair = (ICompPair) tempPair;
                this.CompPairs.Add(pair);
            }
        }

        public List<ICompPair> CompPairs { get; private set; }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            foreach (var compPair in this.CompPairs)
            {
                strBuilder.AppendLine($"{compPair.Node1Id} - {compPair.Node2Id}");
            }
            return strBuilder.ToString();
        }
    }
}
