using EmployeeManagement_EmployeeBLL;
using EmployeeManagement_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_WPF.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            try
            {
                var employeeProviderString = ConfigurationManager.AppSettings["EmployeeMemoryProvider"];
                EmployeeBLL employeeBLL = new EmployeeBLL(employeeProviderString);
                var employeeList = new ObservableCollection<Employee>(employeeBLL.GetAllEmployess());
            }catch(ArgumentNullException ex)
            {
                // do nothing
            }
           
        }
    }
}
