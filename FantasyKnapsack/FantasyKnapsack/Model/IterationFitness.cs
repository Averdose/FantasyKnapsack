using FantasyKnapsack.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyKnapsack.Model
{
    public class IterationFitness : BindableBase
    {
        private int _fitness;
        private int _iteration;

        public int Fitness
        {
            get
            {
                return _fitness;
            }

            set
            {
                _fitness = value;
            }
        }

        public int Iteration
        {
            get
            {
                return _iteration;
            }

            set
            {
                _iteration = value;
            }
        }

        public IterationFitness(int iteration, int fitness)
        {
            Fitness = fitness;
            Iteration = iteration;
        }
    }
}
