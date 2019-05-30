using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    class Tank : IVehicle
    {
        //Propterties
        public int DistanceTraveled { get; }

        //Constructor 
        public Tank()
        {
            DistanceTraveled = new Random().Next(10, 240);
        }

        //Implementation
        public double CalculateToll(int distance)
        {
            double toll = 0;
            return toll;

        }

        public override string ToString()
        {
            return "Tank        ";
        }
    }
}
