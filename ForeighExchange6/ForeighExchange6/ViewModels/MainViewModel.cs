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

    public class MainViewModel
    {
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
            get;
            set;
        }
        public bool iIsEnabled
        {
            get;
            set;
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
