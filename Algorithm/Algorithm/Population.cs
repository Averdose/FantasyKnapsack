using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Population
    {
        private int _budget;
        private double _mutateChance;
        private List<Team> _teams;
        private readonly int _teamSize;
        private Random _random;
        public Population(int initialPopulation, Random random, int teamSize, int budget, double mutateChance)
        {
            _teams = new List<Team>();
            for(int i = 0; i < initialPopulation; i++)
            {
                _teams.Add(new Team(random, teamSize, budget));
            }
            _random = random;
            _teamSize = teamSize;
            _budget = budget;
            _mutateChance = mutateChance;
        }

        private Team CrossOver(Team teamA, Team teamB)
        {
            int indexA = _random.Next(0, _teamSize - 1);
            int indexB = _random.Next(0, _teamSize - 1);

            Player player = teamB.Players[indexB];

            return new Team(teamA.Players, indexA, player, _random, _teamSize, _budget);
        }

        public Team evolve(int iterations)
        {
            int deathZone = (int)(0.1 * _teams.Count);
            for (int i =0; i < iterations; i++)
            {
                
                foreach (var team in _teams)
                {
                    if(_random.NextDouble() < _mutateChance)
                    {
                        team.Mutate();
                    }
                }
                foreach (var team in _teams)
                {
                    team.CalculateFitness();
                }
                _teams.Sort();
                Console.WriteLine("best fitness in iteration {0} is {1} with cost {2}", i, _teams[_teams.Count - 1].Fitness, _teams[_teams.Count - 1].Cost);

                //kill the worst
                _teams.RemoveRange(0, deathZone);
                //breed the best
                for(int j = 0; j < deathZone; j++)
                {
                    int teamA = _random.Next(_teams.Count - deathZone - 1, _teams.Count - 1);
                    int teamB = _random.Next(_teams.Count - deathZone - 1, _teams.Count - 1);
                    if(teamA == teamB)
                    {
                        teamB = (teamB + 1) % deathZone;
                    }
                    _teams.Add(CrossOver(_teams[teamA], _teams[teamB]));
                }
            }
            return _teams[_teams.Count -1];
        }
    }
}
