using System;
using System.Linq;

namespace RunUpTheStairs
{
    public class Program
    {
        /// <summary>
        /// Constant that represents the steps required to complete a turn.
        /// </summary>
        private const int NoOfStepsAtTurn = 2;

        /// <summary>
        /// Calculates the number of steps needed to climb a stairway.
        /// </summary>
        /// <param name="flights">Number of flights</param>
        /// <param name="stepsPerStride">Steps per stride</param>
        /// <returns>Returns an int representing the number of setps needed to climb the stairway</returns>
        public int CalculateNumberOfStepsNeeded(int[] flights, int stepsPerStride)
        {
            var result = 0;

            if (flights == null)
            {
                throw new ArgumentNullException(nameof(flights));
            }

            if (!(flights.Length >= 1 && flights.Length <= 50))
            {
                throw new ArgumentException("No.of flights should be between 1 and 50 inclusive");
            }

            if (!(stepsPerStride >= 2 && stepsPerStride <= 5))
            {
                throw new ArgumentException("Invalid number of steps per stride");
            }

            foreach (var flight in flights)
            {
                if (!(flight>= 5 && flight<= 30))
                {
                    throw new ArgumentException($"Invalid number of steps for flight {flight}");
                }

                result = result + (flight)/stepsPerStride + ((flight % stepsPerStride) > 0 ? 1 : 0);
            }

            result = result + (flights.Length - 1) * NoOfStepsAtTurn;

            return result;
        }

       static void Main()
        {
            var p = new Program();

            //A stairway is made up of a series of flights
            //each flight contains a set of steps
            var flights = new[] { 5, 11, 9, 13, 8, 30, 14 };

            //Steps per stride
            var stepsPerStride = 3;

            Console.WriteLine($"Number of steps need to climb the stairway {string.Join(",", flights.ToList())} with {stepsPerStride} steps per stride is " +
                 $"{p.CalculateNumberOfStepsNeeded(flights, stepsPerStride)}");

            Console.Read();
        }
    }
}
