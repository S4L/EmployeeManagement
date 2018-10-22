using System.Collections.Generic;
using System.Collections.ObjectModel;
using EmMana.WPF.Model;
using EmMana.WPF.Views;
using System.Windows.Input;
using EmMana.WPF.Command;
using System.Windows;
using EmpManage.BLL;

namespace EmMana.WPF.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        //private EmployeeBL _employeeTool;
        //private DepartmentBL _departmentLogic;
        private ObservableCollection<Model.Employee> _observableEmployeeList;

        public EmployeeViewModel()
        {
            if (EmployeeTool == null)
                EmployeeTool = new EmployeeBL();

            if (DepartmentTool == null)
                DepartmentTool = new DepartmentBL();

            //Command new instances
            OpenNewEmployeeCommand = new OpenNewEmployeeWindowCommand(this);
            DeleteEmployeeCommand = new DeleteEmployeeCommand(this);

            EmployeeList = new ObservableCollection<Model.Employee>(GetEmployees());
        }

        #region Properties
        public static EmployeeBL EmployeeTool { get; set; }
        public static DepartmentBL DepartmentTool { get; set; }
        public static Employee SelectedEmployee { get; set; }
        public ObservableCollection<Model.Employee> EmployeeList
        {
            get => _observableEmployeeList;
            set
            {
                if (_observableEmployeeList != value)
                {
                    _observableEmployeeList = value;
                    NotifyPropertyChanged("EmployeeList");
                }
            }
        }
        #endregion

        #region Button Commands
        public ICommand OpenNewEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }
        #endregion

        public List<Model.Employee> GetEmployees()
        {
            var employees = new List<EmpManage.Models.Employee>(EmployeeTool.GetAllEmployees());
            var employeesVM = new List<Model.Employee>();
            foreach (var employee in employees)
                employeesVM.Add(new Model.Employee
                {
                    ID = employee.ID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = DepartmentTool.GetDepartmentNameByDepartmentID(employee.DepartmentId)
                });

            return employeesVM;
        }

        public void OpenNewEmployeeWindow()
        {
            var newEmployeeView = new NewEmployee();
            newEmployeeView.ShowDialog();

            var newemployeeVM = newEmployeeView.DataContext as NewEmployeeViewModel;
            if(newemployeeVM != null)
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
