using System.Windows.Input;
using System.Windows.Navigation;

namespace CourseProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigator.Instance.SourceFrame = frame;
        }

        private void OnAddItemClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}