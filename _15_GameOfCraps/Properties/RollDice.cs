using System;
namespace _15_GameOfCraps.Properties
{
    public class RollDice
    {
        private Random _rand = new Random();
        public int Die1 { get; set; }
        public int Die2 { get; set; }

        public int DiceRoll()
        {
            Die1 = _rand.Next(1, 7);
            Die2 = _rand.Next(1, 7);

            return Die1 + Die2;
        }
    }
}
