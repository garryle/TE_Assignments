using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    public class Truck : IVehicle
    {
        //Properties
        public int NumberOfAxles { get; }
        public int DistanceTraveled { get; }

        //Constructor
        public Truck(int numberOfAxles)
        {
            NumberOfAxles = numberOfAxles;
            DistanceTraveled = new Random().Next(10, 240);
        }

        //Implementation
        public double CalculateToll(int distance)
        {
            double ratePerMile = 0;
            double toll = 0;

            if (this.NumberOfAxles == 4)
            {
                ratePerMile = 0.040;
                toll = ratePerMile * distance;
            }
            else if (NumberOfAxles == 6)
            {
                ratePerMile = 0.045;
                toll = ratePerMile * distance;
            }
            else if (NumberOfAxles == 8 || NumberOfAxles > 8)
            {
                ratePerMile = 0.048;
                toll = ratePerMile * distance;
            }
            return toll;
        }

        public override string ToString()
        {
            if (NumberOfAxles == 4)
            {
                return "Truck(4)Axels";
            }
            else if (NumberOfAxles == 6)
            {
                return "Truck(6)Axels";
            }
            else
            {
                return "Truck(8)Axels";
            }
        }
    }
}
