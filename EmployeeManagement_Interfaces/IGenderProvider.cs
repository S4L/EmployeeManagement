using System.Collections.Generic;
using EmployeeManagement_Models;

namespace EmployeeManagement_Interfaces
{
    public interface IGenderProvider
    {
        void OpenConnection();
        List<GenderCommon> GetAllItems();
    }
}
