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
    using System.Net.Http;
    using Newtonsoft.Json;
    using Xamarin.Forms;
    using ForeighExchange6.Helpers;
    using ForeighExchange6.Services;

    public class MainViewModel :  INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        ApiService apiServices;
        #endregion

        #region Porperties
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (_status != value)
                    _status = value;
                PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(Status)));
            }
        }
        public String Amount
        {
            get;
            set;
        }
        public ObservableCollection<Rate> Rates
        {
            get
            {
                return _rates;
            }
            set
            {
                if (_rates != value)
                    _rates = value;
                PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(IsRunning)));
            }
        }
        public Rate SourceRate
        {
            get
            {
                return _sourceRate;
            }
            set
            {
                if (_sourceRate != value)
                    _sourceRate = value;
                PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(SourceRate)));
            }
        }
        public Rate TargetRate
        {
            get
            {
                return _targetRate;
            }
            set
            {
                if (_targetRate != value)
                    _targetRate = value;
                PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(TargetRate)));
            }
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
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (_isEnabled != value)
                    _isEnabled = value;
                PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nameof(IsRunning)));
            }
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
                    new PropertyChangedEventArgs(nameof(Result)));
            }
        }
        #endregion

        #region Attributes
        bool _isRunning;
        bool _isEnabled;
        string _result;
        string _status;
        ObservableCollection<Rate> _rates;
        Rate _sourceRate;
        Rate _targetRate;
        #endregion

        #region Constructors
        public MainViewModel()
        {
            apiServices = new ApiService();
            LoadRates();
        }

        
        #endregion

        #region Methods
        async void LoadRates()
        {
            IsRunning = true;
            Result = Lenguages.Loading;

            var connection = await apiServices.CheckConnection();
            if(!connection.IsSuccess)
            {
                IsRunning = false;
                Result = connection.Message;
                return;
            }

            var response = await apiServices.GetList<Rate>("http://apiexchangerates.azurewebsites.net", "/api/Rates");

            if(!response.IsSuccess)
            {
                IsRunning = false;
                Result = response.Message;
                return;
            }

            Rates = new ObservableCollection<Rate>((List<Rate>)response.Result);
            IsRunning = false;
            IsEnabled = true;
            Result = Lenguages.Loading;
            Status = Lenguages.fromChargedRate;
        }
        #endregion

        #region Commands

        public ICommand SwitchsCommand
        {
            get
            {
                return new RelayCommand(Switchs);
            }
        }
        private void Switchs()
        {
            var aux = SourceRate;
            SourceRate = TargetRate;
            TargetRate = aux;
            Converts();
        }

        public ICommand ConvertCommand
        {
            get
            {
                return new RelayCommand (Converts);
            }
        }

        async  void Converts()
        {
            if (string.IsNullOrEmpty(Amount))
            {
                await Application.Current.MainPage.DisplayAlert(Lenguages.Error,
                                                                Lenguages.AmountValidation,
                                                                Lenguages.Accept);
                                                                
                return;
            }

            decimal amount = 0;
            if(!decimal.TryParse(Amount, out amount))
            {
                await Application.Current.MainPage.DisplayAlert(Lenguages.Error,
                                                                Lenguages.AmountNumericValidation,
                                                                Lenguages.Accept);
                return;
            }

            if (SourceRate == null)
            {
                await Application.Current.MainPage.DisplayAlert(Lenguages.Error,
                                                                Lenguages.SourceRateValidation,
                                                                Lenguages.Accept);
            }
            if (TargetRate == null)
            {
                await Application.Current.MainPage.DisplayAlert(Lenguages.Error,
                                                                Lenguages.TargetRateTitle,
                                                                Lenguages.Accept);
                return;
            }

            var amountConverted = amount / (decimal)SourceRate.TaxRate * (decimal)TargetRate.TaxRate;

            Result = string.Format("{0} { 1:C2} = {2} { 3:C2}", SourceRate.Code, amount, TargetRate.Code, amountConverted);
        }
  
        #endregion
    }
}
