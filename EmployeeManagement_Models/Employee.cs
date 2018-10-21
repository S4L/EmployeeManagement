using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmMana.Models
{
    public class EmployeeCommon //TODO: change name to Employee
    {
        public int Id { get; set; } //TODO: use GUID type
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public int GenderId { get; set; }
        public Guid EmployeeID { get; set; }
    }
}
