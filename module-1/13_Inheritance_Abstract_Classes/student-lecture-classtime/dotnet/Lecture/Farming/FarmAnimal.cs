using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public abstract class FarmAnimal : ISingable, ISellable
    {       
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }

        public double Price { get; protected set; }

        protected bool IsAwake { get; private set; }

        public void WakeUp()
        {
            IsAwake = true;
        }

        public void GoToBed()
        {
            IsAwake = false;
        }


        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        public FarmAnimal(string name)
        {
            this.Name = name;
            this.IsAwake = true;
        }

        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        public FarmAnimal(string name, bool isAwake)
        {
            this.Name = name;
            this.IsAwake = isAwake; 
        }


        public string MakeSoundOnce()
        {
            string sound;
            if (IsAwake)
            {
                sound = MakeAwakeSoundOnce();
            }
            else
            {
                sound = "zzzzz";
            }

            return sound;
        }

        public string MakeSoundTwice()
        {
            string sound;
            if (IsAwake)
            {
                sound = MakeAwakeSoundTwice();
            }
            else
            {
                sound = "zzzzz";
            }

            return sound;
        }

        /// <summary>
        /// The noise made when the farm animal makes a sound.
        /// </summary>
        /// <returns></returns>
        protected abstract string MakeAwakeSoundOnce();


        /// <summary>
        /// The noise made when the farm animal makes its sound twice.
        /// </summary>
        /// <returns></returns>
        protected abstract string MakeAwakeSoundTwice();

        //public abstract void eat(string food);
       
    }
}
