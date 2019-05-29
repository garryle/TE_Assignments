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

        public override string MakeSoundOnce()
        {
            return "OINK";
        }
        public override string MakeSoundTwice()
        {
            return "OINK OINK";
        }


    }
}
