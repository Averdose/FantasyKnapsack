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
            int budget = 55000;
            double mutationChance = 0.02;
            int iterationCount = 100;
            Random random = new Random();
            //Population population = new Population(populationSize, random, teamSize, budget, mutationChance);
            Population population = new Population(populationSize, playerPopulation, random, teamSize, budget, mutationChance);
            Console.WriteLine("Population : {0}",populationSize);
            Console.WriteLine("Teams : {0}", teamSize);
            Console.WriteLine("Budget : {0}", budget);
            Console.WriteLine("Mutation chance : {0}", mutationChance);
            Console.WriteLine("Iterations count : {0}", iterationCount);
            Team winner = population.Evolve(iterationCount);
            Console.WriteLine("the winners fitness is {0} and cost is {1}", winner.Fitness, winner.Cost);
            for (int i =0; i< winner.Players.Length; i++)
            {
                Console.WriteLine("player of winning team has fitness {0} and cost {1}, id: {2}", winner.Players[i].Average, winner.Players[i].Cost, winner.Players[i].Id);
            }
            Console.ReadLine();
        }
    }
}
