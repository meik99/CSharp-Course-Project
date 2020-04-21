using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using CourseProject.Common.Contract;
using CourseProject.Common.Factory;
using CourseProject.Database.Repository.Facade;

namespace CourseProject
{
    public partial class ListItemControl : UserControl
    {
        ListItemViewModel _viewModel = new ListItemViewModel();

        public ListItemControl()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            
            UpdateItems();
        }

        private void UpdateItems()
        {
            var task = new ItemFacade().FindAll();
            task.ContinueWith((result) => _viewModel.Items = result.Result);
        }
        
        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            Navigator.Instance.Navigate(new ManageItemControl());
        }

        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            string text = "Delete selected items?";
            string caption = "Delete";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            var result = MessageBox.Show(text, caption, buttons, icon);

            switch(result)
            {
                case MessageBoxResult.Yes:
                    new Task(async () =>
                    {
                        var facade = new ItemFacade();
                        var itemArray = new IItem[_viewModel.SelectedItems.Count];
                        _viewModel.SelectedItems.CopyTo(itemArray);
                        
                        foreach (var item in itemArray)
                        {
                            await facade.Delete(item.Id);
                        }

                        ListViewItems?.Dispatcher?.Invoke(() =>
                        {
                            _viewModel.SelectedItems = null;
                            _viewModel.Items = facade.FindAll().Result;
                            ListViewItems.Items.Refresh();
                        });
                    }).Start();
                break;
            };
        }

        private void OnModifyClick(object sender, RoutedEventArgs e)
        {
            Navigator.Instance.Navigate(new ManageItemControl(_viewModel.SelectedItems.First()));
        }

        private void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var items = ListViewItems.SelectedItems;
            var list = new List<IItem>();
            
            foreach (var item in items)
            {
                list.Add(item as IItem);
            }

            _viewModel.SelectedItems = list;
        }
    }
}