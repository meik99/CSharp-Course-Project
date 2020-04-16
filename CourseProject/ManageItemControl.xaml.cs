using System;
using System.Windows;
using System.Windows.Controls;
using CourseProject.Common.Builder;
using CourseProject.Database.Repository.Facade;

namespace CourseProject
{
    public partial class ManageItemControl : UserControl
    {
        ManageItemViewModel ManageItemViewModel { get; set; }
        
        public ManageItemControl()
        {
            InitializeComponent();
            ManageItemViewModel = new ManageItemViewModel();
            this.DataContext = ManageItemViewModel;
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            ManageItemViewModel.Amount = "0";
            ManageItemViewModel.Description = string.Empty;
            Navigator.Instance.Navigate(new ListItemControl());
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            var task = new ItemFacade()
                .Insert(new ItemBuilder()
                    .SetDescription(ManageItemViewModel.Description)
                    .SetAmount(Double.Parse(ManageItemViewModel.Amount))
                    .Build());
            task.ContinueWith(resultTask =>
            {
                Dispatcher?.Invoke(() =>
                {
                    Navigator.Instance.Navigate(new ListItemControl());
                });
                
            });
            task.Start();
        }
    }
}