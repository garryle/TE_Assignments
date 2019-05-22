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
         * Given the name of an animal, return the name of a group of that animal
         * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").
         *
         * The animal name should be case insensitive so "elephant", "Elephant", and
         * "ELEPHANT" should all return "herd".
         *
         * If the name of the animal is not found, null, or empty, return "unknown".
         *
         * Rhino -> Crash
         * Giraffe -> Tower
         * Elephant -> Herd
         * Lion -> Pride
         * Crow -> Murder
         * Pigeon -> Kit
         * Flamingo -> Pat
         * Deer -> Herd
         * Dog -> Pack
         * Crocodile -> Float
         *
         * AnimalGroupName("giraffe") → "Tower"
         * AnimalGroupName("") -> "unknown"
         * AnimalGroupName("walrus") -> "unknown"
         * AnimalGroupName("Rhino") -> "Crash"
         * AnimalGroupName("rhino") -> "Crash"
         * AnimalGroupName("elephants") -> "unknown"
         *
         */
        public string AnimalGroupName(string animalName)
        {
            animalName = animalName.ToLower(); 

            //create a Dictionary
            Dictionary<string, string> animalGroups = new Dictionary<string, string>();

            //add the info to it
            animalGroups.Add("rhino", "Crash");
            animalGroups.Add("giraffe", "Tower");
            animalGroups.Add("elephant", "Herd");
            animalGroups.Add("lion", "Pride");
            animalGroups.Add("crow", "Murder");
            animalGroups.Add("pigeon", "Kit");
            animalGroups.Add("flamingo", "Pat");
            animalGroups.Add("deer", "Herd");
            animalGroups.Add("dog", "Pack");
            animalGroups.Add("crocodile", "Float");

            //look up animal name

            //if found, return correct value
            if (animalGroups.ContainsKey(animalName))
            {
                return animalGroups[animalName]; 
            }
            else  //if not found, return "unknown"
                return "unknown";

        }
    }
}
