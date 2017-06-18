using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace BinaryGaming.Models
{
    public class ModelMembers : ModelBase
    {
        public ModelMembers(Controller controller) : base(controller)
        {

        }

        public IList<GetMatchedMemberList_Result> GetMatchedMemberList(Int32 requestedPage, Int32 rowsPerPage, String searchParameter)
        {
            var query = from t in _dataContext.GetMatchedMemberList(requestedPage, rowsPerPage, searchParameter)
                        select t;

            return query.ToList();
        }

        public Int32 GetMatchedMemberListPageCount(Int32 rowsPerPage, String searchParameter)
        {
            Int32 returnValue = 0;
            Int32 rows = 0;

            var query = (from t in _dataContext.GetMatchedMemberListCount(searchParameter)
                         select t).FirstOrDefault();

            rows = query.Value;

            if (rowsPerPage > 0)
            {
                if ((rows % rowsPerPage) == 0)
                    returnValue = ((Int32)(rows / rowsPerPage));
                else
                    returnValue = ((Int32)(rows / rowsPerPage)) + 1;

            }
            else
                returnValue = rows;

            return (returnValue);

        }


        public bool IsProfileExist(String ProfileId)
        {
            bool returnValue = true;
            ClearError();

            try
            {
                var query = (from t in _dataContext.Members
                             where t.AspNetUserId == ProfileId
                             select t).Single();
            }
            catch (Exception e)
            {
                SetError(e);
                returnValue = false;
            }

            return (returnValue);
        }

        public Members GetRecordByUserId(String UserId)
        {
            Members returnObject = null;
            ClearError();

            try
            {
                returnObject = (from t in _dataContext.Members
                                where t.AspNetUserId == UserId
                                select t).Single();
            }
            catch (Exception e)
            {
                SetError(e);
            }

            return returnObject;

        }

        public Members Get(Int32 id)
        {
            Members returnObject = null;

            ClearError();

            try
            {
                returnObject = (from t in _dataContext.Members
                                where t.Id == id
                                select t).Single();
            }
            catch (Exception e)
            {
                SetError(e);
            }

            return returnObject;
        }

        public bool Update(Members r)
        {
            bool returnValue = false;
            ClearError();

            Members record = Get(r.Id);
            if (record != null)
            {
                record.Assign(r);
                try
                {
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

        public bool Insert(Members r)
        {
            bool returnValue = false;
            ClearError();

            try
            {
                _dataContext.Members.Add(r);
                _dataContext.SaveChanges();
                returnValue = true;
            }
            catch (Exception e)
            {
                SetError(e);
                returnValue = false;
            }

            return (returnValue);
        }
    }
}