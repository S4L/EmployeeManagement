using EMS.Logics;
using EMS.UI.Command;
using EMS.Models;
using EMS.UI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EMS.UI.ViewModels
{
    public class MainVM : BaseVM
    {
        public MainVM()
        {
            //Command new instances
            OpenNewEmployeeCommand = new OpenNewEmployeeViewCmd(this);
            DeleteEmployeeCommand = new DeleteEmployeeCmd(this);

            EmployeeList = new ObservableCollection<EmployeeVM>(GetEmployees());
        }

        #region Properties
        public static EmployeeVM SelectedEmployee { get; set; }
        public static ObservableCollection<EmployeeVM> EmployeeList
        {
            get; set;
        }
        #endregion


        #region Button Commands
        public ICommand OpenNewEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }
        #endregion

        public List<EmployeeVM> GetEmployees()
        {
            var employees = new List<Employee>(EmployeeTool.GetAllEmployees());
            var employeesVM = new List<EmployeeVM>();
            foreach (var employee in employees)
                employeesVM.Add(new EmployeeVM
                {
                    ID = employee.ID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = DepartmentTool.GetDepartmentNameByID(employee.DepartmentId)
                });

            return employeesVM;
        }

        public void OpenNewEmployeeWindow()
        {
            var newEmployeeView = new NewEmployeeView();
            newEmployeeView.ShowDialog();

            var newemployeeVM = newEmployeeView.DataContext as NewEmployeeVM;
            if (newemployeeVM != null)
            {
                if (newemployeeVM.IsSaved)
                {
                    var employee = newemployeeVM.NewEmployee;
                    EmployeeList.Add(employee);
                }
            }
        }

        public void DeleteSelectedEmployee()
        {
            if (EmployeeTool.DeleteEmployee(SelectedEmployee.ID))
            {
                MessageBox.Show("Delete Successful!");
                EmployeeList.Remove(SelectedEmployee);
            }
        }
    }
}
