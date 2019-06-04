using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Exceptions
{
    public class OverdraftException : Exception
    {
        public double OverdraftAmount { get; } = 0.0;

        public OverdraftException(string message, double overdraftAmount)
            : base(message)
        {
            this.OverdraftAmount = overdraftAmount;
        }
    }
}
