using System;
using _15_GameOfCraps.Properties;

namespace _15_GameOfCraps
{
    public class CrapsGame
    {

        private enum DiceSum
        {
            SnakeEyes = 2,
            Trey = 3,
            Seven = 7,
            YoLeven = 11,
            BoxCars = 12
        };

        private enum GameStatus
        {
            Win,
            Lose,
            Continue
        };

        private RollDice _roll = new RollDice();
        private GameStatus _gameStatus;
        private DiceSum _diceSum;
        private int _numRolls;
        private int _sum;
        private int _point;


        private void EvaluateRoll()
        {
            switch (_sum)
            {
                case 7:
                    _diceSum = DiceSum.Seven;
                    _gameStatus = GameStatus.Win;
                    _point = 0;
                    break;
                case 11:
                    _diceSum = DiceSum.YoLeven;
                    _gameStatus = GameStatus.Win;
                    _point = 0;
                    break;
                case 2:
                    _diceSum = DiceSum.SnakeEyes;
                    _gameStatus = GameStatus.Lose;
                    _point = 0;
                    break;
                case 3:
                    _diceSum = DiceSum.Trey;
                    _gameStatus = GameStatus.Lose;
                    _point = 0;
                    break;
                case 12:
                    _diceSum = DiceSum.BoxCars;
                    _gameStatus = GameStatus.Lose;
                    _point = 0;
                    break;
                default:
                    _gameStatus = GameStatus.Continue;
                    _point = _sum;
                    break;

            }
        }

        private void DisplayMessage()
        {
            switch (_gameStatus)
            {
                case GameStatus.Win:
                    Console.WriteLine(_numRolls == 1
                    ? $"Congratulations, you rolled {_diceSum}. YOU WIN!"
                    : $"Congratulations, you rolled {_sum}. YOU WIN!");
                    break;
                case GameStatus.Lose:
                    Console.WriteLine(_numRolls == 1
                    ? $"Sorry, you rolled {_diceSum}. YOU LOSE!"
                    : $"Sorry, you rolled {_sum}. YOU LOSE!");
                    break;
                default:
                    Console.WriteLine($"You rolled {_sum}. Your point is {_point}. Keep rolling!");
                    break;
            }
        }


        public void Play()
        {
            _sum = _roll.DiceRoll();
            _numRolls++;
            EvaluateRoll();
            DisplayMessage();

            while (_gameStatus == GameStatus.Continue)
            {
                KeepPlaying();
                DisplayMessage();
            }
        }

        private void KeepPlaying()
        {
            _sum = _roll.DiceRoll();
            _numRolls++;

            if (_sum == _point)
                _gameStatus = GameStatus.Win;
            else if (_sum == 7)
                _gameStatus = GameStatus.Lose;
            else
                _gameStatus = GameStatus.Continue;
        }

    }
}
