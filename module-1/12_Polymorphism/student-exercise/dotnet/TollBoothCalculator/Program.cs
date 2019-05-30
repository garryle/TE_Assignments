using System;
using System.Collections.Generic;
using TollBoothCalculator.Classes;

namespace TollBoothCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicleList = new List<IVehicle>();
   
            vehicleList.Add(new Car(false));
            vehicleList.Add(new Car(true));
            vehicleList.Add(new Tank());
            vehicleList.Add(new Truck(4));
            vehicleList.Add(new Truck(6));
            vehicleList.Add(new Truck(8));

            Console.WriteLine("Vehicle\t\tDistance Traveled\tToll $");
            Console.WriteLine("------------------------------------------------");

            int totalMiles = 0;
            double tollBoothRevenue = 0;

            foreach (IVehicle vehicle in vehicleList)
            {
                totalMiles += vehicle.DistanceTraveled;
                double toll = vehicle.CalculateToll(vehicle.DistanceTraveled);
                tollBoothRevenue += toll;

                Console.WriteLine($"{vehicle.ToString()}\t\t{vehicle.DistanceTraveled}\t\t${string.Format("{0:0.00}", toll)}");
            }

            Console.WriteLine("\nTotal Miles:  " + totalMiles);
            Console.WriteLine($"Total Toll Booth Revenue:  ${string.Format("{0:0.00}", tollBoothRevenue)}");

            Console.ReadLine();

        }
    }
}
