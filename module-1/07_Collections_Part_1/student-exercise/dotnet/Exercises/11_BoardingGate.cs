using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given a list of Integers representing seat numbers, group them into ranges 1-10, 11-20, and 21-30.
         (Any seat number less than 1, or greater than 30 is invalid, and can be ignored.) Preserve the order
         in which the seat number entered their associated group. Return a list of the grouped Integers 1-10,
         11-20, and 21-30. (Hint: Think multiple queues)
         DIFFICULTY: HARD
		 BoardingGate( [1, 13, 43, 22, 8, 11, 30, 2, 4, 14, 21] ) -> [1, 8, 2, 4, 13, 11, 14, 22, 30, 21]
         BoardingGate( [29, 19, 9, 21, 11, 1, 0, 25, 15, 5, 31] ) -> [9, 1, 5, 19, 11, 15, 29, 21, 25]
         BoardingGate( [0, -1, 44, 31, 17, 7, 27, 16, 26, 6] ) -> [7, 6, 17, 16, 27, 26]
         */
        public List<int> BoardingGate(List<int> seatNumberList)
        {
            //create list to return
            List<int> allSeats = new List<int>();

            //create a list for each queue
            List<int> lowSeats = new List<int>(); // holds seats 1-10
            List<int> midSeats = new List<int>(); // hold seats 11-20
            List<int> highSeats = new List<int>(); // hold seats 21 - 30

            //go through seat number list and put each item into appropirate queue
            foreach (int seatNumber in seatNumberList)
            {
                if (seatNumber > 0 && seatNumber <= 30)
                {
                    if (seatNumber <= 10)
                    {
                        lowSeats.Add(seatNumber);
                    }
                    else if (seatNumber <= 20)
                    {
                        midSeats.Add(seatNumber);
                    }
                    else
                    {
                        highSeats.Add(seatNumber);
                    }
                }
            }
            //combine the queues back together and return
            allSeats.AddRange(lowSeats);
            allSeats.AddRange(midSeats);
            allSeats.AddRange(highSeats);

            return allSeats;
        }

    }
}
