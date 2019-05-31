using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Duck : FarmAnimal
    {
        public Duck():base ("DUCK",false)
        {
            Price = 5; 
        }

        protected override string MakeAwakeSoundOnce()
        {
            return "QUACK";
        }


        protected override string MakeAwakeSoundTwice()
        {
            return "QUACK QUACK";
        }
    }
}
