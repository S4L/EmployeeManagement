using EMS.Logics;
using EMS.Models;
using EMS.UI.ViewModels;
using EMS.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EMS.UI
{
    public class UIService
    {
        public UIService()
        {
            OpenAddWindowCmd = new Command.OpenAddWindow(this);
            DeleteEmployeeCmd = new Command.DeleteEmployee(this);
            AddEmployeeCmd = new Command.AddEmployee(this);
            EditEmployeeCmd = new Command.UpdateEmployee(this);
            EmployeeVM = new EmployeeVM();
        }

        #region Button Commands
        public ICommand OpenAddWindowCmd { get; }
        public ICommand DeleteEmployeeCmd { get; }
        public ICommand AddEmployeeCmd { get; }
        public ICommand EditEmployeeCmd { get; }
        #endregion

        #region Properties
        public EmployeeLogic EmployeeTool => new EmployeeLogic();
        public DepartmentLogic DepartmentTool => new DepartmentLogic();
        public EmployeeVM EmployeeVM { get; set; }
        #endregion

        internal List<Department> GetUIDepartments()
        {
            return DepartmentTool.GetAllDepartments();
        }

        internal List<EmployeeVM> GetUIEmployees()
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
                    Department = DepartmentTool.GetDepartmentNameByID(employee.DepartmentId),
                    Gender = employee.Gender
                });

            return employeesVM;
        }


        internal void OpenNewEmployeeWindow()
        {
            var newEmployeeView = new NewEmployeeView();
            newEmployeeView.ShowDialog();
        }

        internal void DeleteEmployee()
        {
            bool isDeleted = EmployeeTool.DeleteEmployee(EmployeeVM.SelectedEmployee.ID);
            if (isDeleted)
            {
                // Update UI List after successful delete in database
                EmployeeVM.Employees.Remove(EmployeeVM.SelectedEmployee);
            }
        }

        internal void AddEmployee()
        {
            var employee = new Employee
            {
                ID = Guid.NewGuid(),
                FirstName = EmployeeVM.FirstName,
                LastName = EmployeeVM.LastName,
                Email = EmployeeVM.Email,
                Phone = EmployeeVM.Phone,
                DepartmentId = DepartmentTool.GetDepartmentIDByName((string)EmployeeVM.Department),
                Gender = EmployeeVM.Gender
            };

            if (EmployeeTool.AddEmployee(employee))
            {
                EmployeeVM.Employees.Add(EmployeeVM);
            }     
        }

        internal void UpdateEmployee()
        {
            var updateEmployee = new Employee
            {
                ID = EmployeeVM.SelectedEmployee.ID,
                FirstName = EmployeeVM.SelectedEmployee.FirstName,
                LastName = EmployeeVM.SelectedEmployee.LastName,
                Email = EmployeeVM.SelectedEmployee.Email,
                Phone = EmployeeVM.SelectedEmployee.Phone,
                DepartmentId = DepartmentTool.GetDepartmentIDByName((string)EmployeeVM.SelectedEmployee.Department),
                Gender = EmployeeVM.SelectedEmployee.Gender
            };

            EmployeeTool.UpdateEmployee(updateEmployee);
        }

        

        
    }
}
