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
            int populationSize = 500;
            int teamSize = 11;
            int budget = 55000;
            double mutationChance = 0.02;
            int iterationCount = 1000;
            Random random = new Random();
            Population population = new Population(populationSize, random, teamSize, budget, mutationChance);
            Console.WriteLine("Population : {0}",populationSize);
            Console.WriteLine("Teams : {0}", teamSize);
            Console.WriteLine("Budget : {0}", budget);
            Console.WriteLine("Mutation chance : {0}", mutationChance);
            Console.WriteLine("Iterations count : {0}", iterationCount);
            Team winner = population.evolve(iterationCount);
            Console.WriteLine("the winners fitness is {0} and cost is {1}", winner.Fitness, winner.Cost);
            for (int i =0; i< winner.Players.Length; i++)
            {
                Console.WriteLine("player of winning team has fitness {0} and cost {1}", winner.Players[i].Average, winner.Players[i].Cost);
            }
        }
    }
}
