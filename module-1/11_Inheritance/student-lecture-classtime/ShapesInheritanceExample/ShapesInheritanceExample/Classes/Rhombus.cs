using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesInheritanceExample.Classes
{
    class Rhombus : Shape
    {
        public Rhombus(): base (4)
        {
            ChangeToOrange(); 
        }
    }
}
