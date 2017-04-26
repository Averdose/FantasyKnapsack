using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public struct Player
    {
        private int _speed;
        private int _dribbling;
        private int _defence;
        private int _passing;
        private int _shooting;
        private int _cost;
        private int _average;

        public int Average { get { return _average; } set { _average = value; } }
        public Player(Random random)
        {
            _speed = random.Next(0, 100);
            _dribbling = random.Next(0, 100);
            _defence = random.Next(0, 100);
            _passing = random.Next(0, 100);
            _shooting = random.Next(0, 100);
            _cost = random.Next(2000, 8000);
            _average = 0;
            CalculateAverage();
        }

        private void CalculateAverage()
        {
            _average = (_speed + _dribbling + _dribbling + _passing + _shooting) / 5;
        }

    }
}
