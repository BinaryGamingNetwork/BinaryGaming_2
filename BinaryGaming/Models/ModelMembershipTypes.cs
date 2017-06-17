using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BinaryGaming.Models
{
    public class ModelMembershipTypes : ModelBase
    {
        public ModelMembershipTypes(Controller controller) : base(controller)
        {

        }

        public IList<MembershipTypes> GetListMembershipTypes()
        {
            IList<MembershipTypes> list = null;

            ClearError();

            try
            {
                list = (from t in _dataContext.MembershipTypes
                       select t).ToList();
            }
            catch (Exception e)
            {
                SetError(e);
                
            }

            return list;
        }
    }
}