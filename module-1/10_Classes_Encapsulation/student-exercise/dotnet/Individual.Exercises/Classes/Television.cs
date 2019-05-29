using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Television
    {
       //Properties
       public bool IsOn { get; private set; }
       public int CurrentChannel { get; private set; }
       public int CurrentVolume { get; private set; }


        //Constructors 
        public Television()
        {
            CurrentChannel = 3;
            CurrentVolume = 2;
        }

        //Methods

        public void TurnOff()
        {
            IsOn = false;
        }
        public void TurnOn()
        {
            IsOn = true;
            CurrentChannel = 3;
            CurrentVolume = 2;
        }

        public void ChangeChannel(int newChannel)
        {
            if (!IsOn)
            {
                CurrentChannel = 3;
            }
            else if (IsOn)
            {
                CurrentChannel = newChannel;
            }
        }

        public void ChannelUp()
        {
            if (!IsOn)
            {
                CurrentChannel = 3;
            }
            else if (IsOn && CurrentChannel >= 18)
            {
                CurrentChannel = 3;
            }
            else if (IsOn) 
            {
                CurrentChannel = CurrentChannel + 1;
            }
        }

        public void ChannelDown()
        {
            if (!IsOn)
            {
                CurrentChannel = 3;
            }
            else if (IsOn && CurrentChannel <= 3)
            {
                CurrentChannel = 18;
            }
            else if (IsOn)
            {
                CurrentChannel = CurrentChannel - 1;
            }
        }

        public void RaiseVolume()
        {
            if (!IsOn)
            {
                CurrentVolume = 2;
            }
            else if (IsOn && CurrentVolume <= 10)
            {
                CurrentVolume = CurrentVolume + 1;
            }
        }

        public void LowerVolume()
        {
            if (!IsOn)
            {
                CurrentVolume = 2;
            }
            else if (IsOn && CurrentVolume > 0)
            {
                CurrentVolume = CurrentVolume - 1;
            }
        }
    }

}
