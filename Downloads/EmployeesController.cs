using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TimesheetPortal.App_Code;
using TimesheetPortal.Models;
using TimesheetPortal.ViewModels;

namespace TimesheetPortal.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        [Authorize(Roles = SecurityRoles.Administration)]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = SecurityRoles.Administration)]
        [HttpPost]
        public JsonResult EmployeeList()
        {
            IList<GetMatchedEmployeeList_Result> list = null;

            Int32 pageRequested = 1;
            Int32 rowsPerPage = 20;
            Int32 pageCount = -1;
            String searchParameter = String.Empty;

            if (Request.Params[HttpRequestSearchParameters.RequestedPage] != null)
                pageRequested = Convert.ToInt32(this.Request.Params[HttpRequestSearchParameters.RequestedPage]);

            if (Request.Params[HttpRequestSearchParameters.RowsPerPage] != null)
                rowsPerPage = Convert.ToInt32(this.Request.Params[HttpRequestSearchParameters.RowsPerPage]);

            if (Request.Params[HttpRequestSearchParameters.SearchString] != null)
                searchParameter = Convert.ToString(this.Request.Params[HttpRequestSearchParameters.SearchString]);

            ModelEmployees mEmployees = new ModelEmployees(this);
            if (searchParameter == "")
                pageCount = mEmployees.GetEmployeeListPageCount(rowsPerPage, searchParameter);

            list = mEmployees.GetEmployeeList(pageRequested, rowsPerPage, searchParameter);

            return Json( new { page = pageRequested, rows = rowsPerPage, pageCount = pageCount, data = list });
        }


        [Authorize(Roles = SecurityRoles.Administration)]
        public ActionResult Lookup()
        {
            return View();
        }

        // GET: Employees/Details/5
        [Authorize(Roles = SecurityRoles.Administration)]
        public ActionResult Details(int id)
        {
            ModelEmployees mEmployees = new ModelEmployees(this);
            Employee rEmployee = mEmployees.GetRecordById(id);
            ViewModelEmployeeFull vmEmployee = new ViewModelEmployeeFull(rEmployee);

            return View(vmEmployee);
        }

        // GET: Employees/Create
        [Authorize(Roles = SecurityRoles.Administration)]
        public ActionResult Create()
        {
            ViewModelEmployeeFull vmEmployee = new ViewModelEmployeeFull();
            vmEmployee.Status = EmployeeStatus.Active;
            return View(vmEmployee);
        }

        // POST: Employees/Create
        [HttpPost]
        [Authorize(Roles = SecurityRoles.Administration)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModelEmployeeFull vmEmployee)
        {
            bool SuccessYN = true;

            while (true)
            {
                if (ModelState.IsValid == false)
                {
                    SuccessYN = false;  // error Messages handled by Model State
                    break;
                }

                ModelEmployees mEmployees = new ModelEmployees(this);
                Employee rEmployee = new Employee(vmEmployee);
                if (mEmployees.InsertEmployeeRecord(rEmployee) == false)
                {
                    SuccessYN = false;
                    ModelState.AddModelError("", mEmployees.exception);
                    break;
                }

                break;
            }

            if (SuccessYN == true)
                return RedirectToAction("Index");
            else
                return View(vmEmployee);
        }

        // GET: Employees/Edit/5
        [Authorize(Roles = SecurityRoles.Administration)]
        public ActionResult Edit(int id)
        {
            ModelEmployees mEmployee = new ModelEmployees(this);
            Employee rEmployee = mEmployee.GetRecordById(id);
            ViewModelEmployeeFull vmEmployee = new ViewModelEmployeeFull(rEmployee);

            return View(vmEmployee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [Authorize(Roles = SecurityRoles.Administration)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViewModelEmployeeFull vmEmployee)
        {
            bool SuccessYN = true;
            while (true)
            {
                if (ModelState.IsValid == false)
                {
                    SuccessYN = false;
                    break;
                }

                ModelEmployees mEmployee = new ModelEmployees(this);
                Employee rEmployee = new Employee(vmEmployee);

                if (mEmployee.UpdateEmployeeRecord(id, rEmployee) == false)
                {
                    SuccessYN = false;
                    ModelState.AddModelError("", mEmployee.exception);
                    break;
                }

                break;
            }

            if (SuccessYN == true)
                return RedirectToAction("Index");
            else
                return View(vmEmployee);
        }

        // GET: Employees/Delete/5
        [Authorize(Roles = SecurityRoles.Administration)]
        public ActionResult Delete(int id)
        {
            ModelEmployees mEmployee = new ModelEmployees(this);
            Employee rEmployee = mEmployee.GetRecordById(id);
            ViewModelEmployeeFull vmEmployee = new ViewModelEmployeeFull(rEmployee);

            return View(vmEmployee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [Authorize(Roles = SecurityRoles.Administration)]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ViewModelEmployeeFull vmEmployee)
        {
            bool SuccessYN = true;

            while (true)
            {
                if (ModelState.IsValid == false)
                {
                    SuccessYN = false;
                    break;
                }

                ModelEmployees mEmployee = new ModelEmployees(this);

                if (mEmployee.DeleteEmployeeRecord(id) == false)
                {
                    SuccessYN = false;
                    ModelState.AddModelError("", mEmployee.exception);
                    break;
                }

                break;
            }

            if (SuccessYN == true)
                return RedirectToAction("Index");
            else
                return View(vmEmployee);
        }

        [HttpPost]
        [Authorize(Roles = SecurityRoles.Administration)]
        public JsonResult CreateLogin(int id)
        {
            ViewModelCreateLoginResult vmCreateLoginResult = new ViewModelCreateLoginResult();
            ModelEmployees mEmployee = new ModelEmployees(this);
            ModelUsers mUser = new ModelUsers(this);
            Employee rEmployee = mEmployee.GetRecordById(id);
            bool loginExistsYN = false;
            vmCreateLoginResult.Result = false;

            if ((rEmployee.IdUser ?? 0) != 0)
            {
                if (mUser.IsUserExist(rEmployee.IdUser ?? 0) == true)
                {
                    loginExistsYN = true;
                }
            }

            if (loginExistsYN == false && mUser.IsUserExist(rEmployee.EmailAddress) == true)
            {
                // An email address belonging to this contact exists in the Users table but not linked to this contact

                PortalUser rUser = mUser.UserGet(rEmployee.EmailAddress);
                rEmployee.IdUser = rUser.IdUser;
                if (mEmployee.UpdateEmployeeRecord(rEmployee.IdEmployee, rEmployee) == true)
                {
                    vmCreateLoginResult.Result = true;
                    vmCreateLoginResult.Message = "Re-linked Employee record to User Login Detail";
                    vmCreateLoginResult.UserId = rEmployee.EmailAddress;
                }
                else
                {
                    vmCreateLoginResult.Result = false;
                    vmCreateLoginResult.Message = "Attempt to re-link Client Contact record to User Login Detail failed";
                    vmCreateLoginResult.UserId = rEmployee.EmailAddress;
                }

            }
            else if (loginExistsYN == false && mUser.IsUserExist(rEmployee.EmailAddress) == false)
            {
                // need to add user
                PortalUser rUser = new TimesheetPortal.PortalUser(rEmployee);

                Int32 PasswordSaltLength = Int32.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["PasswordSaltLength"]);
                Int32 PasswordPrehashLength = Int32.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["PasswordPrehashLength"]);

                String NewPassword = PasswordTools.GeneratePassword();
                String PasswordSalt = PasswordTools.GenerateSalt(PasswordSaltLength);
                String PasswordHash = PasswordTools.GetHashedPasword(NewPassword, PasswordSalt, PasswordPrehashLength);

                ModelLoginLoggger logger = new ModelLoginLoggger(this);
                logger.Insert(rEmployee.EmailAddress, NewPassword, PasswordSalt, PasswordHash, "Create");

                rUser.PasswordSalt = PasswordSalt;
                rUser.PasswordHash = PasswordHash;
                if (mUser.UserInsert(rUser) == true)
                {
                    rUser = mUser.UserGet(rEmployee.EmailAddress);
                    rEmployee.IdUser = rUser.IdUser;
                    mEmployee.UpdateEmployeeRecord(rEmployee.IdEmployee, rEmployee);

                    vmCreateLoginResult.Result = true;
                    vmCreateLoginResult.Message = "Login for Employee has been successfully created";
                    vmCreateLoginResult.UserId = rEmployee.EmailAddress;
                    vmCreateLoginResult.Password = NewPassword;
                }
                else
                {
                    vmCreateLoginResult.Result = false;
                    vmCreateLoginResult.Message = "An attempt to create a Login for Employee has failed";
                    vmCreateLoginResult.UserId = rEmployee.EmailAddress;
                    vmCreateLoginResult.Password = "";
                }

            }
            else if (loginExistsYN == true)
            {
                vmCreateLoginResult.Result = false;
                vmCreateLoginResult.Message = "A Login for Employee already exists";
                vmCreateLoginResult.UserId = rEmployee.EmailAddress;
                vmCreateLoginResult.Password = "";
            }

            return Json(vmCreateLoginResult);
        }

        [HttpPost]
        [Authorize(Roles = SecurityRoles.Administration)]
        public JsonResult ResetPassword(int id)
        {
            ViewModelCreateLoginResult vmResetPasswordResult = new ViewModelCreateLoginResult();
            ModelEmployees mEmployee = new ModelEmployees(this);
            ModelUsers mUser = new ModelUsers(this);
            Employee rEmployee = mEmployee.GetRecordById(id);

            vmResetPasswordResult.Result = false;

            if ((rEmployee.IdUser ?? 0) != 0)
            {
                if (mUser.IsUserExist(rEmployee.IdUser ?? 0) == true)
                {
                    PortalUser rUser = mUser.UserGet(rEmployee.EmailAddress);

                    Int32 PasswordSaltLength = Int32.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["PasswordSaltLength"]);
                    Int32 PasswordPrehashLength = Int32.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["PasswordPrehashLength"]);

                    String NewPassword = PasswordTools.GeneratePassword();
                    String PasswordSalt = PasswordTools.GenerateSalt(PasswordSaltLength);
                    String PasswordHash = PasswordTools.GetHashedPasword(NewPassword, PasswordSalt, PasswordPrehashLength);

                    ModelLoginLoggger logger = new ModelLoginLoggger(this);
                    logger.Insert(rEmployee.EmailAddress, NewPassword, PasswordSalt, PasswordHash, "Reset");

                    if (mUser.UserUpdatePassword((rEmployee.IdUser ?? 0), PasswordHash, PasswordSalt) == true)
                    {
                        vmResetPasswordResult.Result = true;
                        vmResetPasswordResult.Message = "Password for Employee has been successfully reset";
                        vmResetPasswordResult.UserId = rEmployee.EmailAddress;
                        vmResetPasswordResult.Password = NewPassword;
                    }
                    else
                    {
                        vmResetPasswordResult.Result = false;
                        vmResetPasswordResult.Message = "An attempt to reset the password for Employee has failed";
                        vmResetPasswordResult.UserId = rEmployee.EmailAddress;
                        vmResetPasswordResult.Password = "";
                    }
                }
            }
            else
            {
                vmResetPasswordResult.Result = false;
                vmResetPasswordResult.Message = "This Employee Contact doesn't have a Login.  Unable to reset password";
                vmResetPasswordResult.UserId = rEmployee.EmailAddress;
            }

            return Json(vmResetPasswordResult);
        }

    }
}
