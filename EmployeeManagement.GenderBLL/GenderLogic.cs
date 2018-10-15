using EmMana.DALInterfaces;
using EmMana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmMana.GenderBLL
{
    public class GenderLogic
    {
        private IGenderDataAccess _genderProvider;

        public GenderLogic()
        {
            //TODO: Figure out how to resole the Type.GetType returns null issue
            //var providerType = Type.GetType(configString);
            //_employeeProvider = (IEmployeeProvider)Activator.CreateInstance(providerType);
            _genderProvider = new EmMana.GenderMemoryProvider.GenderInMemory();
        }

        public List<GenderCommon> GetAllGenders()
        {
            return _genderProvider.GetAllGenders();
        }
    }
}
