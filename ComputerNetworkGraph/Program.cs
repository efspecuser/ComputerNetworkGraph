using System;
using System.Collections.Generic;
using System.IO;
using Contracts;

namespace ComputerNetworkGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var compPairsRepo = new CsvCompPairsRepo();
                Console.WriteLine("CSV contains the following pairs:");
                Console.WriteLine(compPairsRepo);

                var graph = ComputerGraphFactory.GetGraph(compPairsRepo);

                Console.WriteLine("The graph is connected: " + graph.IsConnected);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Could not locate default CSV file: {e.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
