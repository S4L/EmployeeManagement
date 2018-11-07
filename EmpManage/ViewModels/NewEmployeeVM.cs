using EmpManage.BLL;
using EmpManage.Command;
using EmpManage.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EmpManage.ViewModels
{
    public class NewEmployeeVM: BaseVM
    {
        public NewEmployeeVM()
        {
            NewEmployee = new EmployeeVM();
            NewEmployee.ID = Guid.NewGuid();
            CreateEmployeeCommand = new CreateEmployeeCmd(this);
        }

        #region Properties
        public ICommand CreateEmployeeCommand { get; }
        public ObservableCollection<Department> ObservableDepartmentList => new ObservableCollection<Department>(DepartmentTool.GetAllDepartments());
        public EmployeeVM NewEmployee { get; set; }
        public bool IsSaved { get; set; }
        #endregion

        public bool CanCreate()
        {
            return true;
        }

        public void SaveChanges()
        {
            var employee = new Employee
            {
                ID = NewEmployee.ID,
                FirstName = NewEmployee.FirstName,
                LastName = NewEmployee.LastName,
                Email = NewEmployee.Email,
                Phone = NewEmployee.Phone,
                DepartmentId = DepartmentTool.GetDepartmentIDByName((string)NewEmployee.Department),
                Gender = NewEmployee.Gender
            };

            if (EmployeeTool.AddEmployee(employee))
            {
                IsSaved = true;
                MessageBox.Show("New Employee Successfully Added!");
            }
        }
    }
}
