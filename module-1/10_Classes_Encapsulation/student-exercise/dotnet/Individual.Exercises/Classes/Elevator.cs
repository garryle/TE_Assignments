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
            DoorIsOpen = true;
        }

        public void CloseDoor()
        {
            DoorIsOpen = false;
        }

        public void GoUp(int desiredFloor)
        {
            if (DoorIsOpen == true)
            {
                CurrentLevel = CurrentLevel;
            }
            else if (DoorIsOpen == false && CurrentLevel <= desiredFloor)
            {
                CurrentLevel = desiredFloor;
            }
            else
            {
                CurrentLevel = CurrentLevel;
            }
        }

        public void GoDown(int desiredFloor)
        {
            if (DoorIsOpen == true)
            {
                CurrentLevel = CurrentLevel;
            }
            else if (DoorIsOpen == false && desiredFloor >= 1)
            {
                CurrentLevel = desiredFloor;
            }
            else
            {
                CurrentLevel = CurrentLevel;
            }
        }
    }

}
