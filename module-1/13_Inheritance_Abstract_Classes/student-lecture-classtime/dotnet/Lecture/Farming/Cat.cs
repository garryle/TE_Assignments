using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public sealed class Cat : FarmAnimal
    {
        public Cat () :base("CAT",false)
        {

        }

        protected override string MakeAwakeSoundOnce()
        {
            return "Meow";
        }

        protected override string MakeAwakeSoundTwice()
        {
            return "Meow Meow";
        }
    }
}
