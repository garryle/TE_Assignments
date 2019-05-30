using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public class Horse : FarmAnimal, ISellable
    {
        /// <summary>
        /// Creates a new horse.
        /// </summary>
        /// <param name="name">The name which the horse goes by.</param>
        public Horse() : base("HORSE",false)
        {
            Price = 1000; 
        }

        /// <summary>
        /// The single noise the horse makes.
        /// </summary>
        /// <returns></returns>
        protected override string MakeAwakeSoundOnce()
        {
            return "NEIGH";
        }

        /// <summary>
        /// The double noise the horse makes.
        /// </summary>
        /// <returns></returns>
        protected override string MakeAwakeSoundTwice()
        {
            return "NEIGH NEIGH";
        }
    }
}
