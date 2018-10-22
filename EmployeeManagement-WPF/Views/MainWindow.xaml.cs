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
            UpdateEmployeeWindow updateEmployee = new UpdateEmployeeWindow();
            updateEmployee.IdTBlock.Text = EmployeeViewModel.SelectedEmployee.ID.ToString();
            updateEmployee.FirstNameTBox.Text = EmployeeViewModel.SelectedEmployee.FirstName;
            updateEmployee.LastNameTBox.Text = EmployeeViewModel.SelectedEmployee.LastName;
            updateEmployee.EmailTBox.Text = EmployeeViewModel.SelectedEmployee.Email;
            updateEmployee.PhoneTBox.Text = EmployeeViewModel.SelectedEmployee.Phone;
            updateEmployee.DepartmentCBox.Text = EmployeeViewModel.SelectedEmployee.Department;
            updateEmployee.GenderCBox.Text = EmployeeViewModel.SelectedEmployee.Gender;
            updateEmployee.ShowDialog();
        }
    }
}
