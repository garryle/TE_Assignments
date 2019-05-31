using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Tractor : ISingable
    {
        public Tractor()
        {

        }

        public string Name { get { return "Tractor"; } }

        public string MakeSoundOnce()
        {
            return "Put";
        }

        public string MakeSoundTwice()
        {
            return "Put put";
        }
    }
}
