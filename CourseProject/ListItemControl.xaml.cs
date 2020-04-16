using System;
using System.Collections.Generic;
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
            task.Start();
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Navigator.Instance.Navigate(new ManageItemControl());
        }
    }
}