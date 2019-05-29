using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class MachoManRandySavage : FarmAnimal
    {
        public MachoManRandySavage():base("MACHOMANRANDYSAVAGE")
        {
            Price = 10; 
        }

        public override string MakeSoundOnce()
        {
            return "OH YEAH";
        }

        public override string MakeSoundTwice()
        {
            return "SNAP INTO A SLIM JIM";
        }
    }
}
