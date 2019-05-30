using System;
using System.Collections.Generic;
using PostageCalculator.Classes;
namespace PostageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter weight of your shipment: ");
            string heaviness = Console.ReadLine();
            double weight = double.Parse(heaviness);

            Console.WriteLine("Is your weight in (p)ounds or (o)unces?");
            string weightType = Console.ReadLine();
            if (weightType.Equals("p"))
            {
                weight = weight * 16;
            }

            Console.WriteLine("How far is shipment traveling?");
            string miles = Console.ReadLine();
            int distance = int.Parse(miles);

            List<IDeliveryDriver> drivers = new List<IDeliveryDriver>();

            drivers.Add(new FirstClass());
            drivers.Add(new SecondClass());
            drivers.Add(new ThirdClass());
            drivers.Add(new FexEd());
            drivers.Add(new SpuFourDay());
            drivers.Add(new SpuTwoDay());
            drivers.Add(new SpuNextDay());

            Console.WriteLine("Delivery Method \t\t " + "$ cost");
            Console.WriteLine("--------------------------------------");
            foreach (IDeliveryDriver driver in drivers)
            {

                Console.ReadLine();
            }
        }
    }
}
