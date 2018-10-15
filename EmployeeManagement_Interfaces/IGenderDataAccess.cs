﻿using System.Collections.Generic;
using EmMana.Models;

namespace EmMana.DALInterfaces
{
    public interface IGenderDataAccess
    {
        void OpenConnection();
        List<GenderCommon> GetAllGenders();
        GenderCommon GetGenderByEmployeeID(int id);
        int GetGenderIDByGenderType(string genderType);
    }
}
