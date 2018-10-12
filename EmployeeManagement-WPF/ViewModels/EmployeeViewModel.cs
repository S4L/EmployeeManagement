using System.Collections.Generic;
using EmployeeManagementBLL;
using System.Collections.ObjectModel;
using EmployeeManagement_Models;
using EmployeeManagement_WPF.Model;
using EmployeeManagement_WPF.Views;
using System.Windows.Input;
using EmployeeManagement_WPF.Command;
using System.ComponentModel;
using System.Collections.Specialized;

namespace EmployeeManagement_WPF.ViewModels
{
    public class EmployeeViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Employee> _observableEmployees;
        private List<DepartmentCommon> _departments;
        private List<GenderCommon> _genders;

        public EmployeeViewModel()
        {
            //var configStr = ConfigurationManager.AppSettings["EmployeeMemory"];
            var _employeeBLL = new EmployeeBLL();
            var _departmentBLL = new DepartmentBLL();
            var _genderBLL = new GenderBLL();
            var employeeCommonList = new List<EmployeeCommon>(_employeeBLL.GetAllEmployess());
            _departments = new List<DepartmentCommon>(_departmentBLL.GetAllDepartments());
            _genders = new List<GenderCommon>(_genderBLL.GetAllGenders());
            var _employeeList = new List<Employee>();
            OpenNewEmployeeCommand = new OpenNewEmployeeWindowCommand(this);

            foreach(var employee in employeeCommonList)
                _employeeList.Add(new Employee
                {
                    ID = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = _departments.Find(deparment => deparment.ID == employee.DepartmentId).Name
                });

            _observableEmployees = new ObservableCollection<Employee>(_employeeList);
        }

        public ObservableCollection<Employee> EmployeeList {
            get => _observableEmployees;
        } 

        public List<DepartmentCommon> DepartmentList => _departments;
        public List<GenderCommon> GenderList => _genders;

        public ICommand OpenNewEmployeeCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OpenNewEmployeeWindow()
        {
            var newEmployeeView = new CreateNewEmployee();
            newEmployeeView.ShowDialog();
        }



    }
}
