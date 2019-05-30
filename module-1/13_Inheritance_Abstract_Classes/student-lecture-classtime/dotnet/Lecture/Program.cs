using Lecture.Farming;
using System;
using System.Collections.Generic;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
           //
            // OLD MACDONALD
            //
            Console.WriteLine("Old MacDonald had a farm ee ay ee ay oh");

            // Let's try singing about a bunch of Farm Animals
            List<ISingable> mcdsAnimals = new List<ISingable>();
            mcdsAnimals.Add(new Horse());
            mcdsAnimals.Add(new Pig());
            mcdsAnimals.Add(new Tractor());
            mcdsAnimals.Add(new MachoManRandySavage());
            mcdsAnimals.Add(new Duck());
            mcdsAnimals.Add(new Child());
            mcdsAnimals.Add(new Cat());

           
            //loop through our list and sing about each one
            foreach (ISingable item in mcdsAnimals)
            {
                Console.WriteLine("And on his farm there was a " + item.Name + " ee ay ee ay oh");
                Console.WriteLine("With a " + item.MakeSoundTwice() + " here and a " + item.MakeSoundTwice() + " there");
                Console.WriteLine("Here a " + item.MakeSoundOnce() + ", there a " + item.MakeSoundOnce() + " everywhere a " + item.MakeSoundTwice());
                Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                Console.WriteLine();
            }

            Console.WriteLine("**********WAKE UP********");
            //loop through our list and WAKE EVERYONE UP and sing about each one
            foreach (ISingable item in mcdsAnimals)
            {
                //if my item is a farm animal, let's wake it up
                if (item is FarmAnimal)
                {
                    ( (FarmAnimal) item).WakeUp();
                }
                Console.WriteLine("And on his farm there was a " + item.Name + " ee ay ee ay oh");
                Console.WriteLine("With a " + item.MakeSoundTwice() + " here and a " + item.MakeSoundTwice() + " there");
                Console.WriteLine("Here a " + item.MakeSoundOnce() + ", there a " + item.MakeSoundOnce() + " everywhere a " + item.MakeSoundTwice());
                Console.WriteLine("Old Macdonald had a farm, ee ay ee ay oh");
                Console.WriteLine();
            }


            Apple sellable = new Apple();
            sellable.Price = 5; 

            //how much is everything on old macdonalds farm
            Console.WriteLine("Item prices");
            foreach (ISingable item in mcdsAnimals)
            {
                if (item is FarmAnimal)
                {
                    Console.WriteLine("The price of " + item.Name + " is $" + ((FarmAnimal)item).Price);
                }
            }

            

            Console.ReadLine();
        }
    }
}