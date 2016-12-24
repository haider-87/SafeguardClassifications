using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeguardClassifications.Models;


namespace SafeguardClassifications.ViewModels
{
    public class Cause1s : IEnumerable<string>
    {

        // A list of unique incident types obtained from maintainance table

  
        public List<string> Causes { get; set; }

        public Cause1s(MaintainanceTable d)
        {

     
            Causes = new List<string>(0);


            // Add first cause group from maintainance table

    
            Causes.Add(d.First().cause1);
            // check if cause group exist , Add if yes else don't add. 

            foreach (var x in d)
            {
                string t = x.cause1;
                if (Causes.Contains(t))
                {
                    continue;
                }

                Causes.Add(t);
            }

  



        }

        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)Causes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>)Causes).GetEnumerator();
        }
    }


}