using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TimesheetPortal.App_Code;

namespace TimesheetPortal.Models
{
    class ModelEmployees : ModelBase
    {

        public ModelEmployees(Controller controller) : base(controller)
        {

        }

        public IList<Employee> GetEmployeeList()
        {
            var query = from t in _dataContext.Employees
                        orderby t.Surname ascending, t.FirstName ascending, t.IdEmployee ascending
                        select t;

            return query.ToList();
        }

        public IList<GetMatchedEmployeeList_Result> GetEmployeeList(Int32 requestedPage, Int32 rowsPerPage, String searchParameter)
        {
            var query = from t in _dataContext.GetMatchedEmployeeList(requestedPage, rowsPerPage, searchParameter)
                         select t;

            return query.ToList();
        }

        public Int32 GetEmployeeListPageCount(Int32 rowsPerPage, String searchParameter)
        {
            Int32 returnValue = 0;
            Int32 rows = 0;

            var query = (from t in _dataContext.GetMatchedEmployeeListCount(searchParameter)
                        select t).FirstOrDefault();

            rows = query.Value;

            if (rowsPerPage > 0)
            {
                if ((rows % rowsPerPage) == 0)
                    returnValue = ((Int32)(rows / rowsPerPage));
                else
                    returnValue = ((Int32)(rows / rowsPerPage)) +1;

            }
            else
                returnValue = rows;

            return (returnValue);

        }

        public String GetEmployeeName(Int32 IdEmployee)
        {
            String returnValue = "";

            var query = (from t in _dataContext.Employees
                        where t.IdEmployee == IdEmployee
                        select t).FirstOrDefault();

            returnValue = StringTools.FormatName(query.Surname, query.FirstName, query.MiddleNames);

            return (returnValue);
        }

        public Employee GetRecordById(Int32 IdEmployee)
        {
            Employee rEmployee = new Employee();

            var query = from t in _dataContext.Employees
                        where t.IdEmployee == IdEmployee
                        select t;

            if (query != null)
                rEmployee = (Employee)query.ToList().First();

            return rEmployee;
        }

        public Employee GetRecordByUserId(Int32 IdUser)
        {
            Employee rEmployee = new Employee();

            var query = from t in _dataContext.Employees
                        where t.IdUser == IdUser
                        select t;

            if (query != null)
                rEmployee = (Employee)query.ToList().FirstOrDefault();

            return rEmployee;
        }

        public Boolean IsEmployee(Int32 IdUser)
        {
            Boolean returnValue = false;

            var query = from t in _dataContext.Employees
                        where t.IdUser == IdUser
                        select t;
            if (query.ToList().Count() > 0)
                returnValue = true;

            return(returnValue);
        }

        public Int32 GetEmployeeIdFromUserId(Int32 IdUser)
        {
            Int32 returnValue = 0;

            Employee employee = GetRecordByUserId(IdUser);

            if (employee != null)
                returnValue = employee.IdEmployee;

            return returnValue;
        }

        public Int32 GetEmployeeUserIdFromId(Int32 idEmployee)
        {
            Int32 returnValue = 0;

            var query = (from t in _dataContext.Employees
                        where t.IdEmployee == idEmployee
                        select t.IdUser).FirstOrDefault();

            returnValue = query ?? 0;

            return (returnValue);
        }

        public Boolean InsertEmployeeRecord(Employee rEmployee)
        {
            Boolean returnValue = false;

            ClearError();

            rEmployee.IdUser = null;
            _dataContext.Employees.Add(rEmployee);
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

            return (returnValue);
        }

        public Boolean UpdateEmployeeRecord(Int32 idEmployee, Employee rEmployee)
        {
            Boolean returnValue = false;

            ClearError();

            Employee updEmployee = GetRecordById(idEmployee);

            updEmployee.IdSwissoft = rEmployee.IdSwissoft;
            updEmployee.SwissoftAbrev = rEmployee.SwissoftAbrev;
            updEmployee.Surname = rEmployee.Surname;
            updEmployee.FirstName = rEmployee.FirstName;
            updEmployee.MiddleNames = rEmployee.MiddleNames;
            updEmployee.Address1 = rEmployee.Address1;
            updEmployee.Address2 = rEmployee.Address2;
            updEmployee.Suburb = rEmployee.Suburb;
            updEmployee.State = rEmployee.State;
            updEmployee.PostCode = rEmployee.PostCode;
            updEmployee.Status = rEmployee.Status;
            updEmployee.EmailAddress = rEmployee.EmailAddress;
            updEmployee.Phone = rEmployee.Phone;
            updEmployee.IdUser = rEmployee.IdUser;

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

            return (returnValue);
        }

        public Boolean DeleteEmployeeRecord(Int32 idEmployee)
        {
            Boolean returnValue = false;

            ClearError();

            Employee rEmployee = (from t in _dataContext.Employees
                                       where t.IdEmployee == idEmployee
                                       select t).FirstOrDefault();

            _dataContext.Employees.Remove(rEmployee);

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
            return (returnValue);
        }
    }
}
