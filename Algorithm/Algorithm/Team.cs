using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Team
    {
        private Player[] _players;
        private Random _random;
        public Player[] Players { get { return _players; } }
        public Team(Random random, int teamSize)
        {
            _players = new Player[teamSize];
            for(int i = 0; i < teamSize; i++)
            {
                _players[i] = new Player(random);
            }
            _random = random;
        }

        public Team(Player[] players, int indexToReplace, Player player, int teamSize)
        {
            _players = new Player[teamSize];
            for (int i = 0; i < teamSize; i++)
            {
                _players[i] = players[i];
            }
            _players[indexToReplace] = player;
        }

        public void Mutate()
        {
            int index = _random.Next(0, _players.Length - 1);
            var player = new Player(_random);
            _players[index] = player;
        }

    }
}
