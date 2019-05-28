using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Elevator
    {
        //Properties
        public int CurrentLevel { get; private set; }
        public bool DoorIsOpen { get; private set; }
        public int NumberOfLevels { get; }

        //Constructors
        Elevator(int numberOfLevels)
        {
            NumberOfLevels = numberOfLevels;
        }

        //Methods 

        public void OpenDoor()
        {
            
        }

        public void CloseDoor()
        {
            
        }

        public void GoUp(int desiredFloor)
        {

        }

        public void GoDown(int desiredFloor)
        {

        }
    }

}
