using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmMana.WPF.Model
{
    public class Employee: INotifyPropertyChanged
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
                if(value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
