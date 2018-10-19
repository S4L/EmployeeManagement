using System;
using System.Collections.ObjectModel;
using System.Windows;
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
        private int totalEmployee = 0;

        public NewEmployeeViewModel()
        {
            if(_departmentLogic == null)
                _departmentLogic = new DepartmentLogic();

            if (_genderLogic == null)
                _genderLogic = new GenderLogic();

            if (_employeeLogic == null)
                _employeeLogic = new EmployeeLogic();
            totalEmployee = _employeeLogic.GetEmployeeCountTotal();
            NewEmployee = new Employee();
            NewEmployee.ID = new Random().Next(1, 1000);
            CreateEmployeeCommand = new CreateEmployeeCommand(this);
        }

        #region Properties
        public ICommand CreateEmployeeCommand { get; }
        public ObservableCollection<DepartmentCommon> ObservableDepartmentList => new ObservableCollection<DepartmentCommon>(_departmentLogic.GetAllDepartments());
        public ObservableCollection<GenderCommon> ObservableGenderList => new ObservableCollection<GenderCommon>(_genderLogic.GetAllGenders());
        public Employee NewEmployee { get; set; }
        public bool IsSaved { get; set; }
        #endregion

        public bool CanCreate()
        {
            return true;
        }

        public void SaveChanges()
        {
            if (!_employeeLogic.IsEmployeeExisted(NewEmployee.ID))
            {
                var employee = new EmployeeCommon
                {
                    Id = NewEmployee.ID,
                    FirstName = NewEmployee.FirstName,
                    LastName = NewEmployee.LastName,
                    Email = NewEmployee.Email,
                    Phone = NewEmployee.Phone,
                    DepartmentId = _departmentLogic.GetDepartmentIDByName(NewEmployee.Department),
                    GenderId = _genderLogic.GetGenderIDByGenderType(NewEmployee.Gender)
                };

                _employeeLogic.CreateEmployee(employee);

                
                    IsSaved = true;
                    MessageBox.Show("New Employee Successfully Added!");
            }
            else
            {
                MessageBox.Show("Error: Employee Already Exist!");
            }
            

        }
    }
}
