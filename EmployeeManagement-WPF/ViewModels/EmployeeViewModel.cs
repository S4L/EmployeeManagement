using System.Collections.Generic;
using EmMana.EmployeeBLL;
using System.Collections.ObjectModel;
using EmMana.Models;
using EmMana.WPF.Model;
using EmMana.WPF.Views;
using System.Windows.Input;
using EmMana.WPF.Command;
using System.ComponentModel;
using System.Collections.Specialized;
using EmMana.DepartmentBLL;
using EmMana.GenderBLL;

namespace EmMana.WPF.ViewModels
{
    public class EmployeeViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Employee> _observableEmployees;
        private List<DepartmentCommon> _departments;
        private List<GenderCommon> _genders;

        public EmployeeViewModel()
        {
            //var configStr = ConfigurationManager.AppSettings["EmployeeMemory"];
            var _employeeBLL = new EmployeeLogic();
            var _departmentBLL = new DepartmentLogic();
            var _genderBLL = new GenderLogic();
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
