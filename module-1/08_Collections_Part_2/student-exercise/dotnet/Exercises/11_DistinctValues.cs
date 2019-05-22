using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given a list of strings, return a list that contains the distinct values. In other words, no value is to be
         included more than once in the returned list. (Hint: Think HashSet)
         DistinctValues( ["red", "yellow", "green", "yellow", "blue", "green", "purple"] ) -> ["red", "yellow", "green", "blue", "purple"]
         DistinctValues( ["jingle", "bells", "jingle", "bells", "jingle", "all", "the", "way"] ) -> ["jingle", "bells", "all", "the", "way"]
         */
        public List<string> DistinctValues(List<string> stringList)
        {
            //create an empty list for our return
            List<string> distinctStrings = new List<string>();

            //create a hashset of values we've added
            HashSet<string> alreadyAdded = new HashSet<string>(); 

            //go through each item in the stringlist
            foreach(string str in stringList)
            {
                //if we haven't already added it to our return then do it
                if (!alreadyAdded.Contains(str))
                {
                    //add it to our return list
                    distinctStrings.Add(str);
                    //add it to our hash of added things
                    alreadyAdded.Add(str);
                }

            }
            return distinctStrings;


        }

    }
}
