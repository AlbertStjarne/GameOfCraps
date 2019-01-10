using System;
using System.Linq;

namespace _15_GameOfCraps.Properties
{
    public class Statistics
    {
        public static int[] Wins = new int[22];
        public static int[] Loses = new int[22];

        public void DisplayStatistics()
        {
            double probability;
            probability = ProbabilityOfWinning();
            Console.WriteLine($"Chances of winning the game of Craps are {probability:P}");
        }

        public double ProbabilityOfWinning()
        {
            return (Wins.Sum() * 1.0) / (Wins.Sum() + Loses.Sum());
        }
    }
}
