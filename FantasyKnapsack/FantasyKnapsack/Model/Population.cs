using FantasyKnapsack.Model;
using FantasyKnapsack.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyKnapsack
{
    public class Population 
    {
        private double deletionCoef = 0.05;
        private long _playerCount;
        private int _budget;
        private double _mutateChance;
        private List<Team> _teams;
        private readonly int _teamSize;
        private Random _random;

        public List<Team> Teams
        {
            get
            {
                return _teams;
            }

            set
            {
                _teams = value;
            }
        }

        public Population(int initialPopulation, List<List<Player>> playerPopulation, Random random, int teamSize, int budget, double mutateChance, double deathRate)
        {
            this.deletionCoef = deathRate;
            _teams = new List<Team>();
            for (int i = 0; i < initialPopulation; i++)
            {
                _teams.Add(new Team(playerPopulation,random,teamSize,budget));
            }
            _random = random;
            _teamSize = teamSize;
            _budget = budget;
            _mutateChance = mutateChance;
            _playerCount = playerPopulation[0].Count + playerPopulation[1].Count + playerPopulation[2].Count + playerPopulation[3].Count;
        }
        private int GetSamePosition(int index)
        {
            int indexB = 0;

            if (index == 0)
            {
                return indexB;
            }
            else if (index < 5)
            {
                indexB = _random.Next(1, 5);
            }
            else if (index < 9)
            {
                indexB = _random.Next(5, 9);
            }
            else
            {
                indexB = _random.Next(9, 11);
            }

            return indexB;
        }
        private Team CrossOver(Team teamA, Team teamB)
        {
            int indexA = _random.Next(0, _teamSize);

            int indexB = GetSamePosition(indexA);

            Player player = teamB.Players[indexB];

            if (teamA.Players.Any(p => p.Id == player.Id))
            {
                return null;
            }
            return new Team(teamA.Players, indexA, player, _random, _teamSize, _budget);
        }

        public Team Evolve(int iterations, List<List<Player>> playerPopulation, BindableCollection<IterationFitness> iterationFitnessList)
        {
            int deathZone = (int)(deletionCoef * _teams.Count);
            for (int i =0; i < iterations && _teams.Count != 1; i++)
            {
                
                foreach (var team in _teams)
                {
                    if(_random.NextDouble() < _mutateChance)
                    {
                        team.Mutate(playerPopulation);
                        _playerCount++;
                    }
                }
                foreach (var team in _teams)
                {
                    team.CalculateFitness();
                }
                _teams.Sort();
                Console.WriteLine("best fitness in iteration {0} is {1} with cost {2}", i, _teams[_teams.Count - 1].Fitness, _teams[_teams.Count - 1].Cost);
                iterationFitnessList.Add(new IterationFitness(i, _teams[_teams.Count - 1].Fitness));
                //kill the worst
                _teams.RemoveRange(0, deathZone);
                deathZone = (int)(deletionCoef * _teams.Count);
                //breed the best
                for(int j = 0; j < deathZone; j++)
                {
                    int teamA = _random.Next(_teams.Count - deathZone - 1, _teams.Count - 1);
                    int teamB = _random.Next(_teams.Count - deathZone - 1, _teams.Count - 1);
                    if(teamA == teamB)
                    {
                        teamB = (teamB + 1) % deathZone;
                    }

                    var team = CrossOver(_teams[teamA], _teams[teamB]);
                    if (team != null)
                    {
                        _teams.Add(team);
                    }
                }
                Console.WriteLine("Teams Left : {0}", _teams.Count);
            }
            _teams.Sort();
            return _teams[_teams.Count -1];
        }


    }
}
