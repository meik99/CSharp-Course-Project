using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CourseProject.Annotations;
using CourseProject.Common.Contract;

namespace CourseProject
{
    public class ListItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private readonly List<IItem> _items = new List<IItem>();

        public List<IItem> Items 
        { 
            get => _items;
            set
            {
                if (value != null)
                {
                    _items.Clear();
                    _items.AddRange(value);
                    OnPropertyChanged(nameof(Items));
                }
            }
        }    
    }
}