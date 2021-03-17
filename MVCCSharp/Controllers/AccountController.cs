using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCSharp.Models;

namespace MVCCSharp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        public ActionResult Details()
        {
            if (Session["id"] == null || (string)Session["Type"]!="Admin")
            {
                return RedirectToAction("Login", "Login");
            }
            Accountcontext accountContext = new Accountcontext();
            var account = accountContext.Accounts.Where(acc => acc.Type != "Admin").ToList();
            //var account = (from Account in accountContext.Accounts select Account).ToList();
            return View(account);
        }

        [HttpPost]
        public ActionResult AddorEdit(Account newacc)
        {
            using (Accountcontext acc = new Accountcontext())
            {
                try
                {
                    newacc.Type = "Sale";
                    if (newacc.Personid == 0)
                    {
                        acc.Accounts.Add(newacc);
                        acc.SaveChanges();
                        return RedirectToAction("Details", "Account");
                    }
                    else
                    {
                        acc.Entry(newacc).State = EntityState.Modified;
                        acc.SaveChanges();
                        return RedirectToAction("Details", "Account");
                    }
                }
                catch (Exception ex)
                {
                    return Content("<script>alert('" + ex.Message.Replace("\'", " ") + "')</script>");
                    // HttpContext.Response.Write("<script>alert('" + ex.Message.Replace("\'", " ") + "')</script>");
                    //return RedirectToAction("Details", "Account");
                }
            }

        }
        [HttpPost]
        public ActionResult Delete(int Personid)
        {
            using (Accountcontext acc = new Accountcontext())
            {
                try
                {
                    Account person = acc.Accounts.Where(x => x.Personid == Personid).FirstOrDefault<Account>();
                    acc.Accounts.Remove(person);
                    acc.SaveChanges();
                    return RedirectToAction("Details", "Account");
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