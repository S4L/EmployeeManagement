using EmMana.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmMana.WPF.Views;

namespace EmMana.WPF
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

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UpdateEmployeeWindow updateEmpView = new UpdateEmployeeWindow();
            EmMana.WPF.Model.Employee selectedItem = EmployeeListView.SelectedItem as EmMana.WPF.Model.Employee;
            updateEmpView.IdTBlock.Text = selectedItem.ID.ToString();
            updateEmpView.FirstNameTBox.Text = selectedItem.FirstName;
            updateEmpView.LastNameTBox.Text = selectedItem.LastName;
            updateEmpView.EmailTBox.Text = selectedItem.Email;
            updateEmpView.PhoneTBox.Text = selectedItem.Phone;
            updateEmpView.DepartmentCBox.Text = selectedItem.Department;
            updateEmpView.GenderCBox.Text = selectedItem.Gender;

            updateEmpView.ShowDialog();
        }
    }
}
