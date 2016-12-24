using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;


namespace SafeguardClassifications.Models 
{
    public class Comments : IEnumerable<Comment>
    {
        

        public List<Comment> CommentsList { get; set; }
    



        public Comments()
        {

            CommentsList = ImportFile();
           

        }

        private List<Comment> ImportFile()
        {

            //Read all lines
            var items = System.IO.File.ReadAllLines("Comments.csv").ToList<string>();


            string filepath = "Comments.csv";

            FileStream file = new FileStream(filepath, FileMode.Open,FileAccess.Read);

            TextReader reader = new StreamReader(file);

            var csv = new CsvReader(reader);
            
            var records = csv.GetRecords<Comment>().ToList();

            foreach (var x in records)
            {

                x.incidentType = x.incidentType.Replace("/", " | ");
                x.comment = x.comment.Replace("/", " | ");
            }

            return records;

    

        }

        public IEnumerator<Comment> GetEnumerator()
        {
            return ((IEnumerable<Comment>)CommentsList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Comment>)CommentsList).GetEnumerator();
        }
    }
}
