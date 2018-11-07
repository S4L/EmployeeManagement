﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.ViewModels
{
    public class EmployeeVM : BaseVM
    {
        private Guid _id;
        private string _firstname;
        private string _lastname;
        private string _email;
        private string _phone;
        private string _department;
        private string _gender;

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
                    NotifyPropertyChanged("ID");
                }
            }
        }

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
                    NotifyPropertyChanged("Firstname");
                }
            }
        }

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
                    NotifyPropertyChanged("Lastname");
                }
            }
        }

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
                    NotifyPropertyChanged("Email");
                }
            }
        }

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
                    NotifyPropertyChanged("Phone");
                }
            }
        }

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
                    NotifyPropertyChanged("Department");
                }
            }
        }

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
                    NotifyPropertyChanged("Gender");
                }
            }
        }
    }
}
