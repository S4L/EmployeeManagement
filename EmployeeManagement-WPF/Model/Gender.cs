using EmployeeManagement_Models;
using EmployeeManagementBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_WPF.Model
{
    public class Gender
    {
        private readonly List<GenderCommon> _genderCommonList;

        public Gender()
        {
            var genderBLL = new GenderBLL();
            _genderCommonList = new List<GenderCommon>(genderBLL.GetAllGenders());
        }

        public List<GenderCommon> GendertList
        {
            get
            {
                return _genderCommonList;
            }
        }
    }
}
