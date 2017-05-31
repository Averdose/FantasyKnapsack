using FantasyKnapsack.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FantasyKnapsack
{
    public class Player : BindableBase
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
        private string _name;
        private string _surname;
        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public int Position { get { return _position; } set { _position = value; } }
        public long Id { get { return _id; } set { _id = value; } }
        public int Average { get { return _average; } set { _average = value; } }
        public int Cost { get { return _cost; } set { _cost = value; } }

        public int Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

        public int Dribbling
        {
            get
            {
                return _dribbling;
            }

            set
            {
                _dribbling = value;
            }
        }

        public int Defence
        {
            get
            {
                return _defence;
            }

            set
            {
                _defence = value;
            }
        }

        public int Passing
        {
            get
            {
                return _passing;
            }

            set
            {
                _passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return _shooting;
            }

            set
            {
                _shooting = value;
            }
        }

        //this player will have random values of skills
        //in further version this data will be read from a file
        public Player()
        {

        }
        public Player(long id, int speed, int dribbling, int defence, int passing, int shooting, int cost, int position, string name, string surname)
        {
            Id = id;
            Speed = speed;
            Dribbling = dribbling;
            Defence = defence;
            Passing = passing;
            Shooting = shooting;
            Cost = cost;
            Position = position;
            Name = name;
            Surname = surname;
            Average = 0;
            CalculateAverage();
        }
        public Player(Random random, long id, int position)
        {
            _position = position;
            _id = id;
            Speed = random.Next(0, 100);
            Dribbling = random.Next(0, 100);
            Defence = random.Next(0, 100);
            Passing = random.Next(0, 100);
            Shooting = random.Next(0, 100);
            _cost = random.Next(2000, 8000);
            _name = id.ToString();
            _surname = id.ToString() + "surname";
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
                _average = (int)(Speed * 0.15 + Dribbling * 0.075 + Defence * 0.4 + Passing * 0.3 + Shooting * 0.075);
            }
            else if (_position < 5)
            {
                _average = (int)(Speed * 0.3 + Dribbling * 0.05 + Defence * 0.3 + Passing * 0.3 + Shooting * 0.05);
            }
            else if (_position < 9)
            {
                _average = (int)(Speed * 0.2 + Dribbling * 0.2 + Defence * 0.2 + Passing * 0.2 + Shooting * 0.2);
            }
            else
            {
                _average = (int)(Speed * 0.2 + Dribbling * 0.2 + Defence * 0.05 + Passing * 0.15 + Shooting * 0.4);
            }
        }

    }
}
