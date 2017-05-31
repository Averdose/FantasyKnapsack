using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyKnapsack.Model
{
    public class InitialState
    {
        #region Fields

        private int _sizeOfPopulation;
        private int _budget;
        private int _bestTeamsToCrossOver;
        private int _worstTeamToReject;
        private int _mutationsNumber;
        private int _crossoversNumber;
        private int _iterationsNumber;
        private int _fitnessThreshold;
        private bool _checkBothConditions;

        #endregion

        #region Getters&Setters
        public int SizeOfPopulation
        {
            get
            {
                return _sizeOfPopulation;
            }

            set
            {
                _sizeOfPopulation = value;
            }
        }

        public int Budget
        {
            get
            {
                return _budget;
            }

            set
            {
                _budget = value;
            }
        }

        public int BestTeamsToCrossOver
        {
            get
            {
                return _bestTeamsToCrossOver;
            }

            set
            {
                _bestTeamsToCrossOver = value;
            }
        }

        public int WorstTeamToReject
        {
            get
            {
                return _worstTeamToReject;
            }

            set
            {
                _worstTeamToReject = value;
            }
        }

        public int MutationsNumber
        {
            get
            {
                return _mutationsNumber;
            }

            set
            {
                _mutationsNumber = value;
            }
        }

        public int CrossoversNumber
        {
            get
            {
                return _crossoversNumber;
            }

            set
            {
                _crossoversNumber = value;
            }
        }

        public int IterationsNumber
        {
            get
            {
                return _iterationsNumber;
            }

            set
            {
                _iterationsNumber = value;
            }
        }

        public int FitnessThreshold
        {
            get
            {
                return _fitnessThreshold;
            }

            set
            {
                _fitnessThreshold = value;
            }
        }

        public bool CheckBothConditions
        {
            get
            {
                return _checkBothConditions;
            }

            set
            {
                _checkBothConditions = value;
            }
        }


        #endregion

        public InitialState()
        {
            SizeOfPopulation = 3000;
            Budget = 12000;
            BestTeamsToCrossOver = 20;
            WorstTeamToReject = 20;
            MutationsNumber = 10;
            CrossoversNumber = 10;
            IterationsNumber = 100;
            FitnessThreshold = 90;
            CheckBothConditions = false;
        }
    }
}
