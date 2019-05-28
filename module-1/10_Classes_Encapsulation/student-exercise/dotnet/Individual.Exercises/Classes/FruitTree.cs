using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class FruitTree
    {
        //Properities
        public string TypeOfFruit { get; }
        public int PiecesOfFruitLeft { get; private set; }

        //Methods
        public bool PickFruit(int numberOfPiecesToRemove)
        {
            if (PiecesOfFruitLeft == 0)
            {
                return false;
            }
            else
            {
                PiecesOfFruitLeft -= numberOfPiecesToRemove;
                return true;
            }
        }

    //Constructor
        public FruitTree(string typeOfFruit, int startingPiecesOfFruit)
        {
            TypeOfFruit = typeOfFruit;
            PiecesOfFruitLeft = startingPiecesOfFruit;
        }
    }
}
