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
            //DataContext = new MainVM();
            DataContext = new UIService();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UpdateEmployeeView updateEmpView = new UpdateEmployeeView();
            //EmployeeVM selectedItem = EmployeeListView.SelectedItem as EmployeeVM;
            //updateEmpView.IdTBlock.Text = selectedItem.ID.ToString();
            //updateEmpView.FirstNameTBox.Text = selectedItem.FirstName;
            //updateEmpView.LastNameTBox.Text = selectedItem.LastName;
            //updateEmpView.EmailTBox.Text = selectedItem.Email;
            //updateEmpView.PhoneTBox.Text = selectedItem.Phone;
            //updateEmpView.DepartmentCBox.Text = selectedItem.Department;
            //updateEmpView.GenderCBox.Text = selectedItem.Gender;

            updateEmpView.ShowDialog();
        }

    }
}
