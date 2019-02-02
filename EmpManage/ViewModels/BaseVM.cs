using EMS.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.UI.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public EmployeeLogic EmployeeTool => new EmployeeLogic();
        public DepartmentLogic DepartmentTool => new DepartmentLogic();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
