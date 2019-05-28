using ShapesInheritanceExample.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesInheritanceExample
{
    class Triangle : Shape
    {
        /// <summary>
        /// isoceles, equilateral, scalene
        /// </summary>
        public string TriangleType { get; }

        public Triangle(string type):base(3)
        {
            TriangleType = type; 
        }
    }
}
