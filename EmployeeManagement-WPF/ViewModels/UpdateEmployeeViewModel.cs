using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using EmMana.WPF.Command;
using EmMana.WPF.Views;
using EmpManage.Models;
using System.Linq;

namespace EmMana.WPF.ViewModels
{
    public class UpdateEmployeeViewModel: BaseViewModel
    {
        private EmMana.WPF.Model.Employee _newEmployee;

        public UpdateEmployeeViewModel()
        {
            UpdateEmployeeCommand = new UpdateEmployeeCommand(this);
            NewEmployee = new EmMana.WPF.Model.Employee();
            IsUpdate = false;
        }

        #region Properties
        public bool IsUpdate { get; set; }
        public ObservableCollection<Department> ObservableDepartments => new ObservableCollection<Department>(EmployeeViewModel.DepartmentTool.GetAllDepartments());
        public EmMana.WPF.Model.Employee NewEmployee
        {
            get
            {
                return _newEmployee;
            }
            set
            {
                if (_newEmployee != value)
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
            try
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

                if (EmployeeViewModel.EmployeeTool.UpdateEmployee(NewEmployee.ID, employee))
                {
                    IsUpdate = true;
                    MessageBox.Show("Update Completed!");

                    //Update selected item in UI List
                    UpdateSelectedItemInView();
                    
                }
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                IsUpdate = false;
                MessageBox.Show("Update Failed!");
            } 
        }

        public void UpdateSelectedItemInView()
        {
            try
            {
                EmployeeViewModel.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).ID = NewEmployee.ID;
                EmployeeViewModel.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).FirstName = NewEmployee.FirstName;
                EmployeeViewModel.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).LastName = NewEmployee.LastName;
                EmployeeViewModel.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).Email = NewEmployee.Email;
                EmployeeViewModel.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).Phone = NewEmployee.Phone;
                EmployeeViewModel.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).Department = NewEmployee.Department;
                EmployeeViewModel.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).Gender = NewEmployee.Gender;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
