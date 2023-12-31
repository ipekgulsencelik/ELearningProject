﻿using ELearningProject.DAL.Context;
using ELearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ELearningProject.Controllers
{
    public class ContactInfoController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = context.ContactInfos.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContactInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContactInfo(ContactInfo contact)
        {
            if (Request.Form["Status"] != null)
            {
                // The "Status" checkbox was checked (true)
                string status = Request.Form["Status"]; // status will be "True"
            }
            else
            {
                // The "Status" checkbox was not checked (false)
                contact.Status = false;
            }

            context.ContactInfos.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContactInfo(int id)
        {
            var value = context.ContactInfos.Find(id);
            context.ContactInfos.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContactInfo(int id)
        {
            var value = context.ContactInfos.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContactInfo(ContactInfo contact)
        {
            var value = context.ContactInfos.Find(contact.ContactInfoID);
            value.Title = contact.Title;
            value.Description = contact.Description;
            value.Address = contact.Address;
            value.Phone = contact.Phone;
            value.Email = contact.Email;        
            value.SocialMedia1 = contact.SocialMedia1;
            value.SocialMedia2 = contact.SocialMedia2;
            value.SocialMedia3 = contact.SocialMedia3;
            value.SocialMedia4 = contact.SocialMedia4;
            value.Status = contact.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}