using MVCCSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCSharp.Controllers
{
    public class LeadController : Controller
    {
        // GET: Lead
        public ActionResult LeadDetails()
        {
            if (Session["id"] == null || (string)Session["Type"] != "Admin")
            {
                return RedirectToAction("Login", "Login");
            }
            Accountcontext accountContext = new Accountcontext();
            var Employeeid = accountContext.Accounts.Where(acc => acc.Type != "Admin").Select(acc => acc.Empid).ToList();
            Leadcontext leadContext = new Leadcontext();
            ViewBag.Employeeid = Employeeid;
            var account = leadContext.Leads.ToList();
            return View(account);
        }
        public ActionResult AddorEdit(Lead newacc)
        {
            try
            {
                using (Leadcontext acc = new Leadcontext())
                {
                    if (newacc.InteractionType == "Meeting")
                        newacc.LeadScore = "Hot";
                    else if (newacc.InteractionType == "Email")
                        newacc.LeadScore = "Cold";
                    else
                        newacc.LeadScore = "Warm";
                    if (newacc.Leadid == 0)
                    {
                        acc.Leads.Add(newacc);
                        acc.SaveChanges();
                        return RedirectToAction("LeadDetails", "Lead");
                    }
                    else
                    {
                        acc.Entry(newacc).State = EntityState.Modified;
                        acc.SaveChanges();
                        return RedirectToAction("LeadDetails", "Lead");
                    }
                }
            }
            catch(Exception Ex)
            {
                return Content("<script>alert('" + Ex.Message.Replace("\'", " ") + "')</script>");
            }
            }
        [HttpPost]
        public ActionResult Delete(int Leadid)
        {
            using (Leadcontext acc = new Leadcontext())
            {
                try
                {
                    Lead person = acc.Leads.Where(x => x.Leadid == Leadid).FirstOrDefault<Lead>();
                    acc.Leads.Remove(person);
                    acc.SaveChanges();
                    return RedirectToAction("LeadDetails", "Lead");
                }
                catch (Exception ex)
                {
                    return Content("<script>alert('" + ex.Message.Replace("\'", " ") + "')</script>");
                    // HttpContext.Response.Write("<script>alert('" + ex.Message.Replace("\'", " ") + "')</script>");
                    //return RedirectToAction("Details", "Account");
                }
            }

        }
    }
    }
