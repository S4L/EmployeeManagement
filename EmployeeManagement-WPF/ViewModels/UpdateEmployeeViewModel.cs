using System.Collections.ObjectModel;
using System.Windows.Input;
using EmMana.WPF.Command;
using EmpManage.Models;

namespace EmMana.WPF.ViewModels
{
    public class UpdateEmployeeViewModel: BaseViewModel
    {
        public UpdateEmployeeViewModel()
        {
            UpdateEmployeeCommand = new UpdateEmployeeCommand(this);
        }

        #region Properties
        public ObservableCollection<Department> ObservableDepartments => new ObservableCollection<Department>(EmployeeViewModel.DepartmentTool.GetAllDepartments());
        public EmMana.WPF.Model.Employee NewEmployee { get; set; }
        #endregion

        #region Command Properties
        public ICommand UpdateEmployeeCommand { get; set; }
        #endregion

        public void UpdateChanges()
        {
            var employee = new Employee
            {
                ID = NewEmployee.ID,
                FirstName = NewEmployee.FirstName,
                LastName = NewEmployee.LastName,
                Email = NewEmployee.Email,
                Phone = NewEmployee.Phone,
                DepartmentId = EmployeeViewModel.DepartmentTool.GetDepartmentIDByName(NewEmployee.Department),
                Gender = NewEmployee.Gender
            };

            EmployeeViewModel.EmployeeTool.UpdateEmployee(NewEmployee.ID, employee);
        }
    }
}
