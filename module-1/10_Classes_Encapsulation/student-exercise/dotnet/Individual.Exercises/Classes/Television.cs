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

        }

        public void ChannelUp()
        {

        }

        public void ChannelDown()
        {

        }

        public void RaiseVolume()
        {

        }

        public void LowerVolume()
        {

        }
    }

}
