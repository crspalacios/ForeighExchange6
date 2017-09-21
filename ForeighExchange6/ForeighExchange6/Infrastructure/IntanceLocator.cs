using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeighExchange6.Infrastructure
{
    using ViewModels;
    public class IntanceLocator
    {
        public MainViewModel Main { get; set; }

        public IntanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}
