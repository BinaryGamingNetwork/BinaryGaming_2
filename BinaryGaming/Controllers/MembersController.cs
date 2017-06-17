﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BinaryGaming.Models;
using BinaryGaming.ViewModels;

namespace BinaryGaming.Controllers
{
    public class MembersController : Controller
    {
        [Authorize()]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            ActionResult returnObject = null;
            String userId = User.Identity.GetUserId();
            ModelMembers mMembers = new ModelMembers(this);
            ModelMembershipTypes mMembershipTypes = new ModelMembershipTypes(this);

            IList<MembershipTypes> listMembershipTypes = mMembershipTypes.GetListMembershipTypes();
            List<SelectListItem>  selectionMembershipTypes = new List<SelectListItem>();
            foreach (MembershipTypes item in listMembershipTypes)
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Value = item.Id.ToString();
                listItem.Text = item.MembershipType;
                selectionMembershipTypes.Add(listItem);
            }

            if (mMembers.IsProfileExist(userId) == true)
            {
                Members rMember = mMembers.GetRecordByUserId(userId);
                ViewModelUserProfile profile = new ViewModelUserProfile(rMember);
                profile.listMembershipTypes = selectionMembershipTypes;
                returnObject = View("MyProfile", profile);
            }
            else
            {
                ViewModelUserProfile profile = new ViewModelUserProfile();
                profile.UserId = userId;
                profile.listMembershipTypes = selectionMembershipTypes;
                returnObject = View("MyProfile", profile);
            }

            return returnObject;
        }

        [HttpPost]
        [Authorize]
        public ActionResult MyProfile(ViewModelUserProfile vmProfile)
        {
            ActionResult returnObject = null;
            String userId = User.Identity.GetUserId();
            ModelMembers mMembers = new ModelMembers(this);

            bool successYN = true;
            while (true)
            {
                if (ModelState.IsValid == false)
                {
                    successYN = false;
                    break;
                }

                if (mMembers.IsProfileExist(userId) == true)
                {
                    if (mMembers.GetRecordByUserId(userId).Id != vmProfile.Id)
                    {
                        ModelState.AddModelError("", "Profile ID doesn't match the expected Profile ID of Logged In User. Possible hacking attempt");
                        successYN = false;
                        break;

                    }

                    Members rMember = new Members(vmProfile);
                    if (mMembers.Update(rMember) == false)
                    {
                        ModelState.AddModelError("", mMembers.exception);
                        successYN = false;
                        break;
                    }
                }
                else
                {
                    Members rMember = new Members(vmProfile);
                    if (mMembers.Insert(rMember) == false)
                    {
                        ModelState.AddModelError("", mMembers.exception);
                        successYN = false;
                        break;
                    }
                }

                break;
            }

            if (successYN == true)
                returnObject = RedirectToAction("Index", "Manage");
            else
            {
                ModelMembershipTypes mMembershipTypes = new ModelMembershipTypes(this);

                IList<MembershipTypes> listMembershipTypes = mMembershipTypes.GetListMembershipTypes();
                List<SelectListItem> selectionMembershipTypes = new List<SelectListItem>();
                foreach (MembershipTypes item in listMembershipTypes)
                {
                    SelectListItem listItem = new SelectListItem();
                    listItem.Value = item.Id.ToString();
                    listItem.Text = item.MembershipType;
                    if (vmProfile.MembershipTypesId == item.Id)
                        listItem.Selected = true;
                    selectionMembershipTypes.Add(listItem);
                }
                vmProfile.listMembershipTypes = selectionMembershipTypes;
                returnObject = View("MyProfile", vmProfile);
            }
            return returnObject;
        }
    }
}