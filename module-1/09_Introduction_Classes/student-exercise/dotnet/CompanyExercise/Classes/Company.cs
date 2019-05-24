using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Company
    {
        //name, string, get, no set
        public string Name { get; set; }
        //Number of Employees, int, get, set
        public int NumberOfEmployees { get; set; }
        //revenue, decimal, get, set
        public decimal Revenue { get; set; }
        //expenses, decimal, get, set
        public decimal Expenses { get; set; }

        //Methods
        public string GetCompanySize()
        {
            if (NumberOfEmployees <= 49)
            {
                return "small";
            }
            else if (NumberOfEmployees >= 50 && NumberOfEmployees <= 250)
            {
                return "medium";
            }
            else
                return "large";
        }

        public decimal GetProfit()
        {
            decimal profit = Revenue - Expenses;
            return profit;
        }

    }

}
