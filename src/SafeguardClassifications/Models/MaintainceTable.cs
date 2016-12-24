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
            var items = System.IO.File.ReadAllLines("MainTable.csv").ToList<string>();


            string filepath = "MainTable.csv";

            FileStream file = new FileStream(filepath, FileMode.Open,FileAccess.Read);

            TextReader reader = new StreamReader(file);

            var csv = new CsvReader(reader);
            
            var records = csv.GetRecords<Classification>().ToList();

            foreach (var x in records)
            {
                x.incidentType= x.incidentType.Replace("/", " | ");
                x.causeGroup = x.causeGroup.Replace("/", " | ");
                x.cause1 = x.cause1.Replace("/", " | ");
            }

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
