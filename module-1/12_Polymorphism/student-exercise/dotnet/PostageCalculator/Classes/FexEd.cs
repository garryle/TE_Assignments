﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    class FexEd : IDeliveryDriver
    {
        private string Name = "FexEd\t\t\t";

        string IDeliveryDriver.Name
        {
            get
            {
                return "FexEd\t\t\t";
            }
        }

        public double CalculateRate(int distance, double weight)
        {
            double rate = 20;
            if (weight > 48 && distance > 500)
            {
                rate += 8;
            }
            else if (weight > 48)
            {
                rate += 3;
            }
            else if (distance > 500)
            {
                rate += 5;
            }
            else
            {
                return rate;
            }
            return rate;
        }
    }
}
