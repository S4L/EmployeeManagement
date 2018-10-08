using EmployeeManagement_WPF.ViewModels;
using System.Windows;

namespace EmployeeManager_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new EmployeeViewModel();
        }
    }
}
