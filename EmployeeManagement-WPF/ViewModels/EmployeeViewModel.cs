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
        private EmployeeBL _employeeLogic;
        private DepartmentBL _departmentLogic;

        private ObservableCollection<Model.Employee> _observableEmployeeList;
        public EmployeeViewModel()
        {
            //var configStr = ConfigurationManager.AppSettings["EmployeeMemory"];
            if (_employeeLogic == null)
            _employeeLogic = new EmployeeBL();

            if (_departmentLogic == null)
            _departmentLogic = new DepartmentBL();

            //Command new instances
            OpenNewEmployeeCommand = new OpenNewEmployeeWindowCommand(this);
            DeleteEmployeeCommand = new DeleteEmployeeCommand(this);

            EmployeeList = new ObservableCollection<Model.Employee>(GetEmployees());
        }

        public Employee SelectedEmployee { get; set; }
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

        //Button Commands
        public ICommand OpenNewEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }

        public List<Model.Employee> GetEmployees()
        {
            var employees = new List<EmpManage.Models.Employee>(_employeeLogic.GetAllEmployees());
            var employeesVM = new List<Model.Employee>();
            foreach (var employee in employees)
                employeesVM.Add(new Model.Employee
                {
                    ID = employee.ID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = _departmentLogic.GetDepartmentByDepartmentID(employee.DepartmentId)?.Name ?? "No department found"
                });

            return employeesVM;
        }

        public void OpenNewEmployeeWindow()
        {
            var newEmployeeView = new NewEmployee();
            newEmployeeView.ShowDialog();

            var vm = newEmployeeView.DataContext as NewEmployeeViewModel;
            if(vm != null)
            {
                if (vm.IsSaved)
                {
                    var model = vm.NewEmployee;
                    EmployeeList.Add(model);
                }
            }
        }

        public void DeleteSelectedEmployee()
        {
            _employeeLogic.DeleteEmployee(SelectedEmployee.ID);

           
                MessageBox.Show("Delete Successful!");
                EmployeeList.Remove(SelectedEmployee);
            
        }
    }
}
