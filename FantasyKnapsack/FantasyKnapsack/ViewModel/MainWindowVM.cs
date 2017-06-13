using FantasyKnapsack.Model;
using FantasyKnapsack.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyKnapsack.ViewModel
{
    public class MainWindowVM : BindableBase
    {
        #region Fields

        private Team _choosenTeam;
        private Team _winningTeam;
        private BindableCollection<Team> _teamsList;
        private BindableCollection<IterationFitness> _iterationFitnessList;

        private InitialState _startState;

        private AsyncRelayCommand _startAlgorithmCommand;
        private AsyncRelayCommand _loadCommand;

        List<List<Player>> playerPopulation;
        private string _currentStatus;
        private int _currentIteration;

        #endregion

        #region Getters&Setters
        public Team ChoosenTeam
        {
            get
            {
                return _choosenTeam;
            }

            set
            {
                _choosenTeam = value;
                Notify();
            }
        }

        public Team WinningTeam
        {
            get
            {
                return _winningTeam;
            }

            set
            {
                _winningTeam = value;
                Notify();
            }
        }

        public BindableCollection<Team> TeamsList
        {
            get
            {
                return _teamsList;
            }

            set
            {
                _teamsList = value;
                Notify();
            }
        }

        public InitialState StartState
        {
            get
            {
                return _startState;
            }

            set
            {
                _startState = value;
                Notify();
            }
        }

        public AsyncRelayCommand StartAlgorithmCommand
        {
            get
            {
                return _startAlgorithmCommand;
            }

            set
            {
                _startAlgorithmCommand = value;
            }
        }

        public string CurrentStatus
        {
            get
            {
                return _currentStatus;
            }

            set
            {
                _currentStatus = value;
                Notify();
            }
        }

        public int CurrentIteration
        {
            get
            {
                return _currentIteration;
            }

            set
            {
                _currentIteration = value;

            }
        }

        public AsyncRelayCommand LoadCommand
        {
            get
            {
                return _loadCommand;
            }

            set
            {
                _loadCommand = value;
            }
        }

        public BindableCollection<IterationFitness> IterationFitnessList
        {
            get
            {
                return _iterationFitnessList;
            }

            set
            {
                _iterationFitnessList = value;
                Notify();
            }
        }

        #endregion



        public MainWindowVM()
        {
            CurrentStatus = "WAITING...";
            CurrentIteration = 0;
            playerPopulation = new List<List<Player>>();
            StartState = new InitialState();
            ChoosenTeam = null;
            WinningTeam = null;
            TeamsList = new BindableCollection<Team>();
            IterationFitnessList = new BindableCollection<IterationFitness>();
            StartAlgorithmCommand = new AsyncRelayCommand(execute => ControlAlgorithm(), canExecute => true);
            LoadCommand = new AsyncRelayCommand(execute => Load(), canExecute => true);
        }

        private async Task ControlAlgorithm()
        {
            if (playerPopulation.Count == 0)
            {
                Load();
            }
            Random random = new Random();
            IterationFitnessList.Clear();
            Population population = new Population(StartState.SizeOfPopulation, playerPopulation, random, 11, StartState.Budget, StartState.MutationsNumber, StartState.BestTeamsToCrossOver);
            ChoosenTeam = population.Evolve(StartState.IterationsNumber, playerPopulation, IterationFitnessList);
            TeamsList.Clear();
            var list = population.Teams.Skip(population.Teams.Count - 20).OrderByDescending(n => n.Fitness);
            foreach(var team in list)
            {
                TeamsList.Add(team);
            }
        }

        private async Task Load()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Files | *.csv";
            string csvFilePath = "";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                csvFilePath = dlg.FileName;
            }
            CsvReader reader = new CsvReader();
            try
            {
                playerPopulation = reader.ReadCsv(csvFilePath);
            }catch(Exception e)
            { }
        }
    }
}
