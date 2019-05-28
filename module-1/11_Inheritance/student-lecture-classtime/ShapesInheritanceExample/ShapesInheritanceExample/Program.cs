using ShapesInheritanceExample.Classes;
using System;

namespace ShapesInheritanceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Shape mySquare = new Shape(4);
            Console.WriteLine(mySquare.Color);
            mySquare.ChangeToPurple();
            Console.WriteLine(mySquare.Color);

            Shape fred = new Rhombus();
            Console.WriteLine("Fred's color is "+ fred.Color);


            Shape wilma = new Triangle("equilateral");
            Console.WriteLine("wilma's color is " + wilma.Color);
            Console.WriteLine("wilma is of triangle type "+  ((Triangle)wilma).TriangleType);

            Triangle et = new EquilateralTriangle();
            et.ChangeToOrange();
            Console.WriteLine("et's color is " + et.Color);
            Console.WriteLine("et is of triangle type " + et.TriangleType);

            Console.ReadLine();
        }
    }
}
