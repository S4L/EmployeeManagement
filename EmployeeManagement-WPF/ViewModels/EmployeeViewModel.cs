using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement_WPF;

namespace EmployeeManagement_WPF.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            var configstring = ConfigurationManager.AppSettings["EmployeeMemoryProvider"];
        }
    }
}
