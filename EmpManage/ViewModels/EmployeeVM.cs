using EMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.UI.ViewModels
{
    public class EmployeeVM : BaseVM
    {
        private Guid _id;
        public Guid ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        private string _firstname;
        public string FirstName
        {
            get
            {
                return _firstname;
            }

            set
            {
                if (value != _firstname)
                {
                    _firstname = value;
                    OnPropertyChanged("Firstname");
                }
            }
        }

        private string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }

            set
            {
                if (value != _lastname)
                {
                    _lastname = value;
                    OnPropertyChanged("Lastname");
                }
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        private string _department;
        public string Department
        {
            get
            {
                return _department;
            }

            set
            {
                if (value != _department)
                {
                    _department = value;
                    OnPropertyChanged("Department");
                }
            }
        }

        private string _gender;
        public string Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                if (value != _gender)
                {
                    _gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        private static ObservableCollection<EmployeeVM> _employees;
        public static ObservableCollection<EmployeeVM> Employees
        {
            get
            {
                if(_employees == null)
                {
                    var uiService = new UIService();
                    _employees = new ObservableCollection<EmployeeVM>(uiService.GetUIEmployees());
                }
                return _employees;
            }

            set
            {
                if (value != _employees)
                {
                    _employees = value;
                }
            }
        }

        private ObservableCollection<Department> _departments;
        public ObservableCollection<Department> Departments
        {
            get
            {
                if (_departments == null)
                {
                    var uiService = new UIService();
                    _departments = new ObservableCollection<Department>(uiService.GetUIDepartments());
                }
                return _departments;
            }
            set
            {
                if (value != _departments)
                {
                    _departments = value;
                }
            }
        }

        public static EmployeeVM SelectedEmployee { get; set; }
    }
}

