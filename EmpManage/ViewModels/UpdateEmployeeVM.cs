using EMS.UI.Command;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EMS.UI.ViewModels
{
    public class UpdateEmployeeVM : BaseVM
    {
        private EmployeeVM _newEmployee;

        public UpdateEmployeeVM()
        {
            UpdateEmployeeCommand = new UpdateEmployee(this);
            NewEmployee = new EmployeeVM();
            IsUpdate = false;
        }

        #region Properties
        public bool IsUpdate { get; set; }
        //public ObservableCollection<Department> ObservableDepartments => new ObservableCollection<Department>(DepartmentTool.GetAllDepartments());
        public EmployeeVM NewEmployee
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
                    OnPropertyChanged("NewEmployee");
                }
            }
        }
        #endregion

        #region Command Properties
        public ICommand UpdateEmployeeCommand { get; set; }
        #endregion

        //public void UpdateChanges()
        //{
        //    try
        //    {
        //        var employee = new Employee
        //        {
        //            ID = NewEmployee.ID,
        //            FirstName = NewEmployee.FirstName,
        //            LastName = NewEmployee.LastName,
        //            Email = NewEmployee.Email,
        //            Phone = NewEmployee.Phone,
        //            DepartmentId = DepartmentTool.GetDepartmentIDByName(NewEmployee.Department),
        //            Gender = NewEmployee.Gender
        //        };

        //        if (EmployeeTool.UpdateEmployee(NewEmployee.ID, employee))
        //        {
        //            IsUpdate = true;
        //            MessageBox.Show("Update Completed!");

        //            //Update selected item in UI List
        //            UpdateSelectedItemInView();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.ToString());
        //        IsUpdate = false;
        //        MessageBox.Show("Update Failed!");
        //    }
        //}

        public void UpdateSelectedItemInView()
        {
            try
            {
                MainVM.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).ID = NewEmployee.ID;
                MainVM.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).FirstName = NewEmployee.FirstName;
                MainVM.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).LastName = NewEmployee.LastName;
                MainVM.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).Email = NewEmployee.Email;
                MainVM.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).Phone = NewEmployee.Phone;
                MainVM.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).Department = NewEmployee.Department;
                MainVM.EmployeeList.FirstOrDefault(e => e.ID == NewEmployee.ID).Gender = NewEmployee.Gender;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
