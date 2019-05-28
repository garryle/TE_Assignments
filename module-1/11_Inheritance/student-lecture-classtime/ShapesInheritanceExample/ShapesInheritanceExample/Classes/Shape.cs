using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesInheritanceExample.Classes
{
    class Shape
    {       
        public int NumberOfSides {get; private set; }
        private int myColor; 
        public string Color
        {
            get
            {
                return colors[myColor];
            }
        }
        private Dictionary<int, string> colors = new Dictionary<int, string>();

        public bool IsFilled { get; private set; }

        public Shape()
        {
            colors.Add(0, "red");
            colors.Add(1, "blue");
            colors.Add(2, "green");
            colors.Add(3, "orange");
            colors.Add(4, "purple");
            colors.Add(5, "yellow");
        }

        public Shape(int numSides) : this()
        {       
            NumberOfSides = numSides;
            myColor = 0;
        }


        public void ChangeToPurple()
        {
            myColor = 4; 
        }
        public void ChangeToOrange()
        {
            myColor = 3;
        }


    }
}
