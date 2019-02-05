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
            EmployeeVM = new EmployeeVM();
        }

        #region Button Commands
        public ICommand OpenAddWindowCmd { get; }
        public ICommand DeleteEmployeeCmd { get; }
        public ICommand AddEmployeeCmd { get; }
        #endregion

        //Properties
        public EmployeeLogic EmployeeTool => new EmployeeLogic();
        public DepartmentLogic DepartmentTool => new DepartmentLogic();
        public EmployeeVM EmployeeVM { get; set; }

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
                    Department = DepartmentTool.GetDepartmentNameByID(employee.DepartmentId)
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

        
    }
}
