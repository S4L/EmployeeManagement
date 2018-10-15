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

namespace EmMana.WPF.ViewModels
{
    public class EmployeeViewModel
    {
        private EmployeeLogic _employeeLogic;
        private DepartmentLogic _departmentLogic;
        private GenderLogic _genderLogic;

        public EmployeeViewModel()
        {
            //var configStr = ConfigurationManager.AppSettings["EmployeeMemory"];
            if (_employeeLogic == null)
                _employeeLogic = new EmployeeLogic();

            if (_departmentLogic == null)
                _departmentLogic = new DepartmentLogic();

            if (_genderLogic == null)
                _genderLogic = new GenderLogic();

            OpenNewEmployeeCommand = new OpenNewEmployeeWindowCommand(this);
        }

        public ObservableCollection<EmployeeVM> EmployeeList => new ObservableCollection<EmployeeVM>(GetEmployees());
        

        public ICommand OpenNewEmployeeCommand { get; }

        public List<EmployeeVM> GetEmployees()
        {
                var employeeCommonList = new List<EmployeeCommon>(_employeeLogic.GetAllEmployees());
                var employeesVM = new List<EmployeeVM>();
                foreach (var employee in employeeCommonList)
                    employeesVM.Add(new EmployeeVM
                    {
                        ID = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                        Phone = employee.Phone,
                        Department = _departmentLogic.GetDepartmentByDepartmentID(employee.DepartmentId)?.Name?? "No department found"
                    });

                return employeesVM;
        }

        public void OpenNewEmployeeWindow()
        {
            var newEmployeeView = new NewEmployee();
            var result = newEmployeeView.ShowDialog();
        }



    }
}
