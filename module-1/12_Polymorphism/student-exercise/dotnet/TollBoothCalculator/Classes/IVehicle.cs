using System;
using System.Collections.Generic;
using System.Text;

namespace TollBoothCalculator.Classes
{
    public interface IVehicle
    {
        int DistanceTraveled { get; }
        

        //Method
        double CalculateToll(int distance);
    }
}
