using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using CsvHelper;

namespace ComputerNetworkGraph
{
    public static class CsvHelper
    {
        public static List<CompPair> ReadInCsv(string absolutePath)
        {
            List<CompPair> result;
            //string value;

            using (TextReader fileReader = File.OpenText(absolutePath))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";

                result = csv.GetRecords<CompPair>().ToList();

                //while (csv.Read())
                //{
                //    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                //    {
                //        result.Add(value);
                //    }
                //}
            }


            return result;
        }
    }
}
