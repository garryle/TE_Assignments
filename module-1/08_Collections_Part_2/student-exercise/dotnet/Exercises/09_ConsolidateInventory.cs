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
         * Given two Dictionaries, Dictionary<string, int>, merge the two into a new Dictionary, Dictionary<string, int> where keys in Dictionary2,
         * and their int values, are added to the int values of matching keys in Dictionary1. Return the new Dictionary.
         *
         * Unmatched keys and their int values in Dictionary2 are simply added to Dictionary1.
         *
         * ConsolidateInventory({"SKU1": 100, "SKU2": 53, "SKU3": 44} {"SKU2":11, "SKU4": 5})
         * 	 → {"SKU1": 100, "SKU2": 64, "SKU3": 44, "SKU4": 5}
         *
         */
        public Dictionary<string, int> ConsolidateInventory(Dictionary<string, int> mainWarehouse,
            Dictionary<string, int> remoteWarehouse)
        {
            //create a new conbined dictionary that is initialized to mainWarehouse
            Dictionary<string, int> comboInventory = new Dictionary<string, int>(mainWarehouse);

            //loop through remoteWarehouse
            foreach (KeyValuePair<string, int> kvp in remoteWarehouse)
            {
                //if the key already exists in the new combined dictionary, then add the value for that key to the combo dictionary
                if (comboInventory.ContainsKey(kvp.Key))
                {
                    //if doesn't already exist, add it witht he remote value
                    comboInventory[kvp.Key] = comboInventory[kvp.Key] + kvp.Value;
                }
                else
                {
                    comboInventory[kvp.Key] = kvp.Value;
                }
            }
            return comboInventory;
        }
    }
}
