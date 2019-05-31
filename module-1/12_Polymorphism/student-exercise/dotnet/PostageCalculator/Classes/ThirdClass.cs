﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PostageCalculator.Classes
{
    public class ThirdClass : IDeliveryDriver
    {
        private string Name = "Postal Service (3rd Class)";
        private double rate;
        //Implementation
        string IDeliveryDriver.Name
        {
            get
            {
                return "Postal Service (3rd Class)";
            }
        }

        public double CalculateRate(int distance, double weight)
        {
            if (weight <= 2)
            {
                rate = 0.0020;
            }
            else if (weight <= 8)
            {
                rate = 0.0022;
            }
            else if (weight <= 15)
            {
                rate = 0.0024;
            }
            else if (weight <= 48)
            {
                rate = 0.0150;
            }
            else if (weight <= 128)
            {
                rate = 0.0160;
            }
            else
            {
                rate = 0.0170;
            }
            return distance * rate;
        }
    }
}