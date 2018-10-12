using EmployeeManagement_Interfaces;
using EmployeeManagement_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementBLL
{
    public class GenderBLL
    {
        private IGenderProvider _genderProvider;

        public GenderBLL()
        {
            //TODO: Figure out how to resole the Type.GetType returns null issue
            //var providerType = Type.GetType(configString);
            //_employeeProvider = (IEmployeeProvider)Activator.CreateInstance(providerType);
            _genderProvider = new GenderMemoryProvider.GenderInMemory();
        }

        public List<GenderCommon> GetAllGenders()
        {
            return _genderProvider.GetAllGenders();
        }
    }
}
