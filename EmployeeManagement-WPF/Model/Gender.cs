using EmMana.GenderBLL;
using EmMana.Models;
using System.Collections.Generic;

namespace EmMana.WPF.Model
{
    public class Gender
    {
        private readonly List<GenderCommon> _genderCommonList;

        public Gender()
        {
            var genderBLL = new GenderLogic();
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
