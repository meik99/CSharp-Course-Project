using System.Windows;

namespace CourseProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigator.Instance.SourceFrame = frame;
        }
    }
}