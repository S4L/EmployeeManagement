using EMS.UI.ViewModels;
using EMS.UI.Views;
using System.Windows;
using System.Windows.Input;

namespace EMS.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new UIService();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetailView detailView = new DetailView();

            if(EmployeeVM.SelectedEmployee != null)
            {
                detailView.ShowDialog();
                //updateEmpView.ShowDialog();
            }
        }

    }
}
