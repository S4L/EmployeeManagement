using EmMana.DALInterfaces;
using EmMana.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EmMana.GenderMemoryProvider
{
    public class GenderInMemory : IGenderDataAccess
    {
        static List<GenderCommon> genders = new List<GenderCommon>
        {
            new GenderCommon{ID = 1, GenderType = "Male"},
            new GenderCommon { ID = 2, GenderType = "Female"},
        };


        public List<GenderCommon> GetAllGenders()
        {
            return genders;
        }

        public GenderCommon GetGenderByEmployeeID(int id)
        {
            return genders.Find(gender => gender.ID == id);
        }

        public int GetGenderIDByGenderType(string genderType)
        {
            try
            {
                return genders.FirstOrDefault(gender => gender.GenderType == genderType).ID;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0;
            }
           
        }

        public void OpenConnection()
        {
            throw new System.NotImplementedException();
        }
    }
}
