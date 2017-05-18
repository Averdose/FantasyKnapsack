using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // generate random teams with random players
            // 
            // while still iterating and fitness is below threshold:
            //      evaluate fitness for each team and sort them
            //      get x best teams
            //      crossover them creating new teams
            //      mutate to create new teams
            //      remove y worst teams
            //      insert best new teams
            string csvFilePath = "../../../../Documentation/playerPopulation.csv";
            CsvReader reader = new CsvReader();
            List<List<Player>> playerPopulation = reader.ReadCsv(csvFilePath);
            int populationSize = 5000;
            int teamSize = 11;
            int budget = 15000;
            double mutationChance = 0.02;
            int iterationCount = 400;
            Random random = new Random();
            //Population population = new Population(populationSize, random, teamSize, budget, mutationChance);
            Population population = new Population(populationSize, playerPopulation, random, teamSize, budget, mutationChance);
            Console.WriteLine("Population : {0}",populationSize);
            Console.WriteLine("Teams : {0}", teamSize);
            Console.WriteLine("Budget : {0}", budget);
            Console.WriteLine("Mutation chance : {0}", mutationChance);
            Console.WriteLine("Iterations count : {0}", iterationCount);
            Team winner = population.Evolve(iterationCount, playerPopulation);
            Console.WriteLine("the winners fitness is {0} and cost is {1}", winner.Fitness, winner.Cost);
            ListWinnerTeam(winner);
            Console.ReadLine();
        }

        private static void ListWinnerTeam(Team winner)
        {
            for (int i = 0; i < winner.Players.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Goalkeeper: {0} {1} has fitness {2} and cost {3} and id {4}", winner.Players[i].Name, winner.Players[i].Surname, winner.Players[i].Average, winner.Players[i].Cost, winner.Players[i].Id);
                }
                else if (i < 5)
                {
                    Console.WriteLine("Defence: {0} {1} has fitness {2} and cost {3}  id {4}", winner.Players[i].Name, winner.Players[i].Surname, winner.Players[i].Average, winner.Players[i].Cost, winner.Players[i].Id);
                }
                else if (i < 9)
                {
                    Console.WriteLine("Midfield: {0} {1} has fitness {2} and cost {3}  id {4}", winner.Players[i].Name, winner.Players[i].Surname, winner.Players[i].Average, winner.Players[i].Cost, winner.Players[i].Id);
                }
                else
                {
                    Console.WriteLine("Attack: {0} {1} has fitness {2} and cost {3}  id {4}", winner.Players[i].Name, winner.Players[i].Surname, winner.Players[i].Average, winner.Players[i].Cost, winner.Players[i].Id);
                }
            }
        }
    }
}
