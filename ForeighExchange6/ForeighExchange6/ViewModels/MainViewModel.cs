using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeighExchange6.ViewModels
{
    using System.Collections.ObjectModel;
    using Models;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;

    public class MainViewModel :  INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion

        #region Porperties
        public String Amount
        {
            get;
            set;
        }
        public ObservableCollection<Rate> Rates
        {
            get;
            set;
        }
        public Rate SourceRate
        {
            get;
            set;
        }
        public Rate TargetRate
        {
            get;
            set;
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                    _isRunning = value;
                    PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(IsRunning)));
            }
        }
        public bool iIsEnabled
        {
            get;
            set;
        }
        public String Result
        {
            get
            {
                return _result;
            }
            set
            {
                if (_result!= value)
                    _result = value;
                    PropertyChanged?.Invoke(
                    this,
                    new PropertyChangedEventArgs(nameof(_result)));
            }
        }
        #endregion

        #region Attributes
        bool _isRunning;
        string _result;
        #endregion

        #region Constructors
        public MainViewModel()
        {
            LoadRates();
        }

        
        #endregion

        #region Methods
        void LoadRates()
        {
            IsRunning = true;
            Result = "Loading rates...";
        }
        #endregion
        
        #region Commands
        public ICommand ConvertCommand
        {
            get
            {
                return new RelayCommand (Converts);
            }
        }

        private void Converts()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
