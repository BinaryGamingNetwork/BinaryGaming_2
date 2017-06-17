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

        public MembershipTypes Get(Int32 id)
        {
            MembershipTypes returnObject = null;

            ClearError();

            try
            {
                returnObject = (from t in _dataContext.MembershipTypes
                                where t.Id == id
                                select t).Single();
            }
            catch (Exception e)
            {
                SetError(e);
            }

            return returnObject;
        }

        public bool Insert(MembershipTypes r)
        {
            bool returnValue = true;
            ClearError();
            try
            {
                _dataContext.MembershipTypes.Add(r);
                _dataContext.SaveChanges();
            }
            catch (Exception e)
            {
                SetError(e);
                returnValue = false;
            }
            return (returnValue);
        }

        public bool Update(MembershipTypes r)
        {
            bool returnValue = false;
            ClearError();

            MembershipTypes record = Get(r.Id);
            if (record != null)
            {
                try
                {
                    record.Assign(r);
                    _dataContext.SaveChanges();
                    returnValue = true;
                }
                catch (Exception e)
                {
                    SetError(e);
                    returnValue = false;
                }
            }

            return (returnValue);
        }

        public bool Delete(Int32 id)
        {
            bool returnValue = false;

            ClearError();
            MembershipTypes record = Get(id);
            if (record != null)
            {
                try
                {
                    _dataContext.MembershipTypes.Remove(record);
                    _dataContext.SaveChanges();
                    returnValue = true;
                }
                catch (Exception e)
                {
                    SetError(e);
                    returnValue = false;
                }
            }
            return (returnValue);
        }

        public bool Delete(MembershipTypes r)
        {
            return (Delete(r.Id));
        }

    }
}