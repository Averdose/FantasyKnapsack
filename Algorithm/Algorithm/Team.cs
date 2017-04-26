using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Team : IComparable<Team>
    {
        private Player[] _players;
        private Random _random;
        private int _fitness;
        private int _cost;
        private int _budget;
        public int Cost { get { return _cost; } }
        public Player[] Players { get { return _players; } }
        public int Fitness { get { return _fitness; } set { _fitness = value; } }
        public Team(Random random, int teamSize, int budget)
        {
            int cost = budget + 1;
            while (cost > budget)
            {
                cost = 0;
                _players = new Player[teamSize];
                for (int i = 0; i < teamSize; i++)
                {
                    _players[i] = new Player(random);
                    cost += _players[i].Cost;
                }
            }
            //
            _fitness = -1;
            CalculateFitness();
            _random = random;
            _budget = budget;
            _cost = cost;
        }

        public Team(Player[] players, int indexToReplace, Player player, Random rnd, int teamSize, int budget)
        {
            _players = new Player[teamSize];
            int cost = 0;
            for (int i = 0; i < teamSize; i++)
            {
                _players[i] = players[i];
                cost += _players[i].Cost;
            }
            cost -= _players[indexToReplace].Cost;
            _players[indexToReplace] = player;
            cost += player.Cost;
            _fitness = -1;
            CalculateFitness();
            if(cost > budget)
            {
                _fitness = 0;
            }
            _budget = budget;
            _cost = cost;
            _random = rnd;
        }

        public void Mutate()
        {
            int index = _random.Next(0, _players.Length - 1);
            var player = new Player(_random);
            _cost -= _players[index].Cost;
            _players[index] = player;
            _cost += _players[index].Cost;
            if(_cost > _budget)
            {
                _fitness = 0;
            }
        }

        public void CalculateFitness()
        {
            if(_fitness == 0)
            {
                return;
            }
            int fitness = 0;
            for (int i = 0; i < _players.Length; i++)
            {
                fitness += _players[i].Average;
            }
            _fitness = fitness;
        }

        public int CompareTo(Team other)
        {
            if (_fitness < other.Fitness)
            {
                return -1;
            }
            else if(_fitness > other.Fitness)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
