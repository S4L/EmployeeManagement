using System.Collections.ObjectModel;
using System.Windows.Input;
using EmMana.WPF.Command;
using EmpManage.Models;

namespace EmMana.WPF.ViewModels
{
    public class UpdateEmployeeViewModel: BaseViewModel
    {
        private EmMana.WPF.Model.Employee _newEmployee;

        public UpdateEmployeeViewModel()
        {
            UpdateEmployeeCommand = new UpdateEmployeeCommand(this);
            NewEmployee = EmployeeViewModel.SelectedEmployee;
        }

        #region Properties
        public ObservableCollection<Department> ObservableDepartments => new ObservableCollection<Department>(EmployeeViewModel.DepartmentTool.GetAllDepartments());
        public EmMana.WPF.Model.Employee NewEmployee
        {
            get
            {
                return _newEmployee;
            }
            set
            {
                if(_newEmployee != value)
                {
                    _newEmployee = value;
                    NotifyPropertyChanged("NewEmployee");
                }
            }
        }
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
