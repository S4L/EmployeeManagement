using EmployeeManagement_Interfaces;
using EmployeeManagement_Models;
using System.Collections.Generic;

namespace Gender_InMemory
{
    public class GenderInMemory : IGenderProvider
    {
        List<GenderCommon> genders = new List<GenderCommon>();

        public List<GenderCommon> GetAllItems()
        {
            genders.Add(new GenderCommon { ID = 1, GenderType = "Male" });
            genders.Add(new GenderCommon { ID = 1, GenderType = "Female" });
            return genders;
        }

        public void OpenConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
