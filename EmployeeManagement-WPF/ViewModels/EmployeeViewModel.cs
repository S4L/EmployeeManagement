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
using System;
using System.Diagnostics;
using System.Windows;

namespace EmMana.WPF.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        private EmployeeLogic _employeeLogic;
        private DepartmentLogic _departmentLogic;
        private GenderLogic _genderLogic;
        private ObservableCollection<Employee> _observableEmployeeList;
        public EmployeeViewModel()
        {
            //var configStr = ConfigurationManager.AppSettings["EmployeeMemory"];
            if (_employeeLogic == null)
            _employeeLogic = new EmployeeLogic();

            if (_departmentLogic == null)
            _departmentLogic = new DepartmentLogic();

            if (_genderLogic == null)
            _genderLogic = new GenderLogic();

            //Command new instances
            OpenNewEmployeeCommand = new OpenNewEmployeeWindowCommand(this);
            DeleteEmployeeCommand = new DeleteEmployeeCommand(this);

            EmployeeList = new ObservableCollection<Employee>(GetEmployees());
        }

        public Employee SelectedEmployee { get; set; }
        public ObservableCollection<Employee> EmployeeList
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

        public List<Employee> GetEmployees()
        {
            var employeeCommonList = new List<EmployeeCommon>(_employeeLogic.GetAllEmployees());
            var employeesVM = new List<Employee>();
            foreach (var employee in employeeCommonList)
                employeesVM.Add(new Employee
                {
                    ID = employee.Id,
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

            if (!_employeeLogic.IsEmployeeExisted(SelectedEmployee.ID))
            {
                MessageBox.Show("Delete Successful!");
                EmployeeList.Remove(SelectedEmployee);
            }
        }
    }
}
