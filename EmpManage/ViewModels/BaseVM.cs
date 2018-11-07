using EmpManage.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManage.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public BaseVM()
        {
            EmployeeDataType = ConfigurationManager.AppSettings["EmployeeInMemory"];
            DepartmentDataType = ConfigurationManager.AppSettings["DepartmentInMemory"];
        }

        //Properties
        public string EmployeeDataType { get; set; }
        public string DepartmentDataType { get; set; }
        public EmployeeBL EmployeeTool => new EmployeeBL(EmployeeDataType);
        public DepartmentBL DepartmentTool => new DepartmentBL(DepartmentDataType);

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
