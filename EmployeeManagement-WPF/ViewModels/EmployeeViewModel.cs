using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EmployeeManagement_EmployeeBLL;
using System.Collections.ObjectModel;

namespace EmployeeManagement_WPF.ViewModels
{
    public class EmployeeViewModel
    {
        private EmployeeBLL _employeeBLL;

        public EmployeeViewModel()
        {
            var configStr = ConfigurationManager.AppSettings["EmployeeMemoryProvider"];
            _employeeBLL = new EmployeeBLL(configStr);
            var employeeList = new ObservableCollection<Task>;
        }
    }
}
