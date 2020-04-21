using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CourseProject.Common.Builder;
using CourseProject.Common.Contract;
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

        public ManageItemControl(IItem item) : this()
        {
            ManageItemViewModel.Amount = item.Amount.ToString(CultureInfo.InvariantCulture);
            ManageItemViewModel.Description = item.Description;
            ManageItemViewModel.Id = item.Id;
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            ManageItemViewModel.Amount = "0";
            ManageItemViewModel.Description = string.Empty;
            ManageItemViewModel.Id = 0;
            
            Navigator.Instance.Navigate(new ListItemControl());
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            Task<IItem> task;

            if (ManageItemViewModel.Id <= 0)
            {
                task = new ItemFacade()
                    .Insert(new ItemBuilder()
                        .SetDescription(ManageItemViewModel.Description)
                        .SetAmount(Double.Parse(ManageItemViewModel.Amount, CultureInfo.InvariantCulture))
                        .Build());
            } else
            {
                task = new ItemFacade()
                    .Update(new ItemBuilder()
                        .SetId(ManageItemViewModel.Id)
                        .SetDescription(ManageItemViewModel.Description)
                        .SetAmount(Double.Parse(ManageItemViewModel.Amount, CultureInfo.InvariantCulture))
                        .Build());
            }
                
            task.ContinueWith(resultTask =>
            {
                Dispatcher?.Invoke(() =>
                {
                    Navigator.Instance.Navigate(new ListItemControl());
                });
                
            });
        }
    }
}