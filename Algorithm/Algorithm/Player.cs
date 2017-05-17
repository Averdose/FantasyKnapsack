using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Algorithm
{
    public struct Player
    {

        private int _position;
        private long _id;
        private int _speed;
        private int _dribbling;
        private int _defence;
        private int _passing;
        private int _shooting;
        private int _cost;
        private int _average;
        public int Position { get { return _position; } }
        public long Id { get { return _id; } }
        public int Average { get { return _average; } set { _average = value; } }
        public int Cost { get { return _cost; } set { _cost = value; } }
        //this player will have random values of skills
        //in further version this data will be read from a file
        public Player(long id, int speed, int dribbling, int defence, int passing, int shooting, int cost, int position)
        {
            _id = id;
            _speed = speed;
            _dribbling = dribbling;
            _defence = defence;
            _passing = passing;
            _shooting = shooting;
            _cost = cost;
            _position = position;
            _average = 0;
            CalculateAverage();
        }
        public Player(Random random, long id, int position)
        {
            _position = position;
            _id = id;
            _speed = random.Next(0, 100);
            _dribbling = random.Next(0, 100);
            _defence = random.Next(0, 100);
            _passing = random.Next(0, 100);
            _shooting = random.Next(0, 100);
            _cost = random.Next(2000, 8000);
            _average = 0;
            CalculateAverage();
        }
    
        //each skill is treated equally so this is a simple average
        //depending on the position respective skills can be weighted apropiately
        private void CalculateAverage()
        {
            //_average = (_speed + _dribbling + _defence + _passing + _shooting) / 5;
            if (_position == 0)
            {
                _average = (int)(_speed * 0.15 + _dribbling * 0.075 + _defence * 0.4 + _passing * 0.3 + _shooting * 0.075);
            }
            else if (_position < 5)
            {
                _average = (int)(_speed * 0.3 + _dribbling * 0.05 + _defence * 0.3 + _passing * 0.3 + _shooting * 0.05);
            }
            else if (_position < 9)
            {
                _average = (int)(_speed * 0.2 + _dribbling * 0.2 + _defence * 0.2 + _passing * 0.2 + _shooting * 0.2);
            }
            else
            {
                _average = (int)(_speed * 0.2 + _dribbling * 0.2 + _defence * 0.05 + _passing * 0.15 + _shooting * 0.4);
            }
        }

    }
}
