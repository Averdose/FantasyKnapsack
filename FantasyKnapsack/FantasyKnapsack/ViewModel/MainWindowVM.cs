using FantasyKnapsack.Model;
using FantasyKnapsack.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyKnapsack.ViewModel
{
    public class MainWindowVM
    {
        #region Fields

        private Team _choosenTeam;
        private Team _winningTeam;
        private BindableCollection<Team> _teamsList;

        private InitialState _startState;

        private AsyncRelayCommand _startAlgorithmCommand;
        private AsyncRelayCommand _loadCommand;

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

        #endregion



        public MainWindowVM()
        {
            CurrentStatus = "PAUSED";
            CurrentIteration = 0;
            StartState = new InitialState();
            ChoosenTeam = null;
            WinningTeam = null;
            TeamsList = new BindableCollection<Team>();
            StartAlgorithmCommand = new AsyncRelayCommand(execute => ControlAlgorithm(), canExecute => true);
            LoadCommand = new AsyncRelayCommand(execute => Load(), canExecute => true)
        }

        private async Task ControlAlgorithm()
        {

        }

        private async Task Load()
        {

        }
    }
}
