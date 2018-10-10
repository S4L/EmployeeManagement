using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EmployeeManagementBLL;
using System.Collections.ObjectModel;
using EmployeeManagement_Models;
using EmployeeManagement_WPF.Model;

namespace EmployeeManagement_WPF.ViewModels
{
    public class EmployeeViewModel
    {
        private EmployeeBLL _employeeBLL;
        private DepartmentBLL _departmentBLL;
        private ObservableCollection<Employee> _observableEmployees;
        

        public EmployeeViewModel()
        {
            //var configStr = ConfigurationManager.AppSettings["EmployeeMemory"];
            _employeeBLL = new EmployeeBLL();
            _departmentBLL = new DepartmentBLL();
            var employeeCommonList = new List<EmployeeCommon>(_employeeBLL.GetAllEmployess());
            var departmentCommonList = new List<DepartmentCommon>(_departmentBLL.GetAllDepartments());

            var _employeeList = new List<Employee>();
            foreach(var employee in employeeCommonList)
                _employeeList.Add(new Employee
                {
                    ID = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = departmentCommonList.Find(deparment => deparment.ID == employee.DepartmentId).Name
                });

            _observableEmployees = new ObservableCollection<Employee>(_employeeList);
        }

        public ObservableCollection<Employee> EmployeeList {
            get
            {
                return _observableEmployees;
            }
        }




    }
}
