using MVCCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCSharp.Controllers
{
    public class AssignController : Controller
    {
        // GET: Assign
        public ActionResult AssignLeads()
        {
            if (Session["id"] == null || (string)Session["Type"]=="Admin")
            {

                return Content("<script>alert('"+"You Have no Authorize Access to This page" +"');window.location='../Home/Index';</script>");
                //return RedirectToAction("Login", "Login");
            }
            Accountcontext accountContext = new Accountcontext();
            int id = (int)Session["id"];
            var Employeeid = accountContext.Accounts.Where(acc => acc.Personid == id).Select(acc=>acc.Empid).FirstOrDefault();
            Leadcontext leadContext = new Leadcontext();
            ViewBag.Employeeid = Employeeid;
            var account = leadContext.Leads.Where(ld=>ld.Empid == Employeeid.ToString()).ToList();
            return View(account);
           
        }
    }
}