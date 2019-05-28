using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Airplane
    {
        //Properties
        public string PlaneNumber { get; }
        public int BookedFirstClassSeats { get; private set; }
        public int TotalFirstClassSeats { get; }
        public int BookedCoachSeats { get; private set; }
        public int TotalCoachSeats { get; }


        public int AvailableFirstClassSeats
        {
            get
            {
               return TotalFirstClassSeats - BookedFirstClassSeats;
            }
        }
        public int AvailableCoachSeats
        {
            get
            {
                return TotalCoachSeats - BookedCoachSeats;
            }
        }

        //Constructors
        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {
            PlaneNumber = planeNumber;
            TotalFirstClassSeats = totalFirstClassSeats;
            TotalCoachSeats = totalCoachSeats;
        }

        //Methods
        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            bool isSuccessReservation = false;

            if (forFirstClass == true)
            {
                if (totalNumberOfSeats <= AvailableFirstClassSeats)
                {
                    BookedFirstClassSeats += totalNumberOfSeats;
                    isSuccessReservation = true;
                }
            }
            else if (forFirstClass == false)
            {
                if (totalNumberOfSeats <= AvailableCoachSeats)
                {
                    BookedCoachSeats += totalNumberOfSeats;
                    isSuccessReservation = true;
                }
            }
            return isSuccessReservation;
        }
    }
}