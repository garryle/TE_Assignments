using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    public class Car : IVehicle
    {
        //Property
        public bool HasTrailer { get; }
        public int DistanceTraveled { get; }

        //Constructor
        public Car(bool hasTrailer)
        {
            HasTrailer = hasTrailer;
            DistanceTraveled = new Random().Next(10, 240);
        }

        //Implementation
        public double CalculateToll(int distance)
        {
            double toll = 0;

            if (HasTrailer)
            {
                toll = (distance * 0.020) + 1.00;
            }
            else if (!HasTrailer)
            {
                toll = distance * 0.020;
            }

           return toll;
        }

        public override string ToString()
        {
            if (!HasTrailer)
            {
                return "Car     ";
            }
            else
            {
                return "Car(Trailer)";
            }
        }
    }
}
