﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {

        /*
        7. This method uses an if to check to make sure that one is equal to one.
            Make sure it returns TRUE when one equals one.
            TOPIC: Boolean Expression & Conditional Logic
        */
        public bool ReturnTrueWhenOneEqualsOne()
        {
            bool doesOneEqualOne = (1 == 1);
            
            //bool doesOneEqualOne; 
            //if (1 == 1)
            //{
            //    doesOneEqualOne=true;
            //}
            //else
            //{
            //    doesOneEqualOne = false; 
            //}

            return doesOneEqualOne;
        }

    }
}
