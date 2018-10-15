using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using EmMana.DepartmentBLL;
using EmMana.EmployeeBLL;
using EmMana.GenderBLL;
using EmMana.Models;
using EmMana.WPF.Command;
using EmMana.WPF.Model;

namespace EmMana.WPF.ViewModels
{
    public class NewEmployeeViewModel
    {
        private DepartmentLogic _departmentLogic;
        private GenderLogic _genderLogic;
        private EmployeeLogic _employeeLogic;
        static int totalEmployee = 0;

        public NewEmployeeViewModel()
        {
            if(_departmentLogic == null)
                _departmentLogic = new DepartmentLogic();

            if (_genderLogic == null)
                _genderLogic = new GenderLogic();

            if (_employeeLogic == null)
                _employeeLogic = new EmployeeLogic();
            totalEmployee = _employeeLogic.GetAllEmployees().Count;

            CreateEmployeeCommand = new CreateEmployeeCommand(this);
        }

        #region Properties
        public ICommand CreateEmployeeCommand { get; }
        public ObservableCollection<DepartmentCommon> ObservableDepartmentList => new ObservableCollection<DepartmentCommon>(_departmentLogic.GetAllDepartments());
        public ObservableCollection<GenderCommon> ObservableGenderList => new ObservableCollection<GenderCommon>(_genderLogic.GetAllGenders());
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public string NewEmail { get; set; }
        public string NewPhone { get; set; }
        public string NewDepartment { get; set; }
        public string NewGender { get; set; }
        #endregion

        public bool CanCreate()
        {
            return true;
        }

        public void SaveChanges()
        {
            _employeeLogic.CreateEmployee(new EmployeeCommon
            {
                Id = totalEmployee + 1,
                FirstName = NewFirstName,
                LastName = NewLastName,
                Email = NewEmail,
                DepartmentId = _departmentLogic.GetDepartmentIDByName(NewDepartment),
                GenderId = _genderLogic.GetGenderIDByGenderType(NewGender)
            }
            );
        }
    }
}
