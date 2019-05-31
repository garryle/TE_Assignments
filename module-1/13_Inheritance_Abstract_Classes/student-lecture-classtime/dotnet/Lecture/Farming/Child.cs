using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Child : ISingable
    {
        public string Name
        {
            get
            {
                return "Child";
            }
        }

        public string MakeSoundOnce()
        {
            return "bark";
        }

        public string MakeSoundTwice()
        {
            return "bark bark";
        }
    }
}
