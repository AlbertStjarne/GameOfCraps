using System;
using System.Linq;

namespace _15_GameOfCraps.Properties
{
    public class Statistics
    {
        public static int[] Wins = new int[22];
        public static int[] Loses = new int[22];

        public double AverageLength()
        {
            double avg;
            int sumOfRounds = 0;

            for (int i = 1; i <= 21; i++)
            {
                sumOfRounds += (Wins[i] * i) + (Loses[i] * i);
            }

            avg = (sumOfRounds * 1.0) / (Wins.Sum() + Loses.Sum());
            return avg;
        }

        public void SetStats(int rounds, CrapsGame.GameStatus result)
        {
            if (result == CrapsGame.GameStatus.Win)
            {
                if (rounds <= 20)
                    Wins[rounds] += 1;
                else
                    Wins[21] += 1;
            }
            else if (result == CrapsGame.GameStatus.Lose)
            {
                if (rounds <= 20)
                    Loses[rounds] += 1;
                else
                    Loses[21] += 1; 
            }
        }

        public void DisplayStatistics()
        {
            double probability;
            double avg;

            for (int i = 1; i <= 21; i++)
            {
                if (i == 21)
                    Console.WriteLine($"Round 21 or more wins: {Wins[i]}");
                else
                    Console.WriteLine($"Round {i} wins: {Wins[i]}");
            }

            for (int i = 1; i <= 21; i++)
            {
                if (i == 21)
                    Console.WriteLine($"Round 21 or more loses: {Loses[i]}");
                else
                    Console.WriteLine($"Round {i} loses: {Loses[i]}");
            }

            probability = ProbabilityOfWinning();
            Console.WriteLine($"Chances of winning the game of Craps are {probability:P}");
            Console.WriteLine($"Average length of a game of Craps is {AverageLength():N2} rounds");
        }

        public double ProbabilityOfWinning()
        {
            return (Wins.Sum() * 1.0) / (Wins.Sum() + Loses.Sum());
        }
    }
}
