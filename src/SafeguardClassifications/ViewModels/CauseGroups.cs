using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SafeguardClassifications.Models;


namespace SafeguardClassifications.ViewModels
{
    public class CauseGroups : IEnumerable<string>
    {

        // A list of unique incident types obtained from maintainance table

        public List<string> Types { get; set; }


        public CauseGroups(MaintainanceTable d)
        {

            Types = new List<string>(0);

            // Add first cause group from maintainance table

            Types.Add(d.First().causeGroup); 

            // check if cause group exist , Add if yes else don't add. 

            foreach (var x in d)
            {
                string t = x.causeGroup;
                if (Types.Contains(t))
                {
                    continue;
                }

                Types.Add(t);
            }
            
        }

        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)Types).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>)Types).GetEnumerator();
        }
    }
}
