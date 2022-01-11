using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToggleButtons.ViewModels
{
    internal class DemonstrateViewModel : VMBase
    {
        private bool _isEnabled = false;
        public bool IsEnabled { get => _isEnabled; set { _isEnabled = value; OnPropertyChanged(nameof(IsEnabled)); } }
        private bool _isOn = false;
        public bool IsOn { get => _isOn; set { _isOn = value; OnPropertyChanged(nameof(IsOn)); } }

        public ICommand EnableStatusSwitchCommand => new RelayCommand(IsEnableSwitch);

        private void IsEnableSwitch(object o)
        {
            if (IsEnabled) 
            {
                IsEnabled = false;
                IsOn = false;
            }
            else
            {
                IsEnabled = true;
                IsOn = false;
            }
        }

    }
}
