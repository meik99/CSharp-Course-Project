using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using CourseProject.Annotations;

namespace CourseProject
{
    public class ManageItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _description;
        private double _amount;

        public string Description
        {
            get => _description;
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string Amount
        {
            get => _amount.ToString(CultureInfo.InvariantCulture);
            set
            {
                if (value.Contains("."))
                {
                    value = value.Replace(".", ",");
                }
                
                double d = _amount;
                bool success = double.TryParse(value, out d);
                
                if (success && Math.Abs(d - _amount) > 0.0001)
                {
                    _amount = d;
                    OnPropertyChanged(nameof(Amount));
                }  
            } 
        }
    }
}