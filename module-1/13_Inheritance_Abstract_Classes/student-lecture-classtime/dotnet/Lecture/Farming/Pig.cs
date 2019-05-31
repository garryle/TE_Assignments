using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Pig : FarmAnimal
    {
        public Pig() : base ("PIG")
        {
            Price = .69;
        }

        protected override string MakeAwakeSoundOnce()
        {
            return "OINK";
        }
        protected override string MakeAwakeSoundTwice()
        {
            return "OINK OINK";
        }


    }
}
