using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using EmMana.WPF.Command;
using EmMana.WPF.Model;
using EmpManage.BLL;


namespace EmMana.WPF.ViewModels
{
    public class NewEmployeeViewModel
    {
        private DepartmentBL _departmentLogic;
        private EmployeeBL _employeeLogic;

        public NewEmployeeViewModel()
        {
            if (_departmentLogic == null)
                _departmentLogic = new DepartmentBL();

            if (_employeeLogic == null)
                _employeeLogic = new EmployeeBL();

            NewEmployee = new Model.Employee();
            NewEmployee.ID = Guid.NewGuid();
            CreateEmployeeCommand = new CreateEmployeeCommand(this);
        }

        #region Properties
        public ICommand CreateEmployeeCommand { get; }
        public ObservableCollection<EmpManage.Models.Department> ObservableDepartmentList => new ObservableCollection<EmpManage.Models.Department>(_departmentLogic.GetAllDepartments());
        public Employee NewEmployee { get; set; }
        public bool IsSaved { get; set; }
        #endregion

        public bool CanCreate()
        {
            return true;
        }

        public void SaveChanges()
        {
            var employee = new EmpManage.Models.Employee
            {
                ID = NewEmployee.ID,
                FirstName = NewEmployee.FirstName,
                LastName = NewEmployee.LastName,
                Email = NewEmployee.Email,
                Phone = NewEmployee.Phone,
                DepartmentId = _departmentLogic.GetDepartmentIDByName((string)NewEmployee.Department),

            };

            _employeeLogic.AddEmployee(employee);

            IsSaved = true;
            MessageBox.Show("New Employee Successfully Added!");
        }
    }
}
