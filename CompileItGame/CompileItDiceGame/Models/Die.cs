﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CompileIt
{
    [Serializable]
    public abstract class Die
    {
        public const string GreenDie = "Green";
        public const string YellowDie = "Yellow";
        public const string RedDie = "Red";

        protected List<CompileType> _dieSides = new List<CompileType>();
        
        public DieType Type { get; }
        public int NumberOfSides
        {
            get
            {
                return _dieSides.Count;
            }
        }
        public string TypeName
        {
            get
            {
                return Type.ToString();
            }
        }
        public List<string> SideNames
        {
            get
            {
                List<string> result = new List<string>();
                foreach (var side in _dieSides)
                {
                    result.Add(side.ToString());
                }
                return result;
            }
        }

        /// <summary>
        /// Create a die of the specified type
        /// </summary>
        /// <param name="type"></param>
        public Die(DieType type)
        {
            Type = type;
            CreateDie();
        }

        /// <summary>
        /// Forces sub-classes to implement this method with the appropriate die compile types
        /// </summary>
        protected abstract void CreateDie();

        /// <summary>
        /// Rolls the die and returns a randomly generated compile type from the die
        /// </summary>
        /// <returns></returns>
        public CompileType Roll(Random dieRoller)
        {
            // This simulates a six sided die
            int side = dieRoller.Next(0, 5);
            return _dieSides[side];
        }
    }
}
