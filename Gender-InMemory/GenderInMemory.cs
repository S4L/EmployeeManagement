using EmployeeManagement_Interfaces;
using EmployeeManagement_Models;
using System.Collections.Generic;

namespace GenderMemoryProvider
{
    public class GenderInMemory : IGenderProvider
    {
        List<GenderCommon> genders = new List<GenderCommon>
        {
            new GenderCommon{ID = 1, GenderType = "Male"},
            new GenderCommon { ID = 2, GenderType = "Female"},
        };


        public List<GenderCommon> GetAllGenders()
        {
            return genders;
        }

        public void OpenConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
