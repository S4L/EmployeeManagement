using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_WPF.Model
{
    public class Employee
    {
        private int _id;
        private string _firstname;
        private string _lastname;
        private string _email;
        private string _phone;
        private string _department;
        private string _gender;


        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
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
                _firstname = value;
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
                _lastname = value;
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
                _email = value;
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
                _phone = value;
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
                _department = value;
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
                _gender = value;
            }
        }
    }
}
