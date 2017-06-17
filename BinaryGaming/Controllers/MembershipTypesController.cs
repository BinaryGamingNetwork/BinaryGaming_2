using BinaryGaming.Models;
using BinaryGaming.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BinaryGaming.Controllers
{
    public class MembershipTypesController : Controller
    {
        // GET: MembershipTypes
        public ActionResult Index()
        {
            ModelMembershipTypes mMembershipTypes = new ModelMembershipTypes(this);
            IList<MembershipTypes> listR = mMembershipTypes.GetListMembershipTypes();
            List<ViewModelMembershipTypes> listVM = new List<ViewModelMembershipTypes>();
            foreach (MembershipTypes r in listR)
            {
                ViewModelMembershipTypes vm = new ViewModelMembershipTypes(r);
                listVM.Add(vm);
            }
            return View("Index", listVM);
        }


        // GET: MembershipTypes/Create
        public ActionResult Create()
        {
            ViewModelMembershipTypes vmMembershipTypes = new ViewModelMembershipTypes();
            return View("Create", vmMembershipTypes);
        }

        // POST: MembershipTypes/Create
        [HttpPost]
        public ActionResult Create(ViewModelMembershipTypes vm)
        {
            ActionResult returnObject = null;

            bool SuccessYN = true;

            while (true)
            {
                if (ModelState.IsValid == false)
                {
                    SuccessYN = false;
                    break;
                }

                MembershipTypes r = new MembershipTypes(vm);
                ModelMembershipTypes m = new ModelMembershipTypes(this);
                if (m.Insert(r) == false)
                {
                    ModelState.AddModelError("", m.exception.GetBaseException().Message);
                    SuccessYN = false;
                    break;
                }

                break;
            }

            if (SuccessYN == true)
            {
                returnObject = RedirectToAction("Index");
            }
            else
            {
                returnObject = View("Create", vm);
            }

            return returnObject;
        }

        // GET: MembershipTypes/Edit/5
        public ActionResult Edit(int id)
        {
            ActionResult returnObject = null;
            ViewModelMembershipTypes vm = null;
            HandleErrorInfo ErrorMessage = null;

            while (true)
            {
                ModelMembershipTypes m = new ModelMembershipTypes(this);
                MembershipTypes r = m.Get(id);
                if (r == null)
                {
                    ErrorMessage = new HandleErrorInfo(m.exception.GetBaseException(), "MembershipTypes", "Edit");
                    returnObject = View("Error", ErrorMessage);
                    break;
                }


                vm = new ViewModelMembershipTypes(r);
                returnObject = View("Edit", vm);
                break;
            }

            return returnObject;
        }

        // POST: MembershipTypes/Edit/5
        [HttpPost]
        public ActionResult Edit(ViewModelMembershipTypes vm)
        {
            ActionResult returnObject = null;
            bool SuccessYN = true;

            while (true)
            {
                if (ModelState.IsValid == false)
                {
                    SuccessYN = false;
                    break;
                }

                MembershipTypes r = new MembershipTypes(vm);
                ModelMembershipTypes m = new ModelMembershipTypes(this);
                if (m.Update(r) == false)
                {
                    ModelState.AddModelError("", m.exception.GetBaseException().Message);
                    SuccessYN = false;
                    break;
                }

                break;
            }

            if (SuccessYN == true)
                returnObject = RedirectToAction("Index");
            else
                returnObject = View("Edit", vm);

            return returnObject;
        }

        // GET: MembershipTypes/Delete/5
        public ActionResult Delete(int id)
        {
            ActionResult returnObject = null;
            ViewModelMembershipTypes vm = null;
            HandleErrorInfo ErrorMessage = null;

            while (true)
            {
                ModelMembershipTypes m = new ModelMembershipTypes(this);
                MembershipTypes r = m.Get(id);
                if (r == null)
                {
                    ErrorMessage = new HandleErrorInfo(m.exception.GetBaseException(), "MembershipTypes", "Edit");
                    returnObject = View("Error", ErrorMessage);
                    break;
                }


                vm = new ViewModelMembershipTypes(r);
                returnObject = View("Delete", vm);
                break;
            }

            return returnObject;
        }

        // POST: MembershipTypes/Delete/5
        [HttpPost]
        public ActionResult Delete(ViewModelMembershipTypes vm)
        {
            ActionResult returnObject = null;
            bool SuccessYN = true;

            while (true)
            {
                if (ModelState.IsValid == false)
                {
                    SuccessYN = false;
                    break;
                }

                ModelMembershipTypes m = new ModelMembershipTypes(this);
                MembershipTypes r = new MembershipTypes(vm);
                if (m.Delete(r) == false)
                {
                    ModelState.AddModelError("", m.exception.GetBaseException().Message);
                    SuccessYN = false;
                    break;
                }

                break;
            }

            if (SuccessYN == true)
                returnObject = RedirectToAction("Index");
            else
                returnObject = View("Delete", vm);

            return returnObject;
        }
    }
}
