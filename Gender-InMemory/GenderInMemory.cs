using EmployeeManagement_Interfaces;
using EmployeeManagement_Models;
using System.Collections.Generic;

namespace Gender_InMemory
{
    public class GenderInMemory : IGenderProvider
    {
        List<Gender> genders = new List<Gender>();

        public List<Gender> GetAllItems()
        {
            genders.Add(new Gender { ID = 1, GenderType = "Male" });
            genders.Add(new Gender { ID = 1, GenderType = "Female" });
            return genders;
        }

        public void OpenConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
