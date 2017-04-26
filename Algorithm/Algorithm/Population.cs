using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Population
    {
        private List<Team> _teams;
        private readonly int _teamSize;
        private Random _random;
        public Population(int initialPopulation, Random random, int teamSize)
        {
            _teams = new List<Team>();
            for(int i = 0; i < initialPopulation; i++)
            {
                _teams.Add(new Team(random, teamSize));
            }
            _random = random;
            _teamSize = teamSize;
        }

        private Team CrossOver(Team teamA, Team teamB)
        {
            int indexA = _random.Next(0, _teamSize - 1);
            int indexB = _random.Next(0, _teamSize - 1);

            Player player = teamB.Players[indexB];

            return new Team(teamA.Players, indexA, player, _teamSize);
        }
    }
}
