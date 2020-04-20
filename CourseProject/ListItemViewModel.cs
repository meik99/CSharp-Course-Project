using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
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
        private List<IItem> _selectedItems = null;
        
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

        public List<IItem> SelectedItems
        {
            get => _selectedItems;
            set
            {
                _selectedItems = value;
                OnPropertyChanged(nameof(SelectedItems));
                OnPropertyChanged(nameof(IsModifyable));
                OnPropertyChanged(nameof(IsDeleteable));
            }
        }

        public bool IsModifyable => _selectedItems != null && _selectedItems.Count == 1;
        public bool IsDeleteable => _selectedItems != null && _selectedItems.Count > 0;
    }
}