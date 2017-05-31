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
        private AsyncRelayCommand _showBestCommand;
        private AsyncRelayCommand _showWorstCommand;

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

        public AsyncRelayCommand ShowBestCommand
        {
            get
            {
                return _showBestCommand;
            }

            set
            {
                _showBestCommand = value;
            }
        }

        public AsyncRelayCommand ShowWorstCommand
        {
            get
            {
                return _showWorstCommand;
            }

            set
            {
                _showWorstCommand = value;
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

        #endregion



        public MainWindowVM()
        {
            CurrentStatus = "PAUSED";
            CurrentIteration = 0;
            StartState = new InitialState();
            ChoosenTeam = new Team();
            WinningTeam = new Team();
            TeamsList = new BindableCollection<Team>();
            StartAlgorithmCommand = new AsyncRelayCommand(execute => ControlAlgorithm(), canExecute => true);
        }

        private async Task ControlAlgorithm()
        {

        }

    }
}
