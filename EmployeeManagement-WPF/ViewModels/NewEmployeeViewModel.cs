using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using EmployeeManagement_Models;
using EmployeeManagement_WPF.Command;
using EmployeeManagement_WPF.Model;
using EmployeeManagement_WPF.Views;
using EmployeeManagementBLL;

namespace EmployeeManagement_WPF.ViewModels
{
    public class NewEmployeeViewModel
    {
        private List<DepartmentCommon> _departments;
        private List<GenderCommon> _genders;

        public NewEmployeeViewModel()
        {
            _departments = new DepartmentBLL().GetAllDepartments();
            _genders = new GenderBLL().GetAllGenders();
            ObservableDepartmentList = new ObservableCollection<DepartmentCommon>(_departments);
            ObservableGenderList = new ObservableCollection<GenderCommon>(_genders);
            CreateEmployeeCommand = new CreateEmployeeCommand(this);
        }

        #region Properties
        public ICommand CreateEmployeeCommand { get; }
        public ObservableCollection<DepartmentCommon> ObservableDepartmentList { get; set; }
        public ObservableCollection<GenderCommon> ObservableGenderList { get; set; }
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
            //Debug.Assert(false, "Pressed");
            var employeeBLL = new EmployeeBLL();
            var genderObj = new Gender();

            var newEmployee = new EmployeeCommon
            {
                Id = employeeBLL.GetAllEmployess().Count,
                FirstName = NewFirstName,
                LastName = NewLastName,
                Email = NewEmail,
                Phone = NewPhone,
                DepartmentId = _departments.Find(department => department.Name == NewDepartment).ID,
                GenderId = _genders.Find(gender => gender.GenderType == NewGender).ID
            };

            employeeBLL.CreateEmployee(newEmployee);
        }
    }
}
