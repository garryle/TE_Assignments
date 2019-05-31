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

        protected override string MakeAwakeSoundOnce()
        {
            return "OH YEAH";
        }

        protected override string MakeAwakeSoundTwice()
        {
            return "SNAP INTO A SLIM JIM";
        }
    }
}
