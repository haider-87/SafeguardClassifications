using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;

namespace SafeguardClassifications.Models 
{
    public class MaintainanceTable : IEnumerable<Classification>
    {
        

        public List<Classification> Classifications { get; set; }
    



        public MaintainanceTable()
        {
            
            Classifications = ImportFile();


        }

        private List<Classification> ImportFile()
        {

            //Read all lines
            var items = System.IO.File.ReadAllLines(@"C:\Solutions\SafeguardClassifications\src\SafeguardClassifications\MainTable.csv").ToList<string>();


            string filepath = @"C:\Solutions\SafeguardClassifications\src\SafeguardClassifications\MainTable.csv";

            FileStream file = new FileStream(filepath, FileMode.Open,FileAccess.Read);

            TextReader reader = new StreamReader(file);

            var csv = new CsvReader(reader);
            
            var records = csv.GetRecords<Classification>().ToList();

            return records;

    

        }

        public IEnumerator<Classification> GetEnumerator()
        {
            return ((IEnumerable<Classification>)Classifications).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Classification>)Classifications).GetEnumerator();
        }
    }
}
